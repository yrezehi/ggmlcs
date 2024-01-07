namespace LLamacs
{
    public class LLamaParameters
    {
        public long Seed { get; set; } = -1;    // RNG seed
        public int NumberOfThreads { get; set; } = 8; // number of threads
        public int NumberOfthreadsForbatch { get; set; } = 8;    // number of threads to use for batch processing (-1 = use n_threads)
        public int TokensToPredict { get; set; } = -1;    // new tokens to predict
        public int ContextSize { get; set; } = 512;   // context size
        public int BatchSize { get; set; } = 512;   // batch size for prompt processing (must be >=32 to use BLAS)
        public string ModelPath { get; set; } = ""; // model path
        public string InputPrefix { get; set; } = "";  // string to prefix user inputs with
        public string InputSuffix { get; set; } = "";  // string to suffix user inputs with
        public List<string> Antiprompt { get; set; } = new List<string>(); // string upon seeing which more user input is prompted
    }
}
