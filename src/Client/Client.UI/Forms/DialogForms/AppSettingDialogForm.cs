
using Client.Domain.Dtos.Response.AppSetting;
using Client.Domain.Interfaces.Services;
using Client.UI.Constants;
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
                    case "RunAppWhenWindowsStartCheckBox":
                        RunAppWhenWindowsStartCheckBox.Checked = bool.Parse(setting.Value);
                        break;
                    case "AutoDownloadClipboardLinksCheckbox":
                        AutoDownloadClipboardLinksCheckbox.Checked = bool.Parse(setting.Value);
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
