﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.GGUF
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GGMLContext
    {
        /*size_t mem_size;
        void* mem_buffer;
        bool mem_buffer_owned;
        bool no_alloc;
        bool no_alloc_save; // this is used to save the no_alloc state when using scratch buffers

        int n_objects;

        struct ggml_object * objects_begin;
        struct ggml_object * objects_end;

        struct ggml_scratch scratch;
        struct ggml_scratch scratch_save;*/
    }
}
