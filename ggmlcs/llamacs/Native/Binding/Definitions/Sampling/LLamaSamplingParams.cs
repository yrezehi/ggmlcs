using System.Runtime.InteropServices;

namespace LLamacs.Native.Binding.Definitions.Sampling
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct LLamaSamplingParams
    {
        public int n_prev;
        public int n_probs;
        public int top_k;
        public float top_p;
        public float min_p;
        public float tfs_z;
        public float typical_p;
        public float temp;
        public int penalty_last_n;
        public float penalty_repeat;
        public float penalty_freq;
        public float penalty_present;
        public int mirostat;
        public float mirostat_tau;
        public float mirostat_eta;
        public bool penalize_nl;
        public string samplers_sequence;

        public string grammar;
        public string cfg_negative_prompt;
        public float cfg_scale;
        public IDictionary<LLamaToken, float> logit_bias;

        public List<LLamaToken> penalty_prompt_tokens;
        public bool use_penalty_prompt_tokens;

        public static LLamaSamplingParams Default() =>
            new LLamaSamplingParams() {
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
                cfg_scale = 1f,
                use_penalty_prompt_tokens = false
            };
    }
}
