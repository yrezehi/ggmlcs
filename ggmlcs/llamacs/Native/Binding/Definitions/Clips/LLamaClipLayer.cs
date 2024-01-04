using LLamacs.Native.Binding.Definitions.GGML;
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
        public GGMLTensor* k_w;
        public GGMLTensor* k_b;
        public GGMLTensor* q_w;
        public GGMLTensor* q_b;
        public GGMLTensor* v_w;
        public GGMLTensor* v_b;

        public GGMLTensor* o_w;
        public GGMLTensor* o_b;

        public GGMLTensor* ln_1_w;
        public GGMLTensor* ln_1_b;

        public GGMLTensor* ff_i_w;
        public GGMLTensor* ff_i_b;

        public GGMLTensor* ff_o_w;
        public GGMLTensor* ff_o_b;

        public GGMLTensor* ln_2_w;
        public GGMLTensor* ln_2_b;
    }
}
