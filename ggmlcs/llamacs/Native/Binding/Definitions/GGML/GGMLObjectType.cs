using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.GGML
{
    public enum GGMLObjectType
    {
        GGML_OBJECT_TENSOR,
        GGML_OBJECT_GRAPH,
        GGML_OBJECT_WORK_BUFFER
    }
}
