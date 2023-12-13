using ggmlcs.Native.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ggmlcs.Native
{
    public class LLama
    {

        private LLamaContext Context { get; set; }

        public void Run(string prompt)
        {
            List<LLamaToken> embedding = LLamaMethods.llama_tokenize();
        }
    }
}
