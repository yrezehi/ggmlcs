using System.Runtime.InteropServices;

namespace LLamacs.Native.Binding.Definitions.TokenData
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

            this.size = (ulong)size;
            this.sorted = sorted;
        }
    }
}
