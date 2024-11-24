
using Client.Domain.Interfaces.Dto;
using Client.UI.Constants;
using Client.UI.UserControls.Common;

namespace Client.UI.Forms.DialogForms;

public partial class AddDownloadNewAddressDialogForm : MasterFixedDialogForm
{
    private readonly ILogger _logger;
    private readonly IDownloadFileService _downloadFileService;
    private readonly IServiceProvider _serviceProvider;
    public AddDownloadNewAddressDialogForm(ILogger<AddDownloadNewAddressDialogForm> logger, IDownloadFileService downloadFileService, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _logger = logger;
        ActiveControl = urlCombobox;
        _downloadFileService = downloadFileService;
        _serviceProvider = serviceProvider;
    }

    private void UseAuthorizationCheckBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void AddDownloadNewAddressDialogForm_Load(object sender, EventArgs e)
    {
        try
        {
            InsertUrlFromClipboardIfExist();
        }
        catch (Exception ex)
        {
            ex.Handle(_logger);
        }
    }


    private void InsertUrlFromClipboardIfExist()
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

    private void mxButton15_Click(object sender, EventArgs e)
    {
        InsertUrlFromClipboardIfExist();
    }

    private async void mxAcceptActionGroup1_ConfirmButtonClick(object sender, EventArgs e)
    {
        try
        {
            var url = string.Empty;
            if (urlCombobox.Properties.Items.Count > 0)
                url = urlCombobox.Properties.Items[0].ToString();

            if (string.IsNullOrEmpty(url))
            {
                ErrorHelper.ShowErrorAsMessageBox(AppMessages.UrlFormatValidationError);
                return;
            }

            ShowPleaseWait();
            //Disable Confirm Button
            mxAcceptActionGroup1.StartProcessingMode();

            var DownloadFileInfoRequest = await _downloadFileService.GetFileInfoAsync(url);

            HidePleaseWait();

            if (!DownloadFileInfoRequest.IsSucceed)
            {
                ErrorHelper.ShowErrorAsMessageBox(DownloadFileInfoRequest);
                return;
            }

            var downloadFileInfoDialogForm = _serviceProvider.GetRequiredService<DownloadFileInfoDialogForm>();

            downloadFileInfoDialogForm.SetDownloadFileInfo(DownloadFileInfoRequest.Data);

            

            if (downloadFileInfoDialogForm.ShowDialog() != DialogResult.OK)
                Close();

        }
        catch (Exception ex)
        {
            ex.Handle(_logger);
        }
        finally
        {
            HidePleaseWait();
            mxAcceptActionGroup1.EndProcessingMode();
        }
    }

    private void mxAcceptActionGroup1_Load(object sender, EventArgs e)
    {

    }
}
