﻿using LLamacs.Native.Binding.LLama;
using LLamacs.Native.Binding.LLava;
using LLamacs.Native.Binding.Definitions.LLava;
using LLamacs.Native.Binding.Definitions.Model;
using LLamacs.Native.Binding.Definitions.Batch;
using LLamacs.Native.Binding.Definitions.Context;
using LLamacs.Native.Binding.Definitions.Sampling;
using LLamacs.Native.DLLs;
using LLamacs.Native.Binding.Definitions.Clips;
using System.Text;
using LLamacs.Native.Binding.Sampling;

namespace LLamacs.LLava
{
    public unsafe class LLavaLLama
    {
        public const string IMAGE_BASE64_TAG_BEGIN = "<img src=\"data:image/jpeg;base64,";
        public const string IMAGE_BASE64_TAG_END = "\">";

        public const string QUESTION_ANSWERING_PROMPT = "A chat between a curious human and an artificial intelligence assistant.  The assistant gives helpful, detailed, and polite answers to the human's questions.\nUSER:";
        public const string ASSISTANT_PROMPT_SUFFIX = "\nASSISTANT:";

        public const int n_batch = 16;

        public LLavaLLama(string modelPath, string prompt, string clipPath, string imagePath)
        {
            DLLLoader.LibraryLoad();

            char[] chars = clipPath.ToCharArray();
            LLamaClipCtx clipCtx;
            // Convert char[] to char*
            fixed (char* charPtr = chars)
            {
                clipCtx = LLavaClipMethods.clip_model_load(charPtr);
            }

            LLamaMethodsHandler.BackendInit();

            LLamaModelParams modelParams = LLamaModelParams.Default();

            LLamaModel llamaModel = LLamaMethodsHandler.LoadModelFromFile(modelPath, modelParams);

            LLamaContextParams contextParams = LLamaContextParams.Default();

            LLamaContext llamaContext = LLamaMethodsHandler.NewContextWithModel(llamaModel, contextParams);

            LLavaContext llavaContext = LLavaContext.Create(clipCtx, llamaContext, llamaModel);

            LLavaImageEmbed image = LoadImage(clipCtx, llavaContext, prompt, imagePath);

            ProcessPrompt(llavaContext, image, prompt);

            LLavaMethods.llava_image_embed_free(image);

            LLamaMethodsHandler.FreeContext(llamaContext);
            LLamaMethodsHandler.FreeModel(llamaModel);
            LLamaMethodsHandler.BackendFree();
        }


        public LLavaImageEmbed LoadImage(LLamaClipCtx clipCtx, LLavaContext llavaContext, string prompt, string imagePath)
        {
            LLavaImageEmbed imageEmbed = new LLavaImageEmbed();

            if (PromptContainsImage(prompt))
            {
                throw new NotImplementedException();
            }
            else
            {
                return ProcessImagePath(clipCtx, imagePath);
            }
        }

        public void ProcessPrompt(LLavaContext context, LLavaImageEmbed imageEmbed, string prompt)
        {
            int n_past = 0;
            int max_tgt_len = 256;

            EvalString(context.llama_context, QUESTION_ANSWERING_PROMPT, n_batch, n_past, false);
            EvalImageEmbed(context.llama_context, context.model, imageEmbed, n_batch, n_past);
            EvalString(context.llama_context, prompt + ASSISTANT_PROMPT_SUFFIX, n_batch, n_past, false);

            LLamaSamplingParams samplingParams = new LLamaSamplingParams();
            LLamaSamplingContext samplingContext = LLamaSamplingMethods.llama_sampling_init(samplingParams);

            for (int index = 0; index < max_tgt_len; index++)
            {
                string tmp = Sample(context.model, samplingContext, context.llama_context, n_past);

                if (string.Compare(tmp, "</s") == 0)
                {
                    break;
                }

                Console.Write(tmp);
            }

            LLamaSamplingMethods.llama_sampling_free(samplingContext);
        }

