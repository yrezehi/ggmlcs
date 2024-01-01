using LLamacs.Native.Binding;
using LLamacs.Native.Binding.Definitions.Batch;
using LLamacs.Native.Binding.Definitions.Context;
using LLamacs.Native.Binding.Definitions.LLava;
using LLamacs.Native.Binding.Definitions.Model;
using LLamacs.Native.Binding.Definitions.TokenData;
using LLamacs.Native.Binding.LLama;
using LLamacs.Native.Binding.LLava;
using LLamacs.Native.DLLs;
using System.Text;

// reference llama.cpp official: https://github.com/ggerganov/llama.cpp/blob/8a5be3bd5885d79ad84aadf32bb8c1a67bd43c19/examples/simple/simple.cpp#L42

namespace LLamacs.Local
{
    public class LLavaLLama
    {
        public const string IMAGE_BASE64_TAG_BEGIN = "<img src=\"data:image/jpeg;base64,";
        public const string IMAGE_BASE64_TAG_END = "\">";

        public LLavaLLama(string modelPath, string prompt, string clipPath)
        {
            // setup llava context
            LLamaClipCtx clipCtx = LLavaClipMethods.clip_model_load(clipPath);

            LLamaMethodsHandler.BackendInit();

            LLamaModelParams modelParams = LLamaModelParams.Default();

            LLamaModel llamaModel = LLamaMethodsHandler.LoadModelFromFile(modelPath, modelParams);

            LLamaContextParams contextParams = LLamaContextParams.Default();

            LLamaContext llamaContext = LLamaMethodsHandler.NewContextWithModel(llamaModel, contextParams);

            LLavaContext llavaContext = LLavaContext.Create(clipCtx, llamaContext, llamaModel);

            // load image
        }


        public LLavaImageEmbed LoadImage(LLavaContext lLavaContext)
        {
            LLavaImageEmbed imageEmbed = new LLavaImageEmbed();
        }

        public bool PromptContainsImage(string prompt)
        {
            int begin, end;
            FindImageTagInPrompt(prompt, begin, end);

            return (begin != -1);
        }

        public void FindImageTagInPrompt(string prompt, out int begin, out int end)
        {
            begin = prompt.IndexOf(IMAGE_BASE64_TAG_BEGIN);
            end = prompt.IndexOf(IMAGE_BASE64_TAG_END);
        }
    }
}
