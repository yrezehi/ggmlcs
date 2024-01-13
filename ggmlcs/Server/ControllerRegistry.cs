using System.Reflection;

namespace Server
{
    public static class ControllerRegistry
    {

        public static void RegisterControllers(this WebApplication application)
        {
            application.Index();
        }

        private static void Index(this WebApplication application) =>
            application.MapGet("/", () => "");

        private static void IndexJS(this WebApplication application) =>
            application.MapGet("/", () => "");

        private static void completionJS(this WebApplication application) =>
            application.MapGet("/", () => "");

        private static void JsonSchemaToGrammarMJS(this WebApplication application) =>
            application.MapGet("/", () => "");

        private static void Props(this WebApplication application) =>
            application.MapGet("/", () => "");

        private static void Completion(this WebApplication application) =>
            application.MapGet("/", () => "");

        private static void Models(this WebApplication application) =>
            application.MapGet("/", () => "");

        private static void ChatCompletions(this WebApplication application) =>
            application.MapGet("/", () => "");

        private static void Infill(this WebApplication application) =>
            application.MapGet("/", () => "");

        private static void ModelJson(this WebApplication application) =>
            application.MapGet("/", () => "");

        private static void Tokenize(this WebApplication application) =>
            application.MapGet("/", () => "");

        private static void Detokenize(this WebApplication application) =>
            application.MapGet("/", () => ""); 

        private static void Embedding(this WebApplication application) =>
            application.MapGet("/", () => ""); 
    }
}
