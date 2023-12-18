using ggmlcs.Native.Binding.Entities;
using System.Runtime.InteropServices;

namespace ggmlcs.Native.Binding.Params
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LLamaModelParams
    {
        public int n_gpu_layers;
        public int main_gpu;
        public float tensor_split;
        public LlamaProgressCallback progress_callback;
        public void progress_callback_user_data;
        public -- kv_overrides;
        public bool vocab_only;
        public bool use_mmap;
        public bool use_mlock;
    }
}
