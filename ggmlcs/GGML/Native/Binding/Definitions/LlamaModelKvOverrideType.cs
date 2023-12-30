using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGML.Native.Binding.Definitions
{
    public enum LlamaModelKvOverrideType
    {
        LLAMA_KV_OVERRIDE_INT = 0,
        LLAMA_KV_OVERRIDE_FLOAT = 1,
        LLAMA_KV_OVERRIDE_BOOL = 2,
    }
}
