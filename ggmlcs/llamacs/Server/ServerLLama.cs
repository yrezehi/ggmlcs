using LLamacs.Native.Binding.Definitions.Context;
using LLamacs.Native.Binding.Definitions.Model;
using LLamacs.Native.Binding;
using LLamacs.Native.DLLs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LLamacs.Server.Clients;
using LLamacs.Native.Binding.Definitions.Batch;
using LLamacs.Native.Binding.Definitions.Slots;

namespace LLamacs.Server
{
    public class ServerLLama : ILLama<LLamaClient>
    {

        private LLamaContext Context { get; set; }
        private LLamaModel Model { get; set; }

        private LLamaContextParams ContextParams { get; set; } = new LLamaContextParams();
        private LLamaModelParams ModelParams { get; set; } = new LLamaModelParams();

        public LLamaBatch Batch { get; set; }

        public bool multimodal { get; set; } = false;
        public bool clean_kv_cache { get; set; } = true;
        public bool all_slots_are_idl { get; set; } = false;
        public bool add_bos_token { get; set; } = true;

        public int id_gen { get; set; }
        public int n_ctx { get; set; }
        public int n_ctx_slot { get; set; }
        public int n_parallel { get; set; } = 4;

        public bool system_need_update { get; set; }
        public string system_prompt { get; set; } = "";
        public List<LLamaToken> system_tokens { get; set; }

        public string name_user { get; set; }
        public string name_assistant { get; set; }

        List<LLamaClientSlot> ClientSlots { get; set; } = new List<LLamaClientSlot>();

        // TODO: List.TaskServer

        // TODO: List.TaskResult

        // TODO: List.multi

        // TODO: mutex.mutex_tasks

        // TODO: condition_variable.condition_tasks

        // TODO: mutex.mutex_results

        // TODO: condition_variable.condition_results

        private ServerLLama(LLamaContext context, LLamaModel model, LLamaContextParams contextParams, LLamaModelParams modelParams)
        {
            id_gen = 0;

            all_slots_are_idl = true;

            n_ctx_slot = n_ctx / n_parallel;

            for(int slotIndex = 0;  slotIndex < n_parallel; slotIndex++)
            {
                ClientSlots.Add(LLamaClientSlot.Create(slotIndex, n_ctx_slot));
            }

            Batch = LLamaMethodsHandler.BatchInit();

            (Context, Model, ContextParams, ModelParams) = (context, model, contextParams, modelParams);
        }

        public static ServerLLama CreateInstance(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }

            DLLLoader.LibraryLoad();

            LLamaMethodsHandler.BackendInit();

            LLamaModelParams modelParams = LLamaModelParams.Default();

            LLamaModel model = LLamaMethodsHandler.LoadModelFromFile(path, modelParams);

            LLamaContextParams contextParams = LLamaContextParams.Default();

            LLamaContext context = LLamaMethodsHandler.NewContextWithModel(model, contextParams);

            return new ServerLLama(context, model, contextParams, modelParams);
        }

        public void Infer(LLamaClient client)
        {

        }
    }
}
