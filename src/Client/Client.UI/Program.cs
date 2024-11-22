

using Client.Persistence.DbContexts;
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
        services.AddMappings();
        services.RegisterForms();
       
        

        // تنظیمات برنامه و اجرای فرم اصلی
        var serviceProvider = services.BuildServiceProvider();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        WindowsFormsSettings.TrackWindowsAppMode = DevExpress.Utils.DefaultBoolean.True;
        var mainForm = serviceProvider.GetRequiredService<Main>();
        Application.Run(mainForm);
    }

    private static void HandleException(Exception ex)
    {
        if (ex != null)
        {
            // لاگ استثنا با استفاده از Serilog
            Log.Error(ex, "An unhandled exception occurred");

            // نمایش پیام به کاربر
            MessageBox.Show("An unexpected error occurred. Please check the log file for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
