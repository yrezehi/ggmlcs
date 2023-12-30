using System.Runtime.InteropServices;

namespace LLamacs.Native.Binding.Definitions.KvOverride
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
