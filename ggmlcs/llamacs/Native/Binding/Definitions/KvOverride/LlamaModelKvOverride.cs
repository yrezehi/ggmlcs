using System.Runtime.InteropServices;

namespace LLamacs.Native.Binding.Definitions.KvOverride
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct LlamaModelKvOverride
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string key;

        public LlamaModelKvOverrideType tag;

        [MarshalAs(UnmanagedType.Struct)]
        public LlamaModelKvOverrideValue value;
    }
}
