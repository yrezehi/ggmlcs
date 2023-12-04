using ggmlcs.Native.Helpers;
using ggmlcs.Native.Libs.Platforms;

namespace ggmlcs.Native.Libs
{
    public static class LibLoader
    {
        public static void LibraryLoad()
        {
            WindowsLoader.LibraryLoad(NativeHelper.GetNativeLibraryEnvironment.LibraryPath);
        }
    }
}
