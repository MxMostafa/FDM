using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Client.Persistence.Configurations;

public class DownloadFileConfiguration : IEntityTypeConfiguration<DownloadFile>
{
    public void Configure(EntityTypeBuilder<DownloadFile> builder)
    {

    }
}
