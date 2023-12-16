using System.Runtime.InteropServices;

namespace ggmlcs.Native.Binding.Params
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LLamaModelParams
    {
        public int n_gpu_layers;
        public int main_gpu;
        public LLamaModel tensor_split;
        public LLamaModel progress_callback;
        public LLamaModel progress_callback_user_data;
        public LLamaModel kv_overrides;
        public bool vocab_only;
        public bool use_mmap;
        public bool use_mlock;
    }
}
