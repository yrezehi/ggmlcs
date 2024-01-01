using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.LLava
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct LLavaImageEmbed
    {
        public float* embed;
        public int n_image_pos;
    }
}
