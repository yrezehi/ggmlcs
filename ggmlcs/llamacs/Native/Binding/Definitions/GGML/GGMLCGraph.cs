using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.GGML
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct GGMLCGraph
    {
        public int size;
        public int n_nodes;
        public int n_leafs;

        public GGMLTensor** nodes;
        public GGMLTensor** grads;
        public GGMLTensor** leafs;

        public GGMLHashSet visited_hash_table;

        public GGMLCGraphEvalOrder order;

        // performance
        public int perf_runs;
        public long perf_cycles;
        public long perf_time_us;
    }
}
