using GGML.Native.Binding.Definitions.Batch;
using GGML.Native.Binding.Definitions.Context;
using GGML.Native.Binding.Definitions.Model;
using GGML.Native.Binding.Definitions.TokenData;
using GGML.Native.Binding.Mode.Instruct;
using System.Reflection;
using System.Runtime.InteropServices;

namespace GGML.Native.Binding
{
    public static unsafe class LLamaMethodsHandler
    {
        public static LLamaModel LoadModelFromFile(string path, LLamaModelParams @params)
        {
            LLamaModel model = LLamaMethods.llama_load_model_from_file(path, @params);
            
            if (model == LLamaModel.Zero)
            {
                throw new MemberAccessException(message: $"Unable to load model {path}");
            }

            return model;
        }
        
        public static void BackendInit(bool numa = false) =>
            LLamaMethods.llama_backend_init(numa);
        
        public static LLamaModel NewContextWithModel(LLamaModel model, LLamaContextParams @params)
        {
            LLamaModel context = LLamaMethods.llama_new_context_with_model(model, @params);

            if (context == LLamaModel.Zero)
            {
                throw new MemberAccessException(message: $"Unable to load context!");
            }

            return context;
        }
        
        public static int NCTXTrain(LLamaModel model) =>
            LLamaMethods.llama_n_ctx_train(model);
        
        public static int NCtx(LLamaModel context) =>
            LLamaMethods.llama_n_ctx(context);

        public static int NVocab(LLamaModel model) =>
            LLamaMethods.llama_n_vocab(model);
        
        public static float* GetLogitsIth(LLamaContext context, int i) =>
            LLamaMethods.llama_get_logits_ith(context, i);


        public static LLamaToken[] Tokenize(LLamaModel model, string text)
        {
            LLamaToken[] tokens = new LLamaToken[text.Length];
            int tokensSize = LLamaMethods.llama_tokenize(model, text, text.Length, tokens, tokens.Length, false, true);
            Array.Resize(ref tokens, tokensSize);
            return tokens;
        }
        
        public static int TokenToPiece(LLamaModel model, LLamaToken token, [Out] char[] buffer, int length) =>
            LLamaMethods.llama_token_to_piece(model, token, buffer, length);
        
        public static int TokenEos(LLamaModel model) => 
            LLamaMethods.llama_token_eos(model);

        public static int Decode(LLamaContext context, LLamaBatch batch)
        {
            int result = LLamaMethods.llama_decode(context, batch);

            if (result != 0)
            {
                throw new MemberAccessException(message: $"Failed to decode batch!");
            }

            return result;
        }
        
        public static LLamaBatch BatchInit(int n_tokens = 512, int embd = 0, int n_seq_max = 1) =>
            LLamaMethods.llama_batch_init(n_tokens, embd, n_seq_max);

        public static void BatchAdd(ref LLamaBatch batch, LLamaToken id, LLamaPos pos, ReadOnlySpan<LlamaSeqId> seqIds, bool logits)
        {
            batch.token[batch.n_tokens] = id;
            batch.pos[batch.n_tokens] = pos;
            batch.n_seq_id[batch.n_tokens] = seqIds.Length;

            for (var i = 0; i < seqIds.Length; ++i)
                batch.seq_id[batch.n_tokens][i] = seqIds[i];

            batch.logits[batch.n_tokens] = Convert.ToByte(logits);

            batch.n_tokens++;
        }
        
        public static void BatchFree(LLamaBatch batch) =>
            LLamaMethods.llama_batch_free(batch);
        
        public static void FreeContext(LLamaModel context) =>
            LLamaMethods.llama_free(context);   
        
        public static void FreeModel(LLamaModel model) =>
            LLamaMethods.llama_free_model(model);
        
        public static void BackendFree() =>
            LLamaMethods.llama_backend_free();

        public static LLamaContextParams ContextDefaultParams() =>
            LLamaMethods.llama_context_default_params();
        
        public static LLamaModelParams ModelDefaultParams() =>
            LLamaMethods.llama_model_default_params();
        
        public static LLamaToken SampleTokenGreedy(LLamaContext context, ref LLamaTokenDataArray candidates) =>
            LLamaMethods.llama_sample_token_greedy(context, ref candidates);
        
        internal static void SampleTemperature(LLamaContext context, ref LLamaTokenDataArray candidates, float temp) =>
            LLamaMethods.llama_sample_temperature(context, candidates, temp);
    }
}
