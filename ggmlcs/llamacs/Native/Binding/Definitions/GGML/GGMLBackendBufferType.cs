using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.GGML
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct GGMLBackendBufferType
    {
        public ggml_backend_buffer_type_i  iface;
        public ggml_backend_buffer_type_context_t context;
    }
}
