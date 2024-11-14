

namespace Client.UI.Forms.DialogForms;

public partial class DownloadFileInfoDialogForm : MasterFixedDialogForm
{
    private readonly ILogger _logger;
    public DownloadFileInfoDialogForm(ILogger<DownloadFileInfoDialogForm> logger)
    {
        InitializeComponent();
        _logger = logger;
    }
}
