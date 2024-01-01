using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.Vision
{
    [StructLayout(LayoutKind.Sequential)]
    public class ClipVisionModel
    {
        /*
            struct clip_vision_hparams hparams;

            struct ggml_tensor * class_embedding;
            struct ggml_tensor * patch_embeddings;
            struct ggml_tensor * position_embeddings;

            struct ggml_tensor * pre_ln_w;
            struct ggml_tensor * pre_ln_b;

            std::vector<clip_layer> layers;

            struct ggml_tensor * post_ln_w;
            struct ggml_tensor * post_ln_b;

            struct ggml_tensor * projection;

            // LLaVA projection
            struct ggml_tensor * mm_0_w;
            struct ggml_tensor * mm_0_b;
            struct ggml_tensor * mm_2_w;
            struct ggml_tensor * mm_2_b;
         */
    }
}
