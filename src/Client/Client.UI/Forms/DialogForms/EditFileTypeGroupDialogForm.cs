using Client.Domain.Dtos.Request.FileTypeGroup;
using Client.Domain.Entites;
using Client.UI.Constants;
using System;


namespace Client.UI.Forms.DialogForms;

public partial class EditFileTypeGroupDialogForm : MasterFixedDialogForm
{
    private readonly ILogger _logger;
    private readonly IAppSettingService _appSettingService;
    public int FileTypeGroupId { get; set; }
    public EditFileTypeGroupDialogForm(ILogger<AddFileTypeGroupDialogForm> logger, IAppSettingService appSettingService)
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


            var request = await _appSettingService.UpdateFileTypeGroupAsync(new UpdateFileTypeGroupReqDto()
            {
                Id = FileTypeGroupId,
                Title = groumNameTextbox.Text,
                FileExtensions = ExtensionsTextbox.Text,
                SavePath = FileTypeGroupSavePathTextBox.Text,
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

    private async void EditFileTypeGroupDialogForm_Load(object sender, EventArgs e)
    {
        try
        {
            var fileTypeGroupRequest = await _appSettingService.GetFileTypeGroupByIdAsync(FileTypeGroupId);
            if (!fileTypeGroupRequest.IsSucceed)
            {
                fileTypeGroupRequest.Throw();
            }
            groumNameTextbox.Text = fileTypeGroupRequest.Data.Title;
            ExtensionsTextbox.Text = fileTypeGroupRequest.Data.FileExtensions;
            FileTypeGroupSavePathTextBox.Text = fileTypeGroupRequest.Data.SavePath;
        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
    }

    private async void DeleteFileTypeGroupButton_Click(object sender, EventArgs e)
    {
        try
        {
            var fileTypeGroupRequest = await _appSettingService.GetFileTypeGroupByIdAsync(FileTypeGroupId);
            if (!fileTypeGroupRequest.IsSucceed)
            {
                fileTypeGroupRequest.Throw();
            }

            if (!CommonHelper.GetConfirm(AppMessages.WarningConfirmMessage)) return;

            await _appSettingService.DeleteFileTypeGroupAsync(FileTypeGroupId);
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
