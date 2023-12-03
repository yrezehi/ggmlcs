using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ggmlcs.Native.Libs.Platforms
{
    public static class WindowsLoader
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        public static void LibraryLoad(string libraryPath)
        {
            IntPtr libHandle = LoadLibrary(libraryPath);
            if (libHandle == IntPtr.Zero)
            {
                throw new ArgumentException($"Failed to load {libraryPath}");
            }
        }
    }
