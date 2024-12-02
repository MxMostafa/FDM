

using static DevExpress.DataProcessing.InMemoryDataProcessor.AddSurrogateOperationAlgorithm;

namespace Client.UI.ViewModel.Download;

public class DownloadViewModel: INotifyPropertyChanged
{
    [DisplayName("شناسه")]
    public int Id { get; set; }
    [DisplayName("نام  فایل")]
    public string FileName { get; set; }
    [DisplayName("آیکن")]
    public string FileIcon { get; set; }
    [DisplayName("صف")]
    public string DownloadQueue { get; set; }
    [DisplayName("اندازه")]
    public long Size { get; set; }
    [DisplayName("وضعیت")]
    public string Status { get; set; }
    [DisplayName("پیشرفت")]
    public int Percent { get; set; }
    [DisplayName("سرعت دانلود")]
    public int Speed { get; set; }
    [DisplayName("زمان باقیمانده")]
    public int Remain { get; set; }
    [DisplayName("آخرین تاریخ دانلود")]
    public DateTime LatestDownloadDateTime { get; set; }

    private string _description;
    [DisplayName("توضیحات")]
    public string Description
    {
        get => _description;
        set
        {
            if (_description != value)
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
