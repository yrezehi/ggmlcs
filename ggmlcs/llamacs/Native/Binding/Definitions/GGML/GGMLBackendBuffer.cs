﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.GGML
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct GGMLBackendBuffer
    {
        public ggml_backend_buffer_i  iface;
        public ggml_backend_buffer_type_t buft;
        public ggml_backend_buffer_context_t context;
        public UIntPtr size;
    }
}
