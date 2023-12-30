using GGML.Native.Libs.Platforms;

namespace GGML.Native.Libs
{
    public static class LibLoader
    {
        public static void LibraryLoad() =>
            WindowsLoader.LibraryLoad(Path.Combine(AppContext.BaseDirectory, "Native", "Runtimes", "windows", "llama.dll"));
    }
}
