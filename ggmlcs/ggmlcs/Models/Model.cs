using ggmlcs.Native.Libs;
using ggmlcs.Native;

namespace ggmlcs.Models
{
    public class Model
    {
        public Lazy<IntPtr> ctx;
        private bool isDisposed = false;
        private bool isFromFile = false;
        private bool isFromBytes = false;

        private Model(IntPtr context)
        {
            this.ctx = new Lazy<IntPtr>(() => context);
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