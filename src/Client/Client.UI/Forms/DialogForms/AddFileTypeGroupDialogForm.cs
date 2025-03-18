using Client.UI.Constants;


namespace Client.UI.Forms.DialogForms;

public partial class AddFileTypeGroupDialogForm : MasterFixedDialogForm
{
    private readonly ILogger _logger;
    private readonly IAppSettingService _appSettingService;
    public AddFileTypeGroupDialogForm(ILogger<AddFileTypeGroupDialogForm> logger, IAppSettingService appSettingService)
    {
        InitializeComponent();
        _logger = logger;
        _appSettingService = appSettingService;
    }

    private async void mxActionGroup1_SaveButtonClick(object sender, EventArgs e)
    {
        try
        {
            //validation
            if (string.IsNullOrEmpty(groumNameTextbox.Text) || string.IsNullOrEmpty(ExtensionsTextbox.Text))
            {
                ErrorHelper.ShowErrorAsMessageBox(AppMessages.ValidationError);
                return;
            }

            if (!CommonHelper.GetConfirm(AppMessages.WarningConfirmMessage)) return;


            var request = await _appSettingService.AddFileTypeGroupAsync(new Domain.Dtos.Request.FileTypeGroup.AddFileTypeGroupReqDto()
            {
                Title = groumNameTextbox.Text,
                FileExtensions = ExtensionsTextbox.Text,
                SavePath =FileTypeGroupSavePathTextBox.Text
            }
            );

            if (!request.IsSucceed)
            {
                request.Throw();
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
    }

    private void ChangeSavePathButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (xtraFolderBrowserDialog1.ShowDialog() != DialogResult.OK) return;
            FileTypeGroupSavePathTextBox.Text = xtraFolderBrowserDialog1.SelectedPath;
        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
    }
}
