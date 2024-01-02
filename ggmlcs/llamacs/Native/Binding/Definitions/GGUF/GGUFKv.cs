using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.GGUF
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GGUFKv
    {
        public GGUFStr key;

        public GGUFType  type;
        public GGUFValue value;
    }
}
