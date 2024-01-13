using System.Runtime.InteropServices;

namespace LLamacs.Native.Binding.Definitions.Sampling
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct LLamaSamplingContext
    {
        /*
            llama_sampling_params params;

            // mirostat sampler state
            float mirostat_mu;

            llama_grammar * grammar;

            // internal
            grammar_parser::parse_state parsed_grammar;

            // TODO: replace with ring-buffer
            std::vector<llama_token>      prev;
            std::vector<llama_token_data> cur;
         */
    }
}
