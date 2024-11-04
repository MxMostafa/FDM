



using System;
using System.Reflection;

namespace Client.Infra.DbContexts;

public class FdmDbContext : DbContext
{
    public DbSet<CategoryGroup> CategoryGroups { get; set; }
    public DbSet<CategoryItem> CategoryItems { get; set; }

    public FdmDbContext(DbContextOptions<FdmDbContext> options) : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
