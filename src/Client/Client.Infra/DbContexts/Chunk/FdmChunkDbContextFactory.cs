namespace Client.Infrastructure.DbContexts.Chunk;

public class FdmChunkDbContextFactory : IDesignTimeDbContextFactory<FdmChunkDbContext>
{
    public FdmChunkDbContext CreateDbContext(string[] args = null)
    {
        // Define the database path
        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "FDM");
        if (!Directory.Exists(dbPath))
        {
            Directory.CreateDirectory(dbPath);
        }

        // Create the SQLite connection string
        var connectionString = $"Data Source={Path.Combine(dbPath, "FDMChunkdb.db")}";

        // Set up options for the DbContext
        var optionsBuilder = new DbContextOptionsBuilder<FdmChunkDbContext>();
        optionsBuilder.UseSqlite(connectionString);

        return new FdmChunkDbContext(optionsBuilder.Options);
    }
}
