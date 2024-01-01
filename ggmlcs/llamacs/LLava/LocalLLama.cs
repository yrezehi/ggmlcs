using LLamacs.Native.Binding;
using LLamacs.Native.Binding.Definitions.Batch;
using LLamacs.Native.Binding.Definitions.Context;
using LLamacs.Native.Binding.Definitions.Model;
using LLamacs.Native.Binding.Definitions.TokenData;
using LLamacs.Native.DLLs;
using System.Text;

// reference llama.cpp official: https://github.com/ggerganov/llama.cpp/blob/8a5be3bd5885d79ad84aadf32bb8c1a67bd43c19/examples/simple/simple.cpp#L42

namespace LLamacs.Local
{
    public unsafe class LLavaLLama : ILLama<string>
    {
        public void Infer(string prompt)
        {
            
        }
    }
}
