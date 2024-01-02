using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.GGUF
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GGUFContext
    {
        
            public GGUFHeader header;
        public gguf_kv          * kv;
        public gguf_tensor_info * infos;
            /*
            size_t alignment;
            size_t offset;    // offset of `data` from beginning of file
            size_t size;      // size of `data` in bytes

            //uint8_t * padding;
            void * data;
         */
    }
}
