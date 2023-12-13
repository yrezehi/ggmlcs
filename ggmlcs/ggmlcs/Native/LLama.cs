using ggmlcs.Native.Binding;
using ggmlcs.Native.Binding.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// commit 70f806b

namespace ggmlcs.Native
{
    public class LLama
    {
        private LLamaContext Context { get; }
        private LLamaModel Model { get; }

        private LLamaContextParams LLamaContextParams { get; } = new LLamaContextParams();

        public void Run(string prompt)
        {

            if (string.IsNullOrEmpty(prompt)) {
                throw new ArgumentException(message: "No prompt was provided!");
            }

            var embeddings = new LLamaToken[prompt.Length + 1];
            LLamaMethods.llama_tokenize(Model, prompt, prompt.Length, embeddings, embeddings.Length);

            if(embeddings.Length == 0) {
                throw new MemberAccessException(message: "Embedding tokens were empty!");
            }

            if(embeddings.Length > LLamaContextParams.n_ctx - 4){
                throw new MemberAccessException(message: "Embedding tokens is larger than allowed context!");
            }

        }
    }
}
