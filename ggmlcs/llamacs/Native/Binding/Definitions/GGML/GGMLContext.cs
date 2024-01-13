using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.GGML
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct GGMLContext
    {
        public ulong mem_size { get; set; }
        public void* mem_buffer { get; set; }
        public bool mem_buffer_owned { get; set; }
        public bool no_alloc { get; set; }
        public bool no_alloc_save { get; set; }

        public int n_objects { get; set; }

        public GGMLObject* objects_begin;
        public GGMLObject* objects_end;

        public GGMLScratch scratch;
        public GGMLScratch scratch_save;
    }
}
