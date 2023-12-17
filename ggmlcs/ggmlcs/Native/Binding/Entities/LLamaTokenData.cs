using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ggmlcs.Native.Binding.Entities
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LLamaTokenData
    {
        LLamaToken id; // token id
        float logit;    // log-odds of the token
        float p;        // probability of the token
    }
}
