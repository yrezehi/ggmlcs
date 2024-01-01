using LLamacs.Native.Binding.Definitions.Batch;
using LLamacs.Native.Binding.Definitions.Context;
using LLamacs.Native.Binding.Definitions.Model;
using LLamacs.Native.Binding.Definitions.TokenData;
using LLamacs.Native.Binding.LLama;
using LLamacs.Native.DLLs;
using System.Text;

// reference llama.cpp official: https://github.com/ggerganov/llama.cpp/blob/8a5be3bd5885d79ad84aadf32bb8c1a67bd43c19/examples/simple/simple.cpp#L42

namespace LLamacs.Local
{
    public unsafe class LLavaLLama : ILLama<string>
    {
        private LLamaContext Context { get; set; }
        private LLamaModel Model { get; set; }

        private LLamaContextParams ContextParams { get; set; } = new LLamaContextParams();
        private LLamaModelParams ModelParams { get; set; } = new LLamaModelParams();

        private LLavaLLama(LLamaContext context, LLamaModel model, LLamaContextParams contextParams) =>
            (Context, Model, ContextParams) = (context, model, contextParams);

        public static LLavaLLama CreateInstance(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }

            DLLLoader.LibraryLoad();

            LLamaMethodsHandler.BackendInit();

            LLamaModelParams modelParams = LLamaModelParams.Default();

            LLamaModel model = LLamaMethodsHandler.LoadModelFromFile(path, modelParams);

            LLamaContextParams contextParams = LLamaContextParams.Default();

            LLamaContext context = LLamaMethodsHandler.NewContextWithModel(model, contextParams);

            return new LocalLLama(context, model, contextParams);
        }

        public void Infer(string prompt)
        {
            Console.Write(prompt);

            LLamaToken[] tokens = LLamaMethodsHandler.Tokenize(Model, prompt);

            int n_len = 32;

            int n_ctx = LLamaMethodsHandler.NCtx(Context);
            int n_kv_req = tokens.Length + (n_len - tokens.Length);

            if (n_kv_req > n_ctx)
            {
                throw new MemberAccessException(message: $"KV Cache is not big enough!");
            }

            LLamaBatch batch = LLamaMethodsHandler.BatchInit(512, 0, 1);

            for (int index = 0; index < tokens.Length; index++)
            {
                LLamaMethodsHandler.BatchAdd(ref batch, tokens[index], index, new[] { 0 }, false);
            }

            batch.logits[batch.n_tokens - 1] = 1;

            LLamaMethodsHandler.Decode(Context, batch);

            int n_cur = batch.n_tokens;

            while (n_cur <= n_len)
            {
                int n_vocab = LLamaMethodsHandler.NVocab(Model);
                float* logits = LLamaMethodsHandler.GetLogitsIth(Context, batch.n_tokens - 1);

                LLamaTokenData[] candidates = new LLamaTokenData[n_vocab];

                for (LLamaToken token = 0; token < n_vocab; token++)
                {
                    candidates[token] = new LLamaTokenData(token, logits[token], 0.0f);
                }

                LLamaTokenDataArray candidates_p = new LLamaTokenDataArray(candidates, candidates.Length, false);

                LLamaToken token_id = LLamaMethodsHandler.SampleTokenGreedy(Context, ref candidates_p);

                if (token_id == LLamaMethodsHandler.TokenEos(Model) || n_cur == n_len)
                {
                    break;
                }

                string resultText = LLamaMethodsHandler.TokenToPiece(Model, token_id);

                Console.Write(resultText);

                batch.n_tokens = 0;

                LLamaMethodsHandler.BatchAdd(ref batch, token_id, n_cur, new[] { 0 }, true);

                n_cur += 1;

                LLamaMethodsHandler.Decode(Context, batch);
            }

            LLamaMethodsHandler.BatchFree(batch);

            FreeModelResources();
        }


        public void FreeModelResources()
        {
            LLamaMethodsHandler.FreeContext(Context);
            LLamaMethodsHandler.FreeModel(Model);
            LLamaMethodsHandler.BackendFree();
        }
    }
}
