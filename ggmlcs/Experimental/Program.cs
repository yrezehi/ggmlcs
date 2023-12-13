using ggmlcs;
using ggmlcs.Models;
try
{
    Model model = Model.FromPath("C:\\Users\\Administrator\\Documents\\Projects\\ggmlcs\\ggmlcs\\llama.cpp\\models\\7B\\ggml-model-q4_0.bin");
    Runner runner = model.CreateRunner();
    var res = runner.WithPrompt(" what is your name young man? ").Infer(out _, nTokensToPredict: 50);
    Console.Write(res);
    model.Dispose();
}
catch (Exception e) { }