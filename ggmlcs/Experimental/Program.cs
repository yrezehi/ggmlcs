using ggmlcs.Native;

var instance = LLama.CreateInstance("C:\\llm_models\\llama-2-7b-guanaco-qlora.Q5_K_S.gguf");

instance.Infer("Hello my name is!");