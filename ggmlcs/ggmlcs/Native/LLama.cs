using ggmlcs.Native.Binding;
using ggmlcs.Native.Binding.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if(embeddings.Length > LLamaContextParams.n_ctx){
                throw new MemberAccessException(message: "Embedding tokens is larger than allowed context!");
            }

            int n_past = 0;
            int n_remain = 512; // TODO: need att
            int n_consumed = 0;
            int n_session_consumed = 0;
            int n_past_guidance = 0;
            int guidance_offset = 0;

            while (n_remain != 0)
            {
                for(int index = 0; index < embeddings.Length; index += LLamaContextParams.n_batch)
                {
                    int n_eval = embeddings.Length - index;

                    if(n_eval)
                }
            }

        }
    }
}
