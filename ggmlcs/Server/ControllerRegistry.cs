using System.Reflection;

namespace Server
{
    public static class ControllerRegistry
    {

        public static void RegisterControllers(this WebApplication application)
        {
            application.Index();
            application.IndexJS();
            application.CompletionJS();
            application.JsonSchemaToGrammarMJS();
            application.Props();
            application.Completion();
            application.Models();
            application.ChatCompletions();
            application.Infill();
            application.ModelJson();
            application.Tokenize();
            application.Detokenize();
            application.Embedding();
        }

        private static void Index(this WebApplication application) =>
            application.MapGet("/", () => "");

        private static void IndexJS(this WebApplication application) =>
            application.MapGet("/index.js", () => "");

        private static void CompletionJS(this WebApplication application) =>
            application.MapGet("/completion.js", () => "");

        private static void JsonSchemaToGrammarMJS(this WebApplication application) =>
            application.MapGet("/json-schema-to-grammar.mjs", () => "");

        private static void Props(this WebApplication application) =>
            application.MapGet("/props", () => "");

        private static void Completion(this WebApplication application) =>
            application.MapGet("/completion", () => "");

        private static void Models(this WebApplication application) =>
            application.MapGet("/v1/models", () => "");

        private static void ChatCompletions(this WebApplication application) =>
            application.MapGet("/v1/chat/completions", () => "");

        private static void Infill(this WebApplication application) =>
            application.MapGet("/infill", () => "");

        private static void ModelJson(this WebApplication application) =>
            application.MapGet("/model.json", () => "");

        private static void Tokenize(this WebApplication application) =>
            application.MapGet("/tokenize", () => "");

        private static void Detokenize(this WebApplication application) =>
            application.MapGet("/detokenize", () => ""); 

        private static void Embedding(this WebApplication application) =>
            application.MapGet("/embedding", () => ""); 
    }
}
