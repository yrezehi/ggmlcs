using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ggmlcs.Native.Binding.Entities
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LlamaModelKvOverride
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] key;

        public LlamaModelKvOverrideType tag;

        public LlamaModelKvOverrideValue value;
    }
}
