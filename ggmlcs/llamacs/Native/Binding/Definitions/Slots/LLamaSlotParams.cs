using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.Slots
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class LLamaSlotParams
    {
        public bool stream ;
        public bool cache_prompt;

        public uint seed;
        public int n_keep = 0;
        public int n_predict = -1;

        public List<string> antiprompt;

        public string input_prefix;
        public string input_suffix;

        public static LLamaSlotParams Default()
        {
            return new LLamaSlotParams() {
                stream = true,
                cache_prompt = false,
                seed = uint.MinValue,
                n_keep = 0,
                n_predict = -1,
                antiprompt = new List<string>(),
                input_prefix = "",
                input_suffix = ""
            };
        }
    }
}
