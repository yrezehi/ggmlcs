using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GGML.Native.Binding.Definitions
{
    [StructLayout(LayoutKind.Explicit)]
    public struct LlamaModelKvOverrideValue
    {
        [FieldOffset(0)]
        public long int_value;

        [FieldOffset(0)]
        public double float_value;

        [FieldOffset(0)]
        public bool bool_value;
    }
}
