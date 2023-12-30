using System.Runtime.InteropServices;

namespace GGML.Native.DLLs.Platforms
{
    public static class WindowsDLLLoader
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
