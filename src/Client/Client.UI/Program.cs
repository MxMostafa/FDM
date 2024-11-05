

using Client.Infra.DbContexts;
using DevExpress.XtraWaitForm;
using Microsoft.EntityFrameworkCore;

namespace Client.UI;

internal static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {

        // Setup the service collection
        var services = new ServiceCollection();
        services.Configuration();
        services.AddSingleton<Main>();

        var serviceProvider = services.BuildServiceProvider();

        // Ensure the database is created and migrations are applied
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<FdmDbContext>();
            context.Database.Migrate(); // Applies any pending migrations
        }

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        var mainForm = serviceProvider.GetRequiredService<Main>();
        Application.Run(mainForm);
    }
}