        public string Sample(LLamaModel llamaModel, LLamaSamplingContext samplingContext, LLamaContext llamaContext, int n_past)
        {
            LLamaToken id = LLamaSamplingMethods.llama_sampling_sample(samplingContext, llamaContext, GGMLAllocr.Zero, 0);

            LLamaSamplingMethods.llama_sampling_accept(samplingContext, llamaContext, id, true);

            string ret;

            if (id == LLamaMethodsHandler.TokenEos(llamaModel))
            {
                ret = "</s>";
            }
            else
            {
                ret = LLamaMethodsHandler.TokenToPiece(llamaContext, id);
            }

            evalId(llamaContext, id, n_past);

            return ret;
        }

        public bool evalId(LLamaContext ctxLLama, int id, int nPast)
        {
            LLamaToken[] tokens = new LLamaToken[1];
            tokens[0] = id;

            return evalTokens(ctxLLama, tokens, 1, nPast);
        }

        static bool evalTokens(LLamaContext ctx_llama, LLamaToken[] tokens, int n_batch, int n_past)
        {
            int n = tokens.Length;

            for (int index = 0; index < n; index += n_batch)
            {
                int n_eval = tokens.Length - index;

                if (n_eval > n_batch)
                {
                    n_eval = n_batch;
                }

                LLamaMethodsHandler.Decode(ctx_llama, LLamaMethods.llama_batch_get_one(tokens, n_eval, n_past, 0));

                n_past += n_eval;
            }

            return true;
        }

        public void EvalImageEmbed(LLamaContext context, LLamaModel model, LLavaImageEmbed image_embed, int n_batch, int n_past)
        {
            int n_embd = LLamaMethods.llama_n_embd(model);

            for (int i = 0; i < image_embed.n_image_pos; i += n_batch)
            {
                int n_eval = image_embed.n_image_pos - i;

                if (n_eval > n_batch)
                {
                    n_eval = n_batch;
                }

                LLamaBatch batch = LLamaMethodsHandler.BatchInit();

                batch.n_tokens = n_eval;
                batch.token = null;
                batch.embd = image_embed.embed + i * n_embd;
                batch.pos = null;
                batch.n_seq_id = null;
                batch.seq_id = null;
                batch.logits = null;
                batch.all_pos_0 = n_past;
                batch.all_pos_1 = 1;
                batch.all_seq_id = 0;

                LLamaMethodsHandler.Decode(context, batch);
            }
        }

        public void EvalTokens(LLamaContext context, LLamaToken[] tokens, int n_batch, int n_past)
        {
            int n = tokens.Length;

            for (int i = 0; i < n; i += n_batch)
            {
                int n_eval = tokens.Length - i;
                if (n_eval > n_batch)
                {
                    n_eval = n_batch;
                }

                LLamaMethodsHandler.Decode(context, LLamaMethods.llama_batch_get_one(tokens, n_eval, n_past, 0));

                n_past += n_eval;
            }

        }

        public void EvalString(LLamaModel model, string str, int n_batch, int n_past, bool add_bos)
        {
            LLamaToken[] tokens = LLamaMethodsHandler.Tokenize(model, str);
            evalTokens(model, tokens, n_batch, n_past);
        }

        public LLavaImageEmbed ProcessImagePath(LLamaClipCtx clipCtx, string imagePath)
        {
            return LLavaMethods.llava_image_embed_make_with_filename(clipCtx, 4, imagePath);
        }

        public bool PromptContainsImage(string prompt)
        {
            int begin = -1, end = -1;
            FindImageTagInPrompt(prompt, out begin, out end);

            return begin != -1;
        }

        public void FindImageTagInPrompt(string prompt, out int begin, out int end)
        {
            begin = prompt.IndexOf(IMAGE_BASE64_TAG_BEGIN);
            end = prompt.IndexOf(IMAGE_BASE64_TAG_END);
        }
    }
}
