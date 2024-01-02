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

        public ggml_tensor* class_embedding;
        public ggml_tensor* patch_embeddings;
        public ggml_tensor* position_embeddings;
        public ggml_tensor* pre_ln_w;
        public ggml_tensor* pre_ln_b;

        public std::vector<clip_layer> layers;
        public ggml_tensor* post_ln_w;
        public ggml_tensor* post_ln_b;

        public ggml_tensor* projection;

        public ggml_tensor* mm_0_w;
        public ggml_tensor* mm_0_b;
        public ggml_tensor* mm_2_w;
        public ggml_tensor* mm_2_b;
    }
}
