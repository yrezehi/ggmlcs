using GGML.Native;

var instance = LLama.CreateInstance("C:\\llm_models\\llama-2-7b-guanaco-qlora.Q2_K.gguf");

instance.Infer("Hello my name is");