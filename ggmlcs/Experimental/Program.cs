using LLamacs.Local;

var instance = LLavaLLama.CreateInstance("C:\\llm_models\\tinyllama-1.1b-chat-v1.0.Q2_K.gguf");

instance.Infer("Hello my name is");