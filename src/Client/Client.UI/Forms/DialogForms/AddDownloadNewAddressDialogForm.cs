
using Client.UI.Constants;

namespace Client.UI.Forms.DialogForms;

public partial class AddDownloadNewAddressDialogForm : MasterFixedDialogForm
{
    private readonly ILogger _logger;
    private readonly IDownloadFileService _downloadFileService;
    public AddDownloadNewAddressDialogForm(ILogger<AddDownloadNewAddressDialogForm> logger, IDownloadFileService downloadFileService)
    {
        InitializeComponent();
        _logger = logger;
        ActiveControl = urlCombobox;
        _downloadFileService = downloadFileService;
    }

    private void UseAuthorizationCheckBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void AddDownloadNewAddressDialogForm_Load(object sender, EventArgs e)
    {
        try
        {
            var clipBoardURL = Clipboard.GetText();

            if (!string.IsNullOrEmpty(clipBoardURL) && FormatHelper.IsUrl(clipBoardURL))
                AddURLToCombo(clipBoardURL);
        }
        catch (Exception ex)
        {
            ex.Handle(_logger);
        }
    }


    private void AddURLToCombo(string url)
    {
        try
        {
            urlCombobox.Properties.Items.Add(url);
            if (urlCombobox.Properties.Items.Count > 0)
                urlCombobox.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            ex.Handle(_logger);
        }
    }

    private async void mxConfirmButton1_Click(object sender, EventArgs e)
    {
        try
        {
            var url = urlCombobox.SelectedText;
            if (string.IsNullOrEmpty(url))
            {
                ErrorHelper.ShowErrorAsMessageBox(AppMessages.WarningConfirmMessage);
                return;
            }

            var file = await _downloadFileService.GetFileInfoAsync(url);
        }
        catch (Exception ex)
        {
            ex.Handle(_logger);
        }
    }
}
