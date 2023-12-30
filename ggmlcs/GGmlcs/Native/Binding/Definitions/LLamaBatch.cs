using System;
using System.Runtime.InteropServices;

namespace GGmlcs.Native.Binding.Definitions
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct GPT2HParams
    {
        public int n_vocab;
        public int n_ctx;
        public int n_embd;
        public int n_head;
        public int n_layer;
        public int ftype;
        public float eps;

        public static GPT2HParams Default() =>
            new GPT2HParams () {
                n_vocab = 50257,
                n_ctx = 1024,
                n_embd = 768,
                n_head = 12,
                n_layer = 12,
                ftype = 1,
                eps = 1e-5f
            };
    }
}
