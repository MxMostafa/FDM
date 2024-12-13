

namespace Client.Domain.Dtos.Request.DownloadFile
{
    public record AddFileToQueueReqDto(
             string FileName,
             int  downloadQueueId,
             string DownloadURL,
             string SavePath,
             long SizeInBytes,
             string? FileExtension,
        DownloadStatus DownloadStatus
        );

}
