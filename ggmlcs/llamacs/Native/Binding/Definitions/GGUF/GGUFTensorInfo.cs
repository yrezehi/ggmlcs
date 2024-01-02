using System.Runtime.InteropServices;

namespace LLamacs.Native.Binding.Definitions.GGUF
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct GGUFTensorInfo
    {
        public GGUFStr name;
        public uint n_dims;
        public ulong[] ne;

        public GGUFType type;

        public ulong offset;

        public void* data;
        public IntPtr size;
    }
}
