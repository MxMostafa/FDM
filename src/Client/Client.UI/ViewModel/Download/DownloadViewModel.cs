

using Client.Domain.Enums;

namespace Client.UI.ViewModel.Download;

public class DownloadViewModel : INotifyPropertyChanged
{
    [DisplayName("ردیف")]
    public int Row { get; set; }

    public long Id { get; set; }
    [DisplayName("نام  فایل")]
    public string FileName { get; set; }
    [DisplayName("آیکن")]
    public Icon? FileIcon { get; set; } = null;
    [DisplayName("صف")]
    public string DownloadQueue { get; set; }


    [DisplayName("اندازه")]
    public string DisplaySize => FormatHelper.ConvertBytes(Size);
    public long Size { get; set; }

    [DisplayName("دانلود شده")]
    public string DisplayDownloadedBytes => FormatHelper.ConvertBytes(DownloadedBytes);
    public long DownloadedBytes { get; set; }


    private string _status;
    [DisplayName("وضعیت")]
    public string Status
    {
        get => _status;
        set
        {
            if (_status != value)
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
    }

    private float _percent;

    [DisplayName("پیشرفت")]
    public float Percent
    {
        get => _percent;
        set
        {
            if (_percent != value)
            {
                _percent = value;
                OnPropertyChanged(nameof(Percent));
            }
        }
    }
    [DisplayName("سرعت دانلود")]
    public int Speed { get; set; }
    [DisplayName("زمان باقیمانده")]
    public int Remain { get; set; }
    [DisplayName("آخرین تاریخ دانلود")]
    public DateTime LatestDownloadDateTime { get; set; }


    [DisplayName("توضیحات")]
    public string Description { get; set; }


    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


    public int DownloadQueueId { get; set; }

    private DownloadStatus _downloadStatus;
    public DownloadStatus DownloadStatus
    {
        get => _downloadStatus;
        set
        {
            if (_downloadStatus != value)
            {
                _downloadStatus = value;
                OnPropertyChanged(nameof(DownloadStatus));
            }
        }
    }


    public CancellationTokenSource CancellationTokenSource { get; set; } = new CancellationTokenSource();
}
