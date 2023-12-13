using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ggmlcs.Native.Binding.Structs
{

    [StructLayout(LayoutKind.Sequential)]
    public struct LLamaContextParams
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
}
