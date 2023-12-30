using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGmlcs.Native.Binding.Definitions
{
    public enum GGmlBackendType
    {
        GGML_BACKEND_CPU = 0,
        GGML_BACKEND_GPU = 10,
        GGML_BACKEND_GPU_SPLIT = 20,
    }
}
