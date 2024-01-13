using System.Text;

namespace Server.Assets
{
    public class AssetResult : IResult
    {
        private static string DEFAULT_INDEX_PAGE_NAME = "index";
        private static string ASSETS_FIELS_LOCATION = "Assets\\";

        private readonly string FileName;

        public AssetResult(string fileName) =>
            FileName = fileName.Trim();

        public Task ExecuteAsync(HttpContext httpContext)
        {
            httpContext.Response.ContentType = MapFileToMimetype(FileName);

            string content = MapPathToAsset(FileName);

            httpContext.Response.ContentLength = Encoding.UTF8.GetByteCount(content);

            return httpContext.Response.WriteAsync(content);
        }

        private string MapFileToMimetype(string fileName) =>
            new Dictionary<string, string>
                {
                    {"js", "text/javascript"},
                }[Path.GetExtension(fileName).TrimStart('.')];

        private string MapPathToAsset(string requestPath) =>
            LoadAsset(string.IsNullOrEmpty(requestPath) ? DEFAULT_INDEX_PAGE_NAME : requestPath);

        private string LoadAsset(string fileName)
        {
            string filePath = BuildAssetFilePath(fileName);

            if (!Path.Exists(filePath))
                filePath = BuildAssetFilePath(DEFAULT_INDEX_PAGE_NAME);

            return LoadAssetAsString(filePath);
        }

        private string LoadAssetAsString(string filePath)
        {
            using (var streamReader = new StreamReader(filePath))
            {
                return streamReader.ReadToEnd();
            }
        }

        private string BuildAssetFilePath(string fileName) =>
            Path.Combine(ASSETS_FIELS_LOCATION, fileName);
    }
}
