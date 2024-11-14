



using Client.Domain.Helpers;

namespace Client.Domain.Services;

public class DownloadFileService : IDownloadFileService
{
    private readonly HttpClient _httpClient;

    public DownloadFileService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ResultPattern<DownloadFileInfoResDto>> GetFileInfoAsync(string url)
    {
        using (var request = new HttpRequestMessage(HttpMethod.Head, url))
        {
            using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Failed to retrieve file headers.");
                }

                // Retrieve content headers
                var contentHeaders = response.Content.Headers;

                // Get file size (Content-Length)
                long? fileSize = contentHeaders.ContentLength;

                // Get MIME type
                string? mimeType = contentHeaders.ContentType?.MediaType;

                //TODO: should read from server
                var allMimeTypes = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("Resources\\MimeTypes.json"));

                var windowsMimeType = allMimeTypes?.FirstOrDefault(m => m.Value == mimeType);

                Icon? icon = null;
                if (windowsMimeType != null)
                    icon = MimeTypeHelper.GetIconForExtension($".{windowsMimeType.Value.Key}");


                return new DownloadFileInfoResDto()
                {
                    FileExtension = windowsMimeType?.Key,
                    MimeType = mimeType,
                    SizeInBytes = fileSize ?? 0,
                    Icon = icon
                };
            }
        }
    }
}
