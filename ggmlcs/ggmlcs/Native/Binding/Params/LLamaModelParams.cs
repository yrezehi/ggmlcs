using System.Runtime.InteropServices;

namespace ggmlcs.Native.Binding.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LLamaModelParams
    {
        public int n_gpu_layers;
        public int main_gpu;
        public IntPtr tensor_split;
        public IntPtr progress_callback;
        public IntPtr progress_callback_user_data;
        public IntPtr kv_overrides;
        public bool vocab_only;
        public bool use_mmap;
        public bool use_mlock;
    }
}
