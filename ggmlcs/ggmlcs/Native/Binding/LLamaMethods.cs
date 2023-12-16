using ggmlcs.Native.Binding.Structs;
using System.Runtime.InteropServices;

namespace ggmlcs.Native.Binding
{
    public static class LLamaMethods
    {

        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern void llama_load_model_from_file(string path, LLamaModelParams @params);
        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern void llama_backend_init(bool numa = false);
        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr llama_new_context_with_model(LLamaModel model);
        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern int llama_n_ctx_train(LLamaModel model);
        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern int llama_n_ctx(IntPtr context);

        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern int llama_tokenize(LLamaModel model, string text, int textLength, [Out] LLamaToken[] tokens, int numberOfMaxTokens, bool addBos = false, bool special = true);
        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern int llama_token_to_piece(IntPtr context, int token);
        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern int llama_token_eos(LLamaModel model);

        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern void llama_free(IntPtr context);
        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern void llama_free_model(LLamaModel model);
        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern void llama_backend_free();

        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLamaContextParams llama_context_default_params();
        [DllImport("llama", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLamaModelParams llama_model_default_params();
    }
}
