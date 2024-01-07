using LLamacs.Native.DLLs.Platforms;

namespace LLamacs.Native.DLLs
{
    public static class DLLLoader
    {
        public const string LLAMA_DLL_NAME = "llama.dll";
        public const string LLAVA_DLL_NAME = "llava_shared.dll";

        public static void LibraryLoad()
        {
            WindowsDLLLoader.LibraryLoad(Path.Combine(AppContext.BaseDirectory, "Native", "DLLs", "Runtimes", "windows", LLAVA_DLL_NAME));

            WindowsDLLLoader.LibraryLoad(Path.Combine(AppContext.BaseDirectory, "Native", "DLLs", "Runtimes", "windows", LLAMA_DLL_NAME));
        }
    }
}
