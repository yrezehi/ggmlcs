using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ggmlcs.Native.Libs
{
    public static class LibLoader
    {
        public static void LibraryLoad()
        {
            LibraryEnvironment libEnv = NativeHelper.GetNativeLibraryEnvironment;

            switch (libEnv.OperatingSystem)
            {
                case "win":
                    WindowsLoader.LibraryLoad(libEnv.LibraryPath);
                    break;
                case "linux":
                    LinuxLoader.LibraryLoad(libEnv.LibraryPath);
                    break;
                case "osx":
                    MacLoader.LibraryLoad(libEnv.LibraryPath);
                    break;
            }
        }
    }
}
