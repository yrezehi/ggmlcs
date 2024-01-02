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

        public string grammar;
        public string cfg_negative_prompt;
        public float cfg_scale = 1f;
        public IDictionary<LLamaToken, float> logit_bias;

        public List<LLamaToken> penalty_prompt_tokens;
        public bool use_penalty_prompt_tokens = false;
    }
}
