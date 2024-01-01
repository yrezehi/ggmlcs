using LLamacs.Native.Binding.Definitions.Batch;
using LLamacs.Native.Binding.Definitions.Context;
using LLamacs.Native.Binding.Definitions.Model;
using LLamacs.Native.Binding.Definitions.TokenData;
using System.Runtime.InteropServices;

namespace LLamacs.Native.Binding.LLava
{
    public static unsafe class LLavaMethods
    {
        [DllImport("llava", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void llama_sample_temperature(LLamaContext context, LLamaTokenDataArray candidates, float temp);
    }
}
