

using Client.Infra.DbContexts;
using DevExpress.XtraWaitForm;
using Microsoft.EntityFrameworkCore;
using Serilog;

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
        services.RegisterForms();


        var serviceProvider = services.BuildServiceProvider();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        var mainForm = serviceProvider.GetRequiredService<Main>();
        Application.Run(mainForm);
    }
}
