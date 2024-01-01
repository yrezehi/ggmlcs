using System.Runtime.InteropServices;

namespace LLamacs.Native.Binding.Definitions.KvOverride
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct LLamaSamplingParams
    {
        /*
            int32_t     n_prev                = 64;       // number of previous tokens to remember
            int32_t     n_probs               = 0;        // if greater than 0, output the probabilities of top n_probs tokens.
            int32_t     top_k                 = 40;       // <= 0 to use vocab size
            float       top_p                 = 0.95f;    // 1.0 = disabled
            float       min_p                 = 0.05f;    // 0.0 = disabled
            float       tfs_z                 = 1.00f;    // 1.0 = disabled
            float       typical_p             = 1.00f;    // 1.0 = disabled
            float       temp                  = 0.80f;    // 1.0 = disabled
            int32_t     penalty_last_n        = 64;       // last n tokens to penalize (0 = disable penalty, -1 = context size)
            float       penalty_repeat        = 1.10f;    // 1.0 = disabled
            float       penalty_freq          = 0.00f;    // 0.0 = disabled
            float       penalty_present       = 0.00f;    // 0.0 = disabled
            int32_t     mirostat              = 0;        // 0 = disabled, 1 = mirostat, 2 = mirostat 2.0
            float       mirostat_tau          = 5.00f;    // target entropy
            float       mirostat_eta          = 0.10f;    // learning rate
            bool        penalize_nl           = true;     // consider newlines as a repeatable token
            std::string samplers_sequence     = "kfypmt"; // top_k, tail_free, typical_p, top_p, min_p, temp

            std::string grammar;  // optional BNF-like grammar to constrain sampling

            // Classifier-Free Guidance
            // https://arxiv.org/abs/2306.17806
            std::string cfg_negative_prompt; // string to help guidance
            float       cfg_scale     = 1.f; // how strong is guidance

            std::unordered_map<llama_token, float> logit_bias; // logit bias for specific tokens

            std::vector<llama_token> penalty_prompt_tokens;
            bool                     use_penalty_prompt_tokens = false;
         */
    }
}
