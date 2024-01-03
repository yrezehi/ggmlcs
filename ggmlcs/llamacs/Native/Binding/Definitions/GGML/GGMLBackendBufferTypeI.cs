using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.GGML
{

    public delegate GGMLBackendBufferT AllocBuffer(GGMLBackendBufferTypeT buft, IntPtr size);
    public delegate IntPtr GetAlignment(GGMLBackendBufferTypeT buft);
    public delegate IntPtr GetAllocSize(GGMLBackendBufferTypeT buft, GGMLTensor tensor);
    public delegate bool SupportsBackend(GGMLBackendBufferTypeT buft, GGMLBackend backend);
    public delegate bool IsHost(GGMLBackendBufferTypeT buft);

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct GGMLBackendBufferTypeI
    {
        public AllocBuffer alloc_buffer;
        public GetAlignment get_alignment;
        public GetAllocSize get_allocSize;
        public SupportsBackend supports_backend;
        public IsHost is_host;
    }
}
