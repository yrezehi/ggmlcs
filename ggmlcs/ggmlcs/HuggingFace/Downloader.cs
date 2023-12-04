namespace ggmlcs.HuggingFace
{
    public class Downloader
    {
        private static readonly HttpClient HttpClient = new() { Timeout = Timeout.InfiniteTimeSpan };

        private static readonly string HUGGING_FACE_BASE_URL = "https://huggingface.co/";

        private static string BuildURL(string uri) =>
            HUGGING_FACE_BASE_URL + uri;

        private static async Task<Stream> Download(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, BuildURL(uri));
            var response = await HttpClient.SendAsync(request);

            return await response.Content.ReadAsStreamAsync();
        }
    }
}
