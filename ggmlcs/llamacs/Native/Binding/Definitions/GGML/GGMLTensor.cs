using System;
using System.Runtime.InteropServices;

namespace LLamacs.Native.Binding.Definitions.GGML
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct GGMLTensor
    {
        public GGMLType type;
        public GGMLBackendType backend;

        struct ggml_backend_buffer* buffer;

        int64_t ne[GGML_MAX_DIMS]; // number of elements
        size_t nb[GGML_MAX_DIMS]; // stride in bytes:
                                  // nb[0] = ggml_type_size(type)
                                  // nb[1] = nb[0]   * (ne[0] / ggml_blck_size(type)) + padding
                                  // nb[i] = nb[i-1] * ne[i-1]

        // compute data
        enum ggml_op op;

        // op params - allocated as int32_t for alignment
        int32_t op_params[GGML_MAX_OP_PARAMS / sizeof(int32_t)];

        bool is_param;

        struct ggml_tensor * grad;
        struct ggml_tensor * src[GGML_MAX_SRC];

        // performance
        int perf_runs;
        int64_t perf_cycles;
        int64_t perf_time_us;

        struct ggml_tensor * view_src;
        size_t view_offs;

        void* data;

        char name[GGML_MAX_NAME];

        void* extra; // extra things e.g. for ggml-cuda.cu

        char padding[8];
    }
}
