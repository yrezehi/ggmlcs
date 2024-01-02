using LLamacs.Native.Binding.Definitions.Batch;
using LLamacs.Native.Binding.Definitions.Context;
using LLamacs.Native.Binding.Definitions.KvOverride;
using LLamacs.Native.Binding.Definitions.Model;
using LLamacs.Native.Binding.Definitions.Sampling;
using LLamacs.Native.Binding.Definitions.TokenData;
using System.Runtime.InteropServices;

namespace LLamacs.Native.Binding.LLava
{
    public static unsafe class LLamaSamplingMethods
    {
        [DllImport("sampling", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLamaSamplingContext llama_sampling_init(LLamaSamplingParams @params);

        [DllImport("sampling", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLamaToken llama_sampling_sample(LLamaSamplingContext ctx_sampling, LLamaContext ctx_main, LLamaContext ctx_cfg, int idx);

        [DllImport("sampling", CallingConvention = CallingConvention.Cdecl)]
        public static extern void llama_sampling_accept(LLamaSamplingContext ctx_sampling, LLamaContext ctx_main, LLamaToken id, bool apply_grammar);

        [DllImport("sampling", CallingConvention = CallingConvention.Cdecl)]
        public static extern void llama_sampling_free(LLamaSamplingContext ctx);
    }
}
