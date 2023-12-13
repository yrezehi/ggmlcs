using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ggmlcs.Native.Constants
{
    public class LLamaConstants
    {
        const int LLAMA_ROPE_SCALING_UNSPECIFIED = -1;
        const uint LLAMA_DEFAULT_SEED = 0xFFFFFFFF;
        const int GGML_DEFAULT_N_THREADS = 4;
        const int GGML_TYPE_F16 = 1;
    }
}
