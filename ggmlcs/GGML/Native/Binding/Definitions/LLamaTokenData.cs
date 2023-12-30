using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GGML.Native.Binding.Definitions
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
