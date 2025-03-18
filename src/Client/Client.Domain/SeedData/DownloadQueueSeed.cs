namespace Client.Domain.SeedData;

public static class DownloadQueueSeed
{
    public static IEnumerable<DownloadQueue> GetSeedData()
    {
        return new List<DownloadQueue>
        {
            new DownloadQueue { Id = 1, Title = DownloadQueueEnum.MainDownloadQueue },
        };
    }
}
