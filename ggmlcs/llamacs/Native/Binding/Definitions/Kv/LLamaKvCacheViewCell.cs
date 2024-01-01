using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.Kv
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct LLamaKvCacheViewCell
    {
        public LLamaPos pos;
    }
}
