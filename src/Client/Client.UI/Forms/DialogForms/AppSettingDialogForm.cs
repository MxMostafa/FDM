
using Client.Domain.Dtos.Response.AppSetting;
using Client.Domain.Interfaces.Services;
using Client.Domain.Services;
using Client.UI.Constants;
using Client.UI.Constants.Configs;
using Client.UI.Helpers;
using Client.UI.ViewModel;
using Client.UI.ViewModel.FileTypeGroup;
using DevExpress.XtraSpreadsheet.Model;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

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

            await LoadAllGroupNameAsync();



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

            var data = new Dictionary<string, string>();
            data.Add(RunAppWhenWindowsStartCheckBox.Name, RunAppWhenWindowsStartCheckBox.Checked.ToString());
            data.Add(AutoDownloadClipboardLinksCheckbox.Name, AutoDownloadClipboardLinksCheckbox.Checked.ToString());
            data.Add(AdvancedSyncUsageCheckbox.Name, AdvancedSyncUsageCheckbox.Checked.ToString());
            data.Add(LastPublicSaveDirectoryCheckBox.Name, LastPublicSaveDirectoryCheckBox.Checked.ToString());
            data.Add(DownloadedFileServerDateCheckBox.Name, DownloadedFileServerDateCheckBox.Checked.ToString());
            data.Add(DownloadStartWindowCheckBox.Name, DownloadStartWindowCheckBox.Checked.ToString());
            data.Add(AddToQueueOnlyCheckBox.Name, AddToQueueOnlyCheckBox.Checked.ToString());
            data.Add(DownloadEndDialogCheckBox.Name, DownloadEndDialogCheckBox.Checked.ToString());
            data.Add(AutoStartAfterPromptCheckBox.Name, AutoStartAfterPromptCheckBox.Checked.ToString());
            data.Add(ShowAddToDownloadQueuePanelCheckBox.Name, ShowAddToDownloadQueuePanelCheckBox.Checked.ToString());
            data.Add(EnableQueuePanelOnGroupAddCheckBox.Name, EnableQueuePanelOnGroupAddCheckBox.Checked.ToString());
            data.Add(SkipDateUpdateOnDownloadResumeCheckBox.Name, SkipDateUpdateOnDownloadResumeCheckBox.Checked.ToString());
            data.Add(DisableProxySettingRadioButton.Name, DisableProxySettingRadioButton.Checked.ToString());
            data.Add(WindowsProxySettingRadioButton.Name, WindowsProxySettingRadioButton.Checked.ToString());
            data.Add(ManulaProxySettingRadioButton.Name, ManulaProxySettingRadioButton.Checked.ToString());
            data.Add(SafariCheckBox.Name, SafariCheckBox.Checked.ToString());
            data.Add(ChromeCheckBox.Name, ChromeCheckBox.Checked.ToString());
            data.Add(IECheckBox.Name, IECheckBox.Checked.ToString());
            data.Add(EdgCheckBox.Name, EdgCheckBox.Checked.ToString());
            data.Add(EdgLegacyCheckBox.Name, EdgLegacyCheckBox.Checked.ToString());
            data.Add(FireFoxCheckBox.Name, FireFoxCheckBox.Checked.ToString());
            data.Add(OperaCheckBox.Name, OperaCheckBox.Checked.ToString());
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

    private async void mxButton8_Click(object sender, EventArgs e)
    {
        try
        {
            var addFileTypeGroupDialogForm = _serviceProvider.GetRequiredService<AddFileTypeGroupDialogForm>();

            if (addFileTypeGroupDialogForm.ShowDialog() != DialogResult.OK)
                Close();

            var result = await _appSettingService.AddFileGroupAsync(addFileTypeGroupDialogForm.Title, addFileTypeGroupDialogForm.suffixName);


            if (result.IsSucceed)
            {
                await LoadAllGroupNameAsync();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage);
            }


        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
    }

    private async Task LoadAllGroupNameAsync()
    {
        try
        {
            var result = await _appSettingService.GetAllFileTypeGroupsAsync();
            List<FileTypeGroupViewModel> temp = new List<FileTypeGroupViewModel>();
            if (result.IsSucceed)
            {
                foreach (var item in result.Data)
                {
                    temp.Add(new FileTypeGroupViewModel()
                    {
                        Id = item.Id,
                        Title = item.Title,
                        FileExtensions = item.FileExtensions,
                        IconName = item.IconName
                    });
                }
            }

            fileTypeGroupViewModelBindingSource.DataSource = temp;

        }
        catch (Exception)
        {

            throw;
        }
    }

    private async void mxButton9_Click(object sender, EventArgs e)
    {
        try
        {
            
            var addFileTypeGroupDialogForm = _serviceProvider.GetRequiredService<EditFileTypeGroupDialogForm>();

            if (addFileTypeGroupDialogForm.ShowDialog() != DialogResult.OK)
                Close();

           var selected= FileTypeGroupComboBox.EditValue;
            if (Convert.ToInt32(selected) > 0)
            {

            }
           

            //var result = await _appSettingService.AddFileGroupAsync(addFileTypeGroupDialogForm.Title, addFileTypeGroupDialogForm.suffixName);


            //if (result.IsSucceed)
            //{
            //    await LoadAllGroupNameAsync();
            //}
            //else
            //{
            //    MessageBox.Show(result.ErrorMessage);
            //}


        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
    }
}
