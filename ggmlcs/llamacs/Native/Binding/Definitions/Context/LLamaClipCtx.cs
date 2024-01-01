using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.Context
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LLamaClipCtx
    {
            public bool has_text_encoder;
            public bool has_vision_encoder;
            public bool has_llava_projector;
        /*
            struct clip_vision_model vision_model;

            float image_mean[3];
            float image_std[3];
            bool use_gelu = false;
            int32_t ftype = 1;

            struct gguf_context * ctx_gguf;
            struct ggml_context * ctx_data;

            std::vector<uint8_t> buf_compute_meta;

            // memory buffers to evaluate the model
            ggml_backend_buffer_t params_buffer = NULL;
            ggml_backend_buffer_t compute_buffer = NULL;
            ggml_backend_t backend = NULL;
            ggml_allocr * compute_alloc = NULL;
        */

        public static LLamaClipCtx Default()
        {
            return new LLamaClipCtx()
            {
                has_text_encoder = false,
                has_vision_encoder = false,
                has_llava_projector = false,
            };
        }
    }
}
