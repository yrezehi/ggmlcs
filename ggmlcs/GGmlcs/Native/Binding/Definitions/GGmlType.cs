using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGmlcs.Native.Binding.Definitions
{
    public enum GGmlType
    {
        GGML_TYPE_F32  = 0,
        GGML_TYPE_F16  = 1,
        GGML_TYPE_Q4_0 = 2,
        GGML_TYPE_Q4_1 = 3,
        GGML_TYPE_Q5_0 = 6,
        GGML_TYPE_Q5_1 = 7,
        GGML_TYPE_Q8_0 = 8,
        GGML_TYPE_Q8_1 = 9,
        GGML_TYPE_Q2_K = 10,
        GGML_TYPE_Q3_K = 11,
        GGML_TYPE_Q4_K = 12,
        GGML_TYPE_Q5_K = 13,
        GGML_TYPE_Q6_K = 14,
        GGML_TYPE_Q8_K = 15,

        GGML_TYPE_I8,
        GGML_TYPE_I16,
        GGML_TYPE_I32,
        GGML_TYPE_COUNT,
    }
}
