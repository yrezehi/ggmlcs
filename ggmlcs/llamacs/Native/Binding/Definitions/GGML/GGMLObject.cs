using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.GGML
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct GGMLObject
    {
        public ulong offs;
        public ulong size;

        public GGMLObject* next;

        public GGMLObjectType type;

        public byte* padding;
    }
}
