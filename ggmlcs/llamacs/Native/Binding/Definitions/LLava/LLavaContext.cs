using LLamacs.Native.Binding.Definitions.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.LLava
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public unsafe struct LLavaContext
    {
        public LLamaClipCtx ctx_clip;
        public LLamaContext llama_context;
        public LLamaModel model;

        public static LLavaContext Create(LLamaClipCtx ctxClip, LLamaContext llamaContext, LLamaModel llamaModel) =>
            new LLavaContext()
            {
                ctx_clip = ctxClip,
                llama_context = llamaContext,
                model = llamaModel,
            };
    }
}
