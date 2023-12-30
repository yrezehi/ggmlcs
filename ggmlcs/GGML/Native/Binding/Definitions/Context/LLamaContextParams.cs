using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GGML.Native.Binding.Definitions.Context
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LLamaContextParams
    {
        public int seed;
        public int n_ctx;
        public int n_batch;
        public int n_threads;
        public int n_threads_batch;
        public int rope_scaling_type;
        public float rope_freq_base;
        public float rope_freq_scale;
        public float yarn_ext_factor;
        public float yarn_attn_factor;
        public float yarn_beta_fast;
        public float yarn_beta_slow;
        public int yarn_orig_ctx;
        public int type_k;
        public int type_v;
        public bool mul_mat_q;
        public bool logits_all;
        public bool embedding;
        public bool offload_kqv;

        public static LLamaContextParams Default() =>
            new LLamaContextParams()
            {
                seed = (int)DateTime.Now.Ticks,
                n_ctx = 512,
                n_batch = 512,
                n_threads = 4,
                n_threads_batch = 4,
                rope_scaling_type = -1,
                rope_freq_base = 0.0f,
                rope_freq_scale = 0.0f,
                yarn_ext_factor = -1.0f,
                yarn_attn_factor = 1.0f,
                yarn_beta_fast = 32.0f,
                yarn_beta_slow = 1.0f,
                yarn_orig_ctx = 0,
                type_k = 1,
                type_v = 1,
                mul_mat_q = true,
                logits_all = false,
                embedding = false,
                offload_kqv = true,
            };
    }
}
