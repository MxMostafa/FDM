




using Client.Domain.Entites;
using Client.Domain.Enums;
using Client.UI.Constants;
using Client.UI.ViewModel.FileTypeGroup;

namespace Client.UI.Forms.DialogForms;
public partial class AppSettingDialogForm : MasterFixedDialogForm
{



    private readonly IAppSettingService _appSettingService;

    private readonly ILogger _logger;
    private readonly IServiceProvider _serviceProvider;
    public AppSettingDialogForm(IAppSettingService appSettingService, ILogger<AppSettingDialogForm> logger, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        xtraTabControl1.SelectedTabPageIndex = 0;
        _appSettingService = appSettingService;
        _logger = logger;
        _serviceProvider = serviceProvider;
    }


    private async void AppSettingDialogForm_Load(object sender, EventArgs e)
    {
        try
        {
            await FillFileTypeGroupsAsync();
            var appSettingsRequest = await _appSettingService.GetGeneralAppSettingAsync();
            if (appSettingsRequest.IsSucceed == false)
            {
                appSettingsRequest.Handle();
                return;
            }

            ApplySettings(appSettingsRequest.Data);
            _logger.LogDebug("all setting loaded");



            siteInfoViewModelBindingSource.DataSource = new List<SiteInfoViewModel>()
                    {
            new SiteInfoViewModel() {Address="http:\\test.com",User="سبس",pass="1234" }
                     };
        }
        catch (Exception ex)
        {
            ex.Handle(_logger);
        }

    }

    private async Task FillFileTypeGroupsAsync()
    {
        try
        {
            ShowPleaseWait();
            var request = await _appSettingService.GetAllFileTypeGroupsAsync();
            if (!request.IsSucceed) request.Throw();

            fileTypeGroupViewModelBindingSource.DataSource = request.Data.Select(f => new FileTypeGroupViewModel()
            {
                Id = f.Id,
                Title = f.Title,
                FileExtensions = f.FileExtensions,
                IconName = f.IconName,
                SavePath = f.SavePath,
                FolderName = f.FolderName
            }).ToList();
        }
        catch (Exception ex)
        {
            HidePleaseWait();
            ex.Handle(_logger);
        }
        finally
        {
            HidePleaseWait();
        }

    }

    private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
    {
        if (e.Column.FieldName == "pass")
        {
            e.DisplayText = new string('*', e.Value?.ToString().Length ?? 0);
        }
    }

