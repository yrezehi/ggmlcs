using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.Kv
{
    public class LLamaKVCacheView
    {
        /*
            // Number of KV cache cells. This will be the same as the context size.
            int32_t n_cells;

            // Maximum number of sequences that can exist in a cell. It's not an error
            // if there are more sequences in a cell than this value, however they will
            // not be visible in the view cells_sequences.
            int32_t n_max_seq;

            // Number of tokens in the cache. For example, if there are two populated
            // cells, the first with 1 sequence id in it and the second with 2 sequence
            // ids then you'll have 3 tokens.
            int32_t token_count;

            // Number of populated cache cells.
            int32_t used_cells;

            // Maximum contiguous empty slots in the cache.
            int32_t max_contiguous;

            // Index to the start of the max_contiguous slot range. Can be negative
            // when cache is full.
            int32_t max_contiguous_idx;

            // Information for an individual cell.
            struct llama_kv_cache_view_cell * cells;

            // The sequences for each cell. There will be n_max_seq items per cell.
            llama_seq_id * cells_sequences;
         */
    }
}
