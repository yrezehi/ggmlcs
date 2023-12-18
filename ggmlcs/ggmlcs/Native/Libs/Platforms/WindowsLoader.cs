using System.Runtime.InteropServices;

namespace ggmlcs.Native.Libs.Platforms
{
    public static class WindowsLoader
    {
        public static void LibraryLoad(string libraryPath)
        {
            NativeLibrary.TryLoad(libraryPath, out var handler);

            if (handler == IntPtr.Zero)
            {
                throw new ArgumentException($"Failed to load {libraryPath}");
            }
        }
    }
}
