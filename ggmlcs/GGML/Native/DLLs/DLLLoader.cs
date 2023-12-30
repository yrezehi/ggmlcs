using GGML.Native.DLLs.Platforms;

namespace GGML.Native.DLLs
{
    public static class DLLLoader
    {
        public static void LibraryLoad() =>
            WindowsDLLLoader.LibraryLoad(Path.Combine(AppContext.BaseDirectory, "Native", "Runtimes", "windows", "llama.dll"));
    }
}
