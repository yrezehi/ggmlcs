using LLamacs.Local;

namespace Experimental.Models
{
    // model ref https://huggingface.co/liuhaotian/llava-v1.5-7b/tree/main
    public static class LLavaLLamaRunner
    {
        public static void Run()
        {
            var instance = new LLavaLLama("c:/llm_models/LLava/ggml-model-q4_k.gguf", "", "c:/llm_models/LLava/mmproj-model-f16.gguf", "c:/Users/Administrator/Downloads/download.jpg");
        }
    }
}
