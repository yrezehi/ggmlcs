using System.Runtime.InteropServices;

namespace GGML.Native.Binding.Definitions
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct LLamaBatch
    {
        public int n_tokens;

        public LLamaToken* token;
        public float* embd;
        public LLamaPos* pos;
        public int* n_seq_id;
        public LlamaSeqId** seq_id;
        public byte* logits;

        public LLamaPos all_pos_0;
        public LLamaPos all_pos_1;
        public LlamaSeqId all_seq_id;
    }
}
