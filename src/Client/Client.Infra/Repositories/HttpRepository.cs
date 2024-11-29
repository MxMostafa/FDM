
using Client.Domain.Dtos;
using Client.Domain.Dtos.Response.DownloadQueueItem;
using Client.Domain.Interfaces.General.Errors;
using Client.Infrastructure.Helpers;
using Newtonsoft.Json;
using System.Drawing;

namespace Client.Infrastructure.Repositories;

public class HttpRepository : IHttpRepository
{
    private readonly HttpClient _httpClient;
    private readonly IHttpErros _httpErrors;

    public HttpRepository(HttpClient httpClient, IHttpErros httpErrors)
    {
        _httpClient = httpClient;
        _httpErrors = httpErrors;
    }

  


    public async Task<ResultPattern<DownloadFileInfoResDto>> GetFileInfoAsync(string url)
    {
        using (var request = new HttpRequestMessage(HttpMethod.Head, url))
        {
            using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
            {
                if (!response.IsSuccessStatusCode)
                {
                    return new ResultPattern<DownloadFileInfoResDto>(_httpErrors.InvalidURL);
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
                    DownloadURL = url,
                    FileExtension = windowsMimeType?.Key,
                    MimeType = mimeType,
                    SizeInBytes = fileSize ?? 0,
                    Icon = icon
                };
            }
        }
    }
}
