namespace Client.Application.Models
{
    public class ActiveDownloadItemModel
    {
        public long Id { get; set; }
        public required string FileName { get; set; }
        public required DownloadQueue DownloadQueue { get; set; }
        public long Size { get; set; }
        public DownloadStatus DownloadStatus { get; set; }
        public long DownloadedBytes { get; set; }
        public CancellationTokenSource CancellationTokenSource { get; set; } = new CancellationTokenSource();
        public int? TaskId { get; set; }

    }
}
