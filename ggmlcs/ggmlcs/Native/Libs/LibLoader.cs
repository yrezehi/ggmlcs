using ggmlcs.Native.Libs.Platforms;
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
            WindowsLoader.LibraryLoad(NativeHelper.GetNativeLibraryEnvironment);
        }
    }
}
