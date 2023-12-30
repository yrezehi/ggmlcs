using System.Runtime.InteropServices;

namespace GGML.Native.Binding.Definitions
{
    public unsafe struct LLamaModelParams
    {
        public int n_gpu_layers;
        public int main_gpu;
        public float* tensor_split;
        public LlamaProgressCallback? progress_callback;
        public void* progress_callback_user_data;
        public LlamaModelKvOverride* kv_overrides;
        public bool vocab_only;
        public bool use_mmap;
        public bool use_mlock;

        public static LLamaModelParams Default()
        {
            return new LLamaModelParams {
                n_gpu_layers                = 0,
                main_gpu                    = 0,
                tensor_split                = null,
                progress_callback           = null,
                progress_callback_user_data = null,
                kv_overrides                = null,
                vocab_only                  = false,
                use_mmap                    = true,
                use_mlock                   = false,
            };
        }
    }
}
