using LLamacs.Native.Binding.Definitions.Clips;
using LLamacs.Native.Binding.Definitions.GGML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.Vision
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ClipVisionModel
    {
        public ClipVisionHParams hparams;

        public GGMLTensor* class_embedding;
        public GGMLTensor* patch_embeddings;
        public GGMLTensor* position_embeddings;
        public GGMLTensor* pre_ln_w;
        public GGMLTensor* pre_ln_b;

        public LLamaClipLayer[] layers;
        public GGMLTensor* post_ln_w;
        public GGMLTensor* post_ln_b;

        public GGMLTensor* projection;

        public GGMLTensor* mm_0_w;
        public GGMLTensor* mm_0_b;
        public GGMLTensor* mm_2_w;
        public GGMLTensor* mm_2_b;
    }
}
