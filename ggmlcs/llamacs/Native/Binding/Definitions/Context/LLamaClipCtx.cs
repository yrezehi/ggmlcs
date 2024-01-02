using LLamacs.Native.Binding.Definitions.GGUF;
using LLamacs.Native.Binding.Definitions.Vision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.Context
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct LLamaClipCtx
    {
        public bool has_text_encoder;
        public bool has_vision_encoder;
        public bool has_llava_projector;
        
        public ClipVisionModel vision_model;

        public float[] image_mean;
        public float[] image_std;

        public bool use_gelu;

        public int ftype;
            
        public GGUFContext* ctx_gguf;
        public GGMLContext* ctx_data;

        public byte[] buf_compute_meta;

        public GGMLBackendBufferT params_buffer;
        public GGMLBackendBufferT compute_buffer;

        public GGMLBackendT backend;
        public GGMLAllocr* compute_alloc;
    }
}
