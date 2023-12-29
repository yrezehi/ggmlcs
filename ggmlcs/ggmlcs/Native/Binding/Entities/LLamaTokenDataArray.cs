using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ggmlcs.Native.Binding.Entities
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct LLamaTokenDataArray
    {
        public LLamaTokenData* data;
        public ulong size;
        public bool sorted;

        public LLamaTokenDataArray(LLamaTokenData[] data, int size, bool sorted)
        {
            fixed (LLamaTokenData* llamaTokenData = data)
            {
                this.data = llamaTokenData;
            }

            this.size = (ulong) size;
            this.sorted = sorted;
        }
    }
}
