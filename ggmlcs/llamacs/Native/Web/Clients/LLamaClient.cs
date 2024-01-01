using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Web.Clients
{
    public class LLamaClient
    {
        public int Id { get; set; } = 0;

        public LlamaSeqId SeqId { get; set; }
        public LLamaToken sampled { get; set; }

        public long TStartPrompt { get; set; } = -1;
        public long TStartGen { get; set; }

        public int NPrompt { get; set; } = 0;
        public int NDecoded { get; set; } = 0;
        public int IBatch { get; set; } = -1;

        public string Input { get; set; }
        public string prompt { get; set; }
        public string Response { get; set; }

        public static LLamaClient Create()
        {
            return new LLamaClient() {};
        }
    }
}
