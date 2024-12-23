using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Persistence.Configurations;

public class DownloadFileConfiguration : IEntityTypeConfiguration<DownloadFile>
{
    public void Configure(EntityTypeBuilder<DownloadFile> builder)
    {

        builder.HasOne(c => c.DownloadQueue)
            .WithMany()
            .HasForeignKey(c => c.DownloadQueueId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.FileTypeGroup)
         .WithMany()
         .HasForeignKey(c => c.FileTypeGroupId)
         .OnDelete(DeleteBehavior.Restrict);
    }
}
