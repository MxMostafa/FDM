



namespace Client.UI.Forms.MasterForms;

public partial class MasterDockForm : Form
{
    protected readonly ILogger _logger;

    public MasterDockForm(ILogger logger)
    {
        InitializeComponent();
        _logger = logger;
    }
    protected void LogInformation(string message)
    {
        _logger?.LogInformation(message);
    }

    protected void LogError(Exception ex, string message)
    {
        _logger?.LogError(ex, message);
    }
}
