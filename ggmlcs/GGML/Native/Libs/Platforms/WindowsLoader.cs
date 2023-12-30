using System.Runtime.InteropServices;

namespace GGML.Native.Libs.Platforms
{
    public static class WindowsLoader
    {
        public static void LibraryLoad(string libraryPath)
        {
            NativeLibrary.TryLoad(libraryPath, out var handler);

            if (handler == LLamaModel.Zero)
            {
                throw new ArgumentException($"Failed to load {libraryPath}");
            }
        }
    }
}
