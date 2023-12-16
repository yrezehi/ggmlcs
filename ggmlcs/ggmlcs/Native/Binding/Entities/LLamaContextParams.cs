using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ggmlcs.Native.Binding.Params
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
    }
}
