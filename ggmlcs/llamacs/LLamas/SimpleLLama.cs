using LLamacs.Native.Binding.Definitions.Batch;
using LLamacs.Native.Binding.Definitions.Context;
using LLamacs.Native.Binding.Definitions.Model;
using LLamacs.Native.Binding.Definitions.TokenData;
using LLamacs.Native.Binding.LLama;
using LLamacs.Native.DLLs;
using System.Text;

// reference llama.cpp official: https://github.com/ggerganov/llama.cpp/blob/8a5be3bd5885d79ad84aadf32bb8c1a67bd43c19/examples/simple/simple.cpp#L42

namespace LLamacs.LLamas
{
    public unsafe class SimpleLLama
    {
        private LLamaContext Context { get; set; }
        private LLamaModel Model { get; set; }

        private LLamaContextParams ContextParams { get; set; } = new LLamaContextParams();
        private LLamaModelParams ModelParams { get; set; } = new LLamaModelParams();

        private SimpleLLama(LLamaContext context, LLamaModel model, LLamaContextParams contextParams) =>
            (Context, Model, ContextParams) = (context, model, contextParams);

        public static SimpleLLama CreateInstance(string path)
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

            return new SimpleLLama(context, model, contextParams);
        }

        public string Infer(string prompt)
        {
            LLamaToken[] tokens = LLamaMethodsHandler.Tokenize(Model, prompt);
            StringBuilder result = new StringBuilder();

            int nLen = 32;

            int nCtx = LLamaMethodsHandler.NCtx(Context);
            int nKVReq = tokens.Length + (nLen - tokens.Length);

            if (nKVReq > nCtx)
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

            int nCur = batch.n_tokens;

            while (nCur <= nLen)
            {
                int nVocab = LLamaMethodsHandler.NVocab(Model);
                float* logits = LLamaMethodsHandler.GetLogitsIth(Context, batch.n_tokens - 1);

                LLamaTokenData[] candidates = new LLamaTokenData[nVocab];

                for (LLamaToken token = 0; token < nVocab; token++)
                {
                    candidates[token] = new LLamaTokenData(token, logits[token], 0.0f);
                }

                LLamaTokenDataArray candidatesP = new LLamaTokenDataArray(candidates, candidates.Length, false);

                LLamaToken tokenId = LLamaMethodsHandler.SampleTokenGreedy(Context, ref candidatesP);

                if (tokenId == LLamaMethodsHandler.TokenEos(Model) || nCur == nLen)
                {
                    break;
                }

                string resultText = LLamaMethodsHandler.TokenToPiece(Model, tokenId);

                result.Append(resultText);

                batch.n_tokens = 0;

                LLamaMethodsHandler.BatchAdd(ref batch, tokenId, nCur, new[] { 0 }, true);

                nCur += 1;

                LLamaMethodsHandler.Decode(Context, batch);
            }

            LLamaMethodsHandler.BatchFree(batch);

            FreeModelResources();

            return result.ToString();
        }


        public void FreeModelResources()
        {
            LLamaMethodsHandler.FreeContext(Context);
            LLamaMethodsHandler.FreeModel(Model);
            LLamaMethodsHandler.BackendFree();
        }
    }
}
