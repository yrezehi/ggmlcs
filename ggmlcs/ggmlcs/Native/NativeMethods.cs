using System.Runtime.InteropServices;

namespace ggmlcs.Native
{
    public static class NativeMethods
    {
        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern void llama_backend_init(bool numa);
        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern void llama_new_context_with_model(IntPtr model);
        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern void llama_n_ctx_train(IntPtr model);
        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern void llama_n_ctx(IntPtr context);
        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern void llama_tokenize(IntPtr context, string prompt, bool add_bos, bool special);
        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern void llama_token_to_piece(IntPtr context, Int32 token);
        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern void llama_token_eos(IntPtr model);
        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern void llama_free(IntPtr context);
        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern void llama_free_model(IntPtr model);
        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern void llama_backend_free();
        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern void llama_context_default_params();
        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern void llama_model_default_params();
    }
}
