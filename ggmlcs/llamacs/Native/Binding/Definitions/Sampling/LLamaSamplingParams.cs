using System.Runtime.InteropServices;

namespace LLamacs.Native.Binding.Definitions.Sampling
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct LLamaSamplingParams
    {
        public int n_prev = 64;
        public int n_probs = 0;
        public int top_k = 40;
        public float top_p = 0.95f;
        public float min_p = 0.05f;
        public float tfs_z = 1.00f;
        public float typical_p = 1.00f;
        public float temp = 0.80f;
        public int penalty_last_n = 64;
        public float penalty_repeat = 1.10f;
        public float penalty_freq = 0.00f;
        public float penalty_present = 0.00f;
        public int mirostat = 0;
        public float mirostat_tau = 5.00f;
        public float mirostat_eta = 0.10f;
        public bool penalize_nl = true;
        public string samplers_sequence = "kfypmt";
        /*
            std::string grammar;  // optional BNF-like grammar to constrain sampling

            // Classifier-Free Guidance
            // https://arxiv.org/abs/2306.17806
            std::string cfg_negative_prompt; // string to help guidance
            float       cfg_scale     = 1.f; // how strong is guidance

            std::unordered_map<llama_token, float> logit_bias; // logit bias for specific tokens

            std::vector<llama_token> penalty_prompt_tokens;
            bool                     use_penalty_prompt_tokens = false;
         */

        public static LLamaSamplingParams Default() =>
            new LLamaSamplingParams () {
                n_prev = 64,
                n_probs = 0,
                top_k = 40,
                top_p = 0.95f,
                min_p = 0.05f,
                tfs_z = 1.00f,
                typical_p = 1.00f,
                temp = 0.80f,
                penalty_last_n = 64,
                penalty_repeat = 1.10f,
                penalty_freq = 0.00f,
                penalty_present = 0.00f,
                mirostat = 0,
                mirostat_tau = 5.00f,
                mirostat_eta = 0.10f,
                penalize_nl = true,
                samplers_sequence = "kfypmt",
            };
    }
}
