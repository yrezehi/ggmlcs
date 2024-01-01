using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.GPT
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public unsafe struct GPTParams
    {
        /*
            uint32_t seed                           = -1;    // RNG seed
            int32_t n_threads                       = get_num_physical_cores();
            int32_t n_threads_batch                 = -1;    // number of threads to use for batch processing (-1 = use n_threads)
            int32_t n_predict                       = -1;    // new tokens to predict
            int32_t n_ctx                           = 512;   // context size
            int32_t n_batch                         = 512;   // batch size for prompt processing (must be >=32 to use BLAS)
            int32_t n_keep                          = 0;     // number of tokens to keep from initial prompt
            int32_t n_draft                         = 8;     // number of tokens to draft during speculative decoding
            int32_t n_chunks                        = -1;    // max number of chunks to process (-1 = unlimited)
            int32_t n_parallel                      = 1;     // number of parallel sequences to decode
            int32_t n_sequences                     = 1;     // number of sequences to decode
            float   p_accept                        = 0.5f;  // speculative decoding accept probability
            float   p_split                         = 0.1f;  // speculative decoding split probability
            int32_t n_gpu_layers                    = -1;    // number of layers to store in VRAM (-1 - use default)
            int32_t n_gpu_layers_draft              = -1;    // number of layers to store in VRAM for the draft model (-1 - use default)
            int32_t main_gpu                        = 0;     // the GPU that is used for scratch and small tensors
            float   tensor_split[LLAMA_MAX_DEVICES] = {0};   // how split tensors should be distributed across GPUs
            int32_t n_beams                         = 0;     // if non-zero then use beam search of given width.
            float   rope_freq_base                  = 0.0f;  // RoPE base frequency
            float   rope_freq_scale                 = 0.0f;  // RoPE frequency scaling factor
            float   yarn_ext_factor                 = -1.0f; // YaRN extrapolation mix factor
            float   yarn_attn_factor                = 1.0f;  // YaRN magnitude scaling factor
            float   yarn_beta_fast                  = 32.0f; // YaRN low correction dim
            float   yarn_beta_slow                  = 1.0f;  // YaRN high correction dim
            int32_t yarn_orig_ctx                   = 0;     // YaRN original context length
            int8_t  rope_scaling_type               = LLAMA_ROPE_SCALING_UNSPECIFIED; // TODO: better to be int32_t for alignment
            struct llama_sampling_params sparams; // sampling parameters
            std::string model             = "models/7B/ggml-model-f16.gguf"; // model path
            std::string model_draft       = "";                              // draft model for speculative decoding
            std::string model_alias       = "unknown"; // model alias
            std::string prompt            = "";
            std::string prompt_file       = "";  // store the external prompt file name
            std::string path_prompt_cache = "";  // path to file for saving/loading prompt eval state
            std::string input_prefix      = "";  // string to prefix user inputs with
            std::string input_suffix      = "";  // string to suffix user inputs with
            std::vector<std::string> antiprompt; // string upon seeing which more user input is prompted
            std::string logdir            = "";  // directory in which to save YAML log files
            std::vector<llama_model_kv_override> kv_overrides;
            // TODO: avoid tuple, use struct
            std::vector<std::tuple<std::string, float>> lora_adapter; // lora adapter path with user defined scale
            std::string lora_base  = "";                              // base model path for the lora adapter
            int  ppl_stride        = 0;     // stride for perplexity calculations. If left at 0, the pre-existing approach will be used.
            int  ppl_output_type   = 0;     // = 0 -> ppl output is as usual, = 1 -> ppl output is num_tokens, ppl, one per line
            bool   hellaswag       = false; // compute HellaSwag score over random tasks from datafile supplied in prompt
            size_t hellaswag_tasks = 400;   // number of tasks to use when computing the HellaSwag score
            bool mul_mat_q         = true;  // if true, use mul_mat_q kernels instead of cuBLAS
            bool random_prompt     = false; // do not randomize prompt if none provided
            bool use_color         = false; // use color to distinguish generations and inputs
            bool interactive       = false; // interactive mode
            bool chatml            = false; // chatml mode (used for models trained on chatml syntax)
            bool prompt_cache_all  = false; // save user input and generations to prompt cache
            bool prompt_cache_ro   = false; // open the prompt cache read-only and do not update it
            bool embedding         = false; // get only sentence embedding
            bool escape            = false; // escape "\n", "\r", "\t", "\'", "\"", and "\\"
            bool interactive_first = false; // wait for user input immediately
            bool multiline_input   = false; // reverse the usage of `\`
            bool simple_io         = false; // improves compatibility with subprocesses and limited consoles
            bool cont_batching     = false; // insert new sequences for decoding on-the-fly
            bool input_prefix_bos  = false; // prefix BOS to user inputs, preceding input_prefix
            bool ignore_eos        = false; // ignore generated EOS tokens
            bool instruct          = false; // instruction mode (used for Alpaca models)
            bool logits_all        = false; // return logits for all tokens in the batch
            bool use_mmap          = true;  // use mmap for faster loads
            bool use_mlock         = false; // use mlock to keep model in memory
            bool numa              = false; // attempt optimizations that help on some NUMA systems
            bool verbose_prompt    = false; // print prompt tokens before generation
            bool infill            = false; // use infill mode
            bool dump_kv_cache     = false; // dump the KV cache contents for debugging purposes
            bool no_kv_offload     = false; // disable KV offloading
            std::string cache_type_k = "f16"; // KV cache data type for the K
            std::string cache_type_v = "f16"; // KV cache data type for the V
            std::string mmproj = ""; // path to multimodal projector
            std::string image  = ""; // path to an image file
         */
    }
}
