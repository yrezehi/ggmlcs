using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.GGUF
{
    public enum GGUFType
    {
        GGUF_TYPE_UINT8 = 0,
        GGUF_TYPE_INT8 = 1,
        GGUF_TYPE_UINT16 = 2,
        GGUF_TYPE_INT16 = 3,
        GGUF_TYPE_UINT32 = 4,
        GGUF_TYPE_INT32 = 5,
        GGUF_TYPE_FLOAT32 = 6,
        GGUF_TYPE_BOOL = 7,
        GGUF_TYPE_STRING = 8,
        GGUF_TYPE_ARRAY = 9,
        GGUF_TYPE_UINT64 = 10,
        GGUF_TYPE_INT64 = 11,
        GGUF_TYPE_FLOAT64 = 12,
        GGUF_TYPE_COUNT,
    }
}
