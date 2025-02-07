namespace Client.Infrastructure.DbContexts.App;

public class FdmAppDbContextFactory : IDesignTimeDbContextFactory<FdmAppDbContext>
{
    public FdmAppDbContext CreateDbContext(string[] args = null)
    {
        // Define the database path
        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "FDM");
        if (!Directory.Exists(dbPath))
        {
            Directory.CreateDirectory(dbPath);
        }

        // Create the SQLite connection string
        var connectionString = $"Data Source={Path.Combine(dbPath, "FDMdb.db")}";

        // Set up options for the DbContext
        var optionsBuilder = new DbContextOptionsBuilder<FdmAppDbContext>();
        optionsBuilder.UseSqlite(connectionString);

        return new FdmAppDbContext(optionsBuilder.Options);
    }
}
