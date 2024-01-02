using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.GGUF
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GGUFValue
    {
        public byte uint8;
        public sbyte int8;
        public ushort uint16;
        public short int16;
        public uint uint32;
        public int int32;
        public float float32;
        public ulong uint64;
        public long int64;
        public double float64;
        public bool bool_;

        public GGUFStr str;
        public GGUFArray arr;
    }
}
