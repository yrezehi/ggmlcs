using System.Runtime.InteropServices;

namespace ggmlcs.Native
{

    using llama_token = Int32;

    /// <summary>
    /// The LLaMA token data.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LLaMATokenData
    {
        public llama_token id;  // token id

        public float p;     // probability of the token
        public float plog;  // log probability of the token
    }

    /// <summary>
    /// The LLaMA context parameters.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LLaMAContextParams
    {
        public int n_ctx;   // text context
        public int n_parts; // -1 for default
        public int seed;    // RNG seed, 0 for random

        public bool f16_kv;     // use fp16 for KV cache
        public bool logits_all; // the llama_eval() call computes all logits, not just the last one
        public bool vocab_only; // only load the vocabulary, no weights
        public bool use_mlock;  // force system to keep model in RAM
        public bool embedding;  // embedding mode only
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BinConfiguration
    {
        public int dim;
        public int hidden_dim;
        public int n_layers;
        public int n_heads;
        public int n_kv_heads;
        public int vocab_size;
        public int seq_len;
    }

    /// <summary>
    /// The native methods for LLaMA.
    /// </summary>
    public static class LLaMANativeMethods
    {
        public static class LLaMANativeMethods
        {
            [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
            public static extern void llama_backend_init(bool numa);
            [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
            public static extern void llama_new_context_with_model(IntPtr model);
            [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
            public static extern void llama_n_ctx_train(IntPtr model);
            [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
            public static extern void llama_n_ctx(IntPtr context);
        }
    }
}
