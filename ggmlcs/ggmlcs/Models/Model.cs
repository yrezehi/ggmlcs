using ggmlcs.Native.Libs;
using ggmlcs.Native;
using System.Runtime.InteropServices;
using ggmlcs.Native.Tokenizers;

namespace ggmlcs.Models
{
    public class Model
    {
        public Lazy<IntPtr> ctx;
        private bool isDisposed = false;
        private bool isFromFile = false;
        private bool isFromBytes = false;
        private Tokenizer Tokenizer;
        private BinConfiguration Configuration;

        private Model(IntPtr context)
        {
            this.ctx = new Lazy<IntPtr>(() => context);
        }

        public void Create(string modelPath)
        {
            using FileStream fileStream = new FileStream(modelPath, FileMode.Open, FileAccess.Read);
            byte[] inBytes = new byte[Marshal.SizeOf(typeof(BinConfiguration))];

            if (fileStream.Read(inBytes, 0, inBytes.Length) != inBytes.Length)
            {
                throw new ArgumentException("Failed to ready the configuration!");
            }

            GCHandle handleGC = GCHandle.Alloc(inBytes, GCHandleType.Pinned);

            BinConfiguration configurationInstance;

            try
            {
                configurationInstance = (BinConfiguration)Marshal.PtrToStructure(handleGC.AddrOfPinnedObject(), typeof(BinConfiguration));
            }
            finally { handleGC.Free(); }

            Tokenizer = Tokenizer.Create(Configuration.vocab_size).Load();
            LibLoader.LibraryLoad();
        }

        /// <summary>
        /// Creates a new LLaMAModelFactory from a model path.
        /// </summary>
        /// <param name="modelPath">The path to the model.</param>
        public static Model FromPath(string modelPath)
        {
            LibLoader.LibraryLoad();

            return new Model(
                LLaMANativeMethods.llama_init_from_file(
                    modelPath,
                    LLaMANativeMethods.llama_context_default_params()
                )
            );
        }

        /// <summary>
        /// Creates a LLaMARunner for this model.
        /// </summary>
        /// <returns>A new LLaMARunner.</returns>
        public Runner CreateRunner()
        {
            return new Runner(this);
        }

        public void Dispose()
        {
            // If already disposed, do nothing.
            if (isDisposed)
            {
                return;
            }

            // Dispose of unmanaged resources.
            if (ctx.IsValueCreated && ctx.Value != IntPtr.Zero)
            {
                LLaMANativeMethods.llama_free(ctx.Value);
            }

            isDisposed = true;
        }
    }
}