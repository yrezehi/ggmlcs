using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.Kv
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public unsafe struct LLamaKVCacheView
    {
            public int n_cells;
            public int n_max_seq;
            public int token_count;
            public int used_cells;
            public int max_contiguous;
            public int max_contiguous_idx;
            public LLamaKvCacheViewCell* cells;
            public LlamaSeqId* cells_sequences;
    }
}
