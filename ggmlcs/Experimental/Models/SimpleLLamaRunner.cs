﻿using LLamacs.LLamas;

namespace Experimental.Models
{
    public static class SimpleLLamaRunner
    {
        public static void Run()
        {
            var instance = SimpleLLama.CreateInstance("C:\\llm_models\\tinyllama-1.1b-chat-v1.0.Q2_K.gguf");

            var result = instance.Infer("Hello!");

            Console.Write(result);
        }
    }
}
