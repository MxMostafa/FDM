﻿
using Client.Domain.Dtos.Response.AppSetting;
using Client.Domain.Interfaces.Services;
using Client.UI.Constants;
using Client.UI.Constants.Configs;
using Client.UI.Helpers;
using Client.UI.ViewModel;
using Microsoft.Extensions.Logging;

namespace Client.UI.Forms.DialogForms;
public partial class AppSettingDialogForm : MasterFixedDialogForm
{



    private readonly IAppSettingService _appSettingService;

    private readonly ILogger _logger;
    public AppSettingDialogForm(IAppSettingService appSettingService, ILogger<AppSettingDialogForm> logger)
    {
        InitializeComponent();
        xtraTabControl1.SelectedTabPageIndex = 0;
        _appSettingService = appSettingService;
        _logger = logger;
    }


    private async void AppSettingDialogForm_Load(object sender, EventArgs e)
    {
        try
        {

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
            data.Add(AdvancedSyncUsageCheckbox.Name,AdvancedSyncUsageCheckbox.Checked.ToString());
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
                    case var key when key ==  AppSettingConfigs.AutoDownloadConfig:
                        AutoDownloadClipboardLinksCheckbox.Checked = bool.Parse(setting.Value);
                        break;
                    case var key when key == AppSettingConfigs.AdvancedSyncUsageConfig:
                    AdvancedSyncUsageCheckbox.Checked=bool.Parse(setting.Value);
                        break;
                    case var key when key== AppSettingConfigs.LastPublicSaveDirectoryConfig:
                        LastPublicSaveDirectoryCheckBox.Checked=bool.Parse(setting.Value);
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
}
