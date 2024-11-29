

namespace Client.UI.ViewModel.Download;

public class DownloadViewModel
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
    [DisplayName("توضیحات")]
    public string Description { get; set; }
}
