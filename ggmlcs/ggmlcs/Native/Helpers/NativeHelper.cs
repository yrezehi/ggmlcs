using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ggmlcs.Native.Helpers
{
    public struct LibraryEnvironment
    {
        public string LibraryPath { get; set; }
        public string OperatingSystem { get; set; }
    }

    public static class NativeHelper
    {
        public const string LLAMA_DLL = "libllama";

        public static LibraryEnvironment GetNativeLibraryEnvironment
        {
            get
            {
                // Temporary placeholder
                var filename = "llama";
                var os = "generic";
                var arch = "generic";
                var ext = "";

                // Get OS strings
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    os = "win";
                    ext = ".dll";
                }

                // Get architecture string
                if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                {
                    arch = "x64";
                }

                // Return the path
                return new LibraryEnvironment
                {
                    LibraryPath = Path.Combine(
                        AppContext.BaseDirectory,
                        "runtimes",
                        $"{os}-{arch}",
                        $"{filename}{ext}"),
                    OperatingSystem = os
                };
            }
        }
    }
}