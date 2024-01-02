using LLamacs.Native.Binding.Definitions.Batch;
using LLamacs.Native.Binding.Definitions.Context;
using LLamacs.Native.Binding.Definitions.KvOverride;
using LLamacs.Native.Binding.Definitions.Model;
using LLamacs.Native.Binding.Definitions.Sampling;
using LLamacs.Native.Binding.Definitions.TokenData;
using System.Runtime.InteropServices;

namespace LLamacs.Native.Binding.LLava
{
    public static unsafe class LLavaSamplingMethods
    {
        [DllImport("sampling", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLamaSamplingContext llama_sampling_init(LLamaSamplingParams @params);
    }
}
