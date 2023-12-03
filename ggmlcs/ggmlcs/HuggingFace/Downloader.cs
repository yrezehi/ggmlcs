using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ggmlcs.HuggingFace
{
    public class Downloader
    {
        private static readonly HttpClient HttpClient = new() { Timeout = Timeout.InfiniteTimeSpan };

        private static readonly string HUGGING_FACE_BASE_URL = "https://huggingface.co/";

        private static string BuildURL(string uri) =>
            HUGGING_FACE_BASE_URL + uri;
    }
}
