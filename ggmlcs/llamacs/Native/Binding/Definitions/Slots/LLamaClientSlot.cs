using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLamacs.Native.Binding.Definitions.Slots
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct LLamaClientSlot
    {
        public int id;
        public int task_id;

        public int n_ctx;
        public int n_past;
        public int n_decoded;
        public int n_remaining;
        public int i_batch;


        public static LLamaClientSlot Create(int id, int n_ctx_slot) =>
            new LLamaClientSlot()
            {
                id = id,
                n_ctx = n_ctx_slot,
                n_past = 0,
                n_decoded = 0,
                n_remaining = -1,
                i_batch = -1
    };

        /*
        struct slot_params params;

            slot_state state = IDLE;
            slot_command command = NONE;

            // used to determine the slot that has been used the longest
            int64_t t_last_used = -1;

            int32_t num_prompt_tokens           = 0;
            int32_t num_prompt_tokens_processed = 0;

            json prompt;
            std::string generated_text;
            llama_token sampled;
            std::vector<llama_token> cache_tokens;
            std::vector<completion_token_output> generated_token_probs;

            bool infill = false;
            bool embedding = false;
            bool has_next_token = true;
            bool truncated = false;
            bool stopped_eos = false;
            bool stopped_word = false;
            bool stopped_limit = false;

            bool oaicompat = false;
            std::string oaicompat_model;

            std::string stopping_word;

            // sampling
            struct llama_sampling_params sparams;
            llama_sampling_context *ctx_sampling = nullptr;

            // multimodal
            std::vector<slot_image> images;

            // stats
            size_t sent_count = 0;
            size_t sent_token_probs_index = 0;

            int64_t t_start_process_prompt;
            int64_t t_start_genereration;

            double t_prompt_processing; // ms
            double t_token_generation; // ms

            // multitasks
            int multitask_id = -1;

            void reset() {
                num_prompt_tokens      = 0;
                generated_text         = "";
                truncated              = false;
                stopped_eos            = false;
                stopped_word           = false;
                stopped_limit          = false;
                stopping_word          = "";
                n_past                 = 0;
                sent_count             = 0;
                sent_token_probs_index = 0;
                infill                 = false;

                generated_token_probs.clear();

                for (slot_image & img : images)
                {
                    free(img.image_embedding);
                    if (img.img_data) {
                        clip_image_u8_free(img.img_data);
                    }
                    img.prefix_prompt = "";
                }

                images.clear();
            }

            bool has_budget(gpt_params &global_params) {
                n_remaining = -1;
                if(params.n_predict != -1)
                {
                    n_remaining = params.n_predict - n_decoded;
                }
                else if (global_params.n_predict != -1)
                {
                    n_remaining = global_params.n_predict - n_decoded;
                }
                return n_remaining > 0 || n_remaining == -1; // no budget || limitless
            }

            bool available() const {
                return state == IDLE && command == NONE;
            }

            bool is_processing() const {
                return (state == IDLE && command == LOAD_PROMPT) || state == PROCESSING;
            }

            void add_token_string(const completion_token_output &token) {
                if (command == RELEASE)
                {
                    return;
                }
                cache_tokens.push_back(token.tok);
                generated_token_probs.push_back(token);
            }

            void release() {
                if (state == IDLE || state == PROCESSING)
                {
                    t_token_generation = (ggml_time_us() - t_start_genereration) / 1e3;
                    command = RELEASE;
                }
            }

            json get_formated_timings() {
                return json
                {
                    {"prompt_n",               num_prompt_tokens_processed},
                    {"prompt_ms",              t_prompt_processing},
                    {"prompt_per_token_ms",    t_prompt_processing / num_prompt_tokens_processed},
                    {"prompt_per_second",      1e3 / t_prompt_processing * num_prompt_tokens_processed},

                    {"predicted_n",            n_decoded},
                    {"predicted_ms",           t_token_generation},
                    {"predicted_per_token_ms", t_token_generation / n_decoded},
                    {"predicted_per_second",   1e3 / t_token_generation * n_decoded},
                };
            }

            void print_timings() const {
                LOG_TEE("\n");
                LOG_TEE("%s: prompt eval time = %10.2f ms / %5d tokens (%8.2f ms per token, %8.2f tokens per second)\n",
                    __func__, t_prompt_processing, num_prompt_tokens_processed, t_prompt_processing / num_prompt_tokens_processed, 1e3 / t_prompt_processing * num_prompt_tokens_processed);
                LOG_TEE("%s:        eval time = %10.2f ms / %5d runs   (%8.2f ms per token, %8.2f tokens per second)\n",
                    __func__, t_token_generation, n_decoded,t_token_generation / n_decoded, 1e3 / t_token_generation * n_decoded);
                LOG_TEE("%s:       total time = %10.2f ms\n", __func__, t_prompt_processing + t_token_generation);
            }
         */

    }
}
