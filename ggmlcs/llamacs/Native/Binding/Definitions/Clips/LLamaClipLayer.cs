using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.Clips
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct LLamaClipLayer
    {
        public ggml_tensor* k_w;
        public ggml_tensor* k_b;
        public ggml_tensor* q_w;
        public ggml_tensor* q_b;
        public ggml_tensor* v_w;
        public ggml_tensor* v_b;

        public ggml_tensor* o_w;
        public ggml_tensor* o_b;

        public ggml_tensor* ln_1_w;
        public ggml_tensor* ln_1_b;

        public ggml_tensor* ff_i_w;
        public ggml_tensor* ff_i_b;

        public ggml_tensor* ff_o_w;
        public ggml_tensor* ff_o_b;

        public ggml_tensor* ln_2_w;
        public ggml_tensor* ln_2_b;
    }
}
