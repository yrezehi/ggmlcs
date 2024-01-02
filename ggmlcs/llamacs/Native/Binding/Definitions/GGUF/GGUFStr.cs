using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.GGUF
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct GGUFStr
    {
        public long n;
        public char* data;
    }
}
