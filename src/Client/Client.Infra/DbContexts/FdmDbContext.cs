using Client.Domain.Entites.Base;
using Client.Domain.SeedData;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Linq.Expressions;

namespace Client.Infrastructure.DbContexts;
public class FdmDbContext : DbContext
{
    public DbSet<CategoryGroup> CategoryGroups { get; set; }
    public DbSet<CategoryItem> CategoryItems { get; set; }
    public DbSet<DownloadQueue> DownloadQueues { get; set; }
    public DbSet<AppSetting> AppSettings { get; set; }
    public DbSet<FileTypeGroup> FileTypeGroups { get; set; }
    public DbSet<DownloadFile> DownloadFiles { get; set; }
    public DbSet<DownloadFileChunk> DownloadFileChunks { get; set; }
    public FdmDbContext(DbContextOptions<FdmDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

        // Apply global filter for entities that implement ISoftDeletableEntity
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(ISoftDeletableEntity).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var filter = Expression.Lambda(
                    Expression.Equal(
                        Expression.Property(parameter, nameof(ISoftDeletableEntity.IsDeleted)),
                        Expression.Constant(false)
                    ),
                    parameter
                );

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
            }
        }


        // Apply seed data from external classes
        modelBuilder.Entity<FileTypeGroup>().HasData(FileTypeGroupSeed.GetSeedData());
        modelBuilder.Entity<DownloadQueue>().HasData(DownloadQueueSeed.GetSeedData());
        modelBuilder.Entity<AppSetting>().HasData(AppSettingSeed.GetSeedData());
        
}
}
