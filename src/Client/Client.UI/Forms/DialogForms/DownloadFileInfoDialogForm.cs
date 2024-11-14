

using Client.Domain.Dtos.Response.DownloadQueueItem;
using Client.UI.ViewModel.Download;

namespace Client.UI.Forms.DialogForms;

public partial class DownloadFileInfoDialogForm : MasterFixedDialogForm
{
    private readonly ILogger _logger;

    //Property Injection or Method Injection
    private DownloadFileInfoResDto _downloadFileInfo;

    public DownloadFileInfoDialogForm(ILogger<DownloadFileInfoDialogForm> logger)
    {
        InitializeComponent();
        _logger = logger;
    }

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
                Size = FormatHelper.ConvertBytes(_downloadFileInfo.SizeInBytes)
            };

            fileTypeImage.Image = viewModel.Icon.ToBitmap();
            FileSizeLabel.Text = viewModel.Size;
        }
    }


}
