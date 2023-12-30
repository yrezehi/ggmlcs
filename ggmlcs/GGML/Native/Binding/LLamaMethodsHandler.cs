using GGML.Native.Binding.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GGML.Native.Binding
{
    public class LLamaMethodsHandler
    {
        public static extern LLamaModel LoadModelFromFile(string path, LLamaModelParams @params);
        
        public static extern void BackendInit(bool numa = false);
        
        public static extern LLamaModel NewContextWithModel(LLamaModel model, LLamaContextParams @params);
        
        public static extern int NCTXTrain(LLamaModel model);
        
        public static extern int NCtx(LLamaModel context);

        public static extern int NVocab(LLamaModel model);
        
        public static extern float* GetLogitsIth(LLamaContext context, int i);

        
        public static extern int Tokenize(LLamaModel model, string text, int textLength, [Out] LLamaToken[] tokens, int numberOfMaxTokens, bool addBos = false, bool special = true);
        
        public static extern int TokenToPiece(LLamaModel model, LLamaToken token, [Out] char[] buffer, int length);
        
        public static extern int TokenEos(LLamaModel model);
        
        public static extern int Decode(LLamaContext context, LLamaBatch batch);
        
        public static extern LLamaBatch BatchInit(int n_tokens = 512, int embd = 0, int n_seq_max = 1);

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
        
        public static extern void BatchFree(LLamaBatch batch);

        
        public static extern void FreeContext(LLamaModel context);
        
        public static extern void FreeModel(LLamaModel model);
        
        public static extern void BackendFree();

        public static extern LLamaContextParams ContextDefaultParams();
        public static extern LLamaModelParams ModelDefaultParams();

        
        public static extern LLamaToken llama_sample_token_greedy(LLamaContext context, ref LLamaTokenDataArray candidates);

        
        internal static extern void llama_sample_temperature(LLamaContext context, LLamaTokenDataArray candidates, float temp);
    }
}