    private void ManulaProxySettingRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        ProxySettingPanel.Enabled = ManulaProxySettingRadioButton.Checked;
    }

    private async void mxActionGroup1_SaveButtonClick(object sender, EventArgs e)
    {
        try
        {
            if (!CommonHelper.GetConfirm(AppMessages.WarningConfirmMessage)) return;

            var data = new Dictionary<string, string>
            {
                { RunAppWhenWindowsStartCheckBox.Name, RunAppWhenWindowsStartCheckBox.Checked.ToString() },
                { AutoDownloadClipboardLinksCheckbox.Name, AutoDownloadClipboardLinksCheckbox.Checked.ToString() },
                { AdvancedSyncUsageCheckbox.Name, AdvancedSyncUsageCheckbox.Checked.ToString() },
                { LastPublicSaveDirectoryCheckBox.Name, LastPublicSaveDirectoryCheckBox.Checked.ToString() },
                { DownloadedFileServerDateCheckBox.Name, DownloadedFileServerDateCheckBox.Checked.ToString() },
                { DownloadStartWindowCheckBox.Name, DownloadStartWindowCheckBox.Checked.ToString() },
                { AddToQueueOnlyCheckBox.Name, AddToQueueOnlyCheckBox.Checked.ToString() },
                { DownloadEndDialogCheckBox.Name, DownloadEndDialogCheckBox.Checked.ToString() },
                { AutoStartAfterPromptCheckBox.Name, AutoStartAfterPromptCheckBox.Checked.ToString() },
                { ShowAddToDownloadQueuePanelCheckBox.Name, ShowAddToDownloadQueuePanelCheckBox.Checked.ToString() },
                { EnableQueuePanelOnGroupAddCheckBox.Name, EnableQueuePanelOnGroupAddCheckBox.Checked.ToString() },
                { SkipDateUpdateOnDownloadResumeCheckBox.Name, SkipDateUpdateOnDownloadResumeCheckBox.Checked.ToString() },
                { DisableProxySettingRadioButton.Name, DisableProxySettingRadioButton.Checked.ToString() },
                { WindowsProxySettingRadioButton.Name, WindowsProxySettingRadioButton.Checked.ToString() },
                { ManulaProxySettingRadioButton.Name, ManulaProxySettingRadioButton.Checked.ToString() },
                { SafariCheckBox.Name, SafariCheckBox.Checked.ToString() },
                { ChromeCheckBox.Name, ChromeCheckBox.Checked.ToString() },
                { IECheckBox.Name, IECheckBox.Checked.ToString() },
                { EdgCheckBox.Name, EdgCheckBox.Checked.ToString() },
                { EdgLegacyCheckBox.Name, EdgLegacyCheckBox.Checked.ToString() },
                { FireFoxCheckBox.Name, FireFoxCheckBox.Checked.ToString() },
                { OperaCheckBox.Name, OperaCheckBox.Checked.ToString() },
                {ParallelDownloadLimiTrackBarControl.Name, ParallelDownloadLimiTrackBarControl.Value.ToString() },
                {TempSavePathTextbox.Name, TempSavePathTextbox.Text }
            };
            await _appSettingService.AddGeneralAppSettingsAsync(data);

            Close();
        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
    }

    private void ApplySettings(List<AppSettingResDto> settings)
    {
        try
        {
            foreach (var setting in settings)
            {
                switch (setting.Key)
                {
                    case var key when key == AppSettingConfigs.RunWindowsStartConfig:
                        RunAppWhenWindowsStartCheckBox.Checked = bool.Parse(setting.Value);
                        break;
                    case var key when key == AppSettingConfigs.AutoDownloadConfig:
                        AutoDownloadClipboardLinksCheckbox.Checked = bool.Parse(setting.Value);
                        break;
                    case var key when key == AppSettingConfigs.AdvancedSyncUsageConfig:
                        AdvancedSyncUsageCheckbox.Checked = bool.Parse(setting.Value);
                        break;
                    case var key when key == AppSettingConfigs.LastPublicSaveDirectoryConfig:
                        LastPublicSaveDirectoryCheckBox.Checked = bool.Parse(setting.Value);
                        break;
                    case var key when key == AppSettingConfigs.DownloadedFileServerDateConfig:
                        DownloadedFileServerDateCheckBox.Checked = bool.Parse(setting.Value);
                        break;
                    case var key when key == AppSettingConfigs.DownloadStartWindowConfig:
                        DownloadStartWindowCheckBox.Checked = bool.Parse(setting.Value);
                        break;
                    case var key when key == AppSettingConfigs.AddToQueueOnlyConfig:
                        AddToQueueOnlyCheckBox.Checked = bool.Parse(setting.Value);
                        break;
                    case var key when key == AppSettingConfigs.DownloadEndDialogConfig:
                        DownloadEndDialogCheckBox.Checked = bool.Parse(setting.Value);
                        break;
                    case var key when key == AppSettingConfigs.AutoStartAfterPromptConfig:
                        AutoStartAfterPromptCheckBox.Checked = bool.Parse(setting.Value);
                        break;
                    case var key when key == AppSettingConfigs.ShowAddToDownloadQueuePanelConfig:
                        ShowAddToDownloadQueuePanelCheckBox.Checked = bool.Parse(setting.Value);
                        break;
                    case var key when key == AppSettingConfigs.EnableQueuePanelOnGroupAddConfig:
                        EnableQueuePanelOnGroupAddCheckBox.Checked = bool.Parse(setting.Value);
                        break;
                    case var key when key == AppSettingConfigs.SkipDateUpdateOnDownloadResumeConfig:
                        SkipDateUpdateOnDownloadResumeCheckBox.Checked = bool.Parse(setting.Value);
                        break;
                    case var key when key == AppSettingConfigs.DisableProxySettingConfig:
                        DisableProxySettingRadioButton.Checked = bool.Parse(setting.Value);
                        break;
                    case var key when key == AppSettingConfigs.WindowsProxySettingConfig:
                        WindowsProxySettingRadioButton.Checked = bool.Parse(setting.Value);
                        break;
                    case var key when key == AppSettingConfigs.ManulaProxySettingConfig:
                        ManulaProxySettingRadioButton.Checked = bool.Parse(setting.Value);
                        break;
                    case var key when key == AppSettingConfigs.SafariConfig:
                        SafariCheckBox.Checked = bool.Parse(setting.Value);
                        break;
                    case var key when key == AppSettingConfigs.ChromeConfig:
                        ChromeCheckBox.Checked = bool.Parse(setting.Value);
                        break;
                    case var key when key == AppSettingConfigs.IEConfig:
                        IECheckBox.Checked = bool.Parse(setting.Value);
                        break;
                    case var key when key == AppSettingConfigs.EdgConfig:
                        EdgCheckBox.Checked = bool.Parse(setting.Value);
                        break;
                    case var key when key == AppSettingConfigs.EdgLegacyConfig:
                        EdgLegacyCheckBox.Checked = bool.Parse(setting.Value);
                        break;
                    case var key when key == AppSettingConfigs.FireFoxConfig:
                        FireFoxCheckBox.Checked = bool.Parse(setting.Value);
                        break;
                    case var key when key == AppSettingConfigs.OperaConfig:
                        OperaCheckBox.Checked = bool.Parse(setting.Value);
                        break;
                    case var key when key == AppSettingConfigs.ParallelDownloadLimit:
                        ParallelDownloadLimiTrackBarControl.Value = int.Parse(setting.Value);
                        break;
                    case var key when key == AppSettingConfigs.TempSavePath:
                        TempSavePathTextbox.Text = setting.Value;
                        break;
                    default:
                        break;
                }
            }

        }
        catch (Exception ex)
        {
            ex.Handle(_logger);
        }
    }

    private async void AddFileTypeGroupButton_Click(object sender, EventArgs e)
    {
        try
        {
            var addFileTypeGroupDialogForm = _serviceProvider.GetRequiredService<AddFileTypeGroupDialogForm>();

            if (addFileTypeGroupDialogForm.ShowDialog() == DialogResult.OK)
                await FillFileTypeGroupsAsync();

        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
    }

    private async void EditFileTypeGroupButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (!(FileTypeGroupComboBox.EditValue is int selected)) return;

            var addFileTypeGroupDialogForm = _serviceProvider.GetRequiredService<EditFileTypeGroupDialogForm>();

            addFileTypeGroupDialogForm.FileTypeGroupId = selected;
            if (addFileTypeGroupDialogForm.ShowDialog() == DialogResult.OK)
                await FillFileTypeGroupsAsync();

        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
    }

    private async void FileTypeGroupComboBox_Properties_SelectionChanged(object sender, DevExpress.XtraEditors.Controls.PopupSelectionChangedEventArgs e)
    {
        try
        {
            if (!(FileTypeGroupComboBox.EditValue is int selected)) return;
            var fileTypeGroupRequest = await _appSettingService.GetFileTypeGroupByIdAsync(selected);
            if (fileTypeGroupRequest.IsSucceed)
            {
                FileTypeGroupSavePathTextbox.Text = fileTypeGroupRequest.Data.SavePath;
            }
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
            TempSavePathTextbox.Text = xtraFolderBrowserDialog1.SelectedPath;
        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
    }
}
