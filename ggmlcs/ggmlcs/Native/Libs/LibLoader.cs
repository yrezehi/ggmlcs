using ggmlcs.Native.Libs.Platforms;

namespace ggmlcs.Native.Libs
{
    public static class LibLoader
    {
        public static void LibraryLoad() =>
            WindowsLoader.LibraryLoad(Path.Combine(AppContext.BaseDirectory, "Native", "Runtimes", "windows", "llama.dll"));
    }
}
