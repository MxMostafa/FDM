



using Client.Domain.Entites;
using Client.UI.ViewModel.FileTypeGroup;
using System.ComponentModel;
using System.IO;

namespace Client.UI.Forms.DialogForms;

public partial class DownloadFileInfoDialogForm : MasterFixedDialogForm
{
    private readonly ILogger _logger;
    private readonly IAppSettingService _appSettingService;
    private readonly IServiceProvider _serviceProvider;
    //Property Injection or Method Injection
    private DownloadFileInfoResDto _downloadFileInfo;

    public DownloadFileInfoDialogForm(ILogger<DownloadFileInfoDialogForm> logger, IAppSettingService appSettingService, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _logger = logger;
        _appSettingService = appSettingService;
        _serviceProvider = serviceProvider;
    }

    // Property injection (you can use this in the form)
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

    // Property injection (you can use this in the form)
    public DownloadFileInfoResDto DownloadFileInfo
    {
        get { return _downloadFileInfo; }
        set
        {
            _downloadFileInfo = value;
            UpdateUIWithFileInfo();
        }
    }

    // Method injection (an alternative to property injection)
    public void SetDownloadFileInfo(DownloadFileInfoResDto fileInfo)
    {
        _downloadFileInfo = fileInfo;
        UpdateUIWithFileInfo();
    }

    private void UpdateUIWithFileInfo()
    {
        if (_downloadFileInfo != null)
        {
            var viewModel = new DownloadFileInfoViewModel()
            {
                FileExtension = _downloadFileInfo.FileExtension,
                Icon = _downloadFileInfo.Icon,
                MimeType = _downloadFileInfo.MimeType,
                Size = FormatHelper.ConvertBytes(_downloadFileInfo.SizeInBytes),
                DownloadURL = _downloadFileInfo.DownloadURL
            };

            fileTypeImage.Image = viewModel.Icon.ToBitmap();
            FileSizeLabel.Text = viewModel.Size;
            downloadURLTextbox.Text = viewModel.DownloadURL;
        }
    }

    private async void DownloadFileInfoDialogForm_Load(object sender, EventArgs e)
    {
        try
        {

            await FillFileTypeGroupsAsync();

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

            var downloadFileInfoTypeRequest = await _appSettingService.GetByFileExtensionAsync(_downloadFileInfo.FileExtension);
            if (downloadFileInfoTypeRequest.IsSucceed)
            {

                FileTypeGroupComboBox.EditValue = downloadFileInfoTypeRequest.Data.Id;
                FileTypeGroupSavePathTextBox.Text = downloadFileInfoTypeRequest.Data.SavePath;
            }

        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }

    }

    private async void mxButton15_Click(object sender, EventArgs e)
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

    private void ChangeSavePathButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (Path.Exists(FileTypeGroupSavePathTextBox.Text))
                xtraFolderBrowserDialog1.SelectedPath = FileTypeGroupSavePathTextBox.Text;

            if (xtraFolderBrowserDialog1.ShowDialog() != DialogResult.OK) return;
            FileTypeGroupSavePathTextBox.Text = xtraFolderBrowserDialog1.SelectedPath;
        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
    }
}
