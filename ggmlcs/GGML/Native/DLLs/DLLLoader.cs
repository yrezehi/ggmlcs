using GGML.Native.DLLs.Platforms;

namespace GGML.Native.DLLs
{
    public static class DLLLoader
    {
        public static void LibraryLoad() =>
            WindowsDLLLoader.LibraryLoad(Path.Combine(AppContext.BaseDirectory, "Native", "DLLs", "Runtimes", "windows", "llama.dll"));
    }
}
