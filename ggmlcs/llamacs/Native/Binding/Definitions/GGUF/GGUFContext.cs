using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.GGUF
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct GGUFContext
    {
        public GGUFHeader header;
        public GGUFKv* kv;
        public GGUFTensorInfo* infos;

        public IntPtr alignment;
        public IntPtr offset;    
        public IntPtr size;      

        public void* data;
    }
}
