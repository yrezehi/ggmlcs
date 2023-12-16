using ggmlcs.Native.Helpers;
using ggmlcs.Native.Libs.Platforms;

namespace ggmlcs.Native.Libs
{
    public static class LibLoader
    {
        public static void LibraryLoad()
        {
            WindowsLoader.LibraryLoad(new LibraryEnvironment
            {
                LibraryPath = Path.Combine(
                        AppContext.BaseDirectory,
                        "Native\\Runtimes",
                        $"win-generic",
                        $"llama.dll"),
                OperatingSystem = "generic"
            }.LibraryPath);
        }
    }
}
