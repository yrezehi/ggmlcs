using LLamacs.Local;

namespace Experimental.Models
{
    // model ref https://huggingface.co/liuhaotian/llava-v1.5-7b/tree/main
    public static class LLavaLLamaRunner
    {
        public static void Run()
        {
            var instance = new LLavaLLama("C:\\llm_models\\llava-v1.5-7b-Q4_K.gguf", "", "C:\\llm_models\\llava-v1.5-7b\\mmproj-model-f16.gguf", "C:\\Users\\Administrator\\Downloads\\download.jpg");
        }
    }
}
