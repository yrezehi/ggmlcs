using LLamacs.Native.Binding.Definitions.Batch;
using LLamacs.Native.Binding.Definitions.Context;
using LLamacs.Native.Binding.Definitions.Model;
using LLamacs.Native.Binding.Definitions.TokenData;
using System.Runtime.InteropServices;

namespace LLamacs.Native.Binding.LLava
{
    public static unsafe class LLavaClipMethods
    {
        [DllImport("clip", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLamaClipCtx clip_model_load(string fname, int verbosity = 1);
    }
}
