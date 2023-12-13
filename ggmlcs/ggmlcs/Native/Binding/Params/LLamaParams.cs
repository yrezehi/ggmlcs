using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ggmlcs.Native.Binding.Structs
{
    public class LLamaParams
    {
        public int ContextSize { get; set; } = 512;
        public float RoPEFrequencyBase { get; set; } = 0.0f;
        public float RopeFrequencyScale { get; set; } = 0.0f;
        public long Seed { get; set; } = DateTime.Now.Ticks;
        public bool Numa { get; set; } = false;
    }
}
