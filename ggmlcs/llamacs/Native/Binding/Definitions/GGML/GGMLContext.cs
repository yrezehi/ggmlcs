using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.GGUF
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct GGMLContext
    {
        public UIntPtr mem_size { get; set; }
        public void* mem_buffer { get; set; }
        public bool mem_buffer_owned { get; set; }
        public bool no_alloc { get; set; }
        public bool no_alloc_save { get; set; }

        public int n_objects { get; set; }

        /*
        struct ggml_object * objects_begin;
        struct ggml_object * objects_end;

        struct ggml_scratch scratch;
        struct ggml_scratch scratch_save;*/
    }
}
