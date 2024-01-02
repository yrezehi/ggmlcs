using LLamacs.Native.Binding.Definitions.Batch;
using LLamacs.Native.Binding.Definitions.Context;
using LLamacs.Native.Binding.Definitions.LLava;
using LLamacs.Native.Binding.Definitions.Model;
using LLamacs.Native.Binding.Definitions.TokenData;
using System.Runtime.InteropServices;

namespace LLamacs.Native.Binding.LLava
{
    public static unsafe class LLavaMethods
    {
        [DllImport("llava", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLavaImageEmbed llava_image_embed_make_with_filename(LLamaClipCtx clip_ctx, int n_threads, string imagePath);

        [DllImport("llava", CallingConvention = CallingConvention.Cdecl)]
        public static extern void llava_image_embed_free(LLavaImageEmbed embed);
    }
}
