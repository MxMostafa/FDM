

namespace Client.Infrastructure.DbContexts;

public class FdmDbContextFactory : IDesignTimeDbContextFactory<FdmDbContext>
{
    public FdmDbContext CreateDbContext(string[] args = null)
    {
        // Define the database path
        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "PDM");
        if (!Directory.Exists(dbPath))
        {
            Directory.CreateDirectory(dbPath);
        }

        // Create the SQLite connection string
        var connectionString = $"Data Source={Path.Combine(dbPath, "FDMdb.db")}";

        // Set up options for the DbContext
        var optionsBuilder = new DbContextOptionsBuilder<FdmDbContext>();
        optionsBuilder.UseSqlite(connectionString);

        return new FdmDbContext(optionsBuilder.Options);
    }
}
