using System.Runtime.InteropServices;

namespace LLamacs.Native.Binding.Definitions.TokenData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LLamaTokenData
    {
        public LLamaToken id;  // token id
        public float logit;    // log-odds of the token
        public float p;        // probability of the token

        public LLamaTokenData(LLamaToken id, float logit, float p)
        {
            this.id = id;
            this.logit = logit;
            this.p = p;
        }
    }
}
