namespace Client.Infrastructure.DbContexts.File;

public class FdmFileDbContextFactory : IDesignTimeDbContextFactory<FdmFileDbContext>
{
    public FdmFileDbContext CreateDbContext(string[] args = null)
    {
        // Define the database path
        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "FDM");
        if (!Directory.Exists(dbPath))
        {
            Directory.CreateDirectory(dbPath);
        }

        // Create the SQLite connection string
        var connectionString = $"Data Source={Path.Combine(dbPath, "FDMFiledb.db")}";

        // Set up options for the DbContext
        var optionsBuilder = new DbContextOptionsBuilder<FdmFileDbContext>();
        optionsBuilder.UseSqlite(connectionString);

        return new FdmFileDbContext(optionsBuilder.Options);
    }
}
