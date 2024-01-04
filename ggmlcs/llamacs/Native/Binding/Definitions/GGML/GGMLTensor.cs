using System;
using System.Runtime.InteropServices;

namespace LLamacs.Native.Binding.Definitions.GGML
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct GGMLTensor
    {
        public GGMLType type;
        public GGMLBackendType backend;

        public GGMLBackendBuffer* buffer;

        public long[] ne;
        public IntPtr[] nb;

        public GGMLOP op;

        public int[] op_params;

        public bool is_param;

        public GGMLTensor* grad;
        public GGMLTensor[] src;

        // performance
        public int perf_runs;
        public long perf_cycles;
        public long perf_time_us;

        public GGMLTensor* view_src;
        public IntPtr view_offs;

        public void* data;

        public char[] name;

        public void* extra;

        public char[] padding;
    }
}
