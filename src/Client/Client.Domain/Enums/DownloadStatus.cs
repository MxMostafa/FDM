

namespace Client.Domain.Enums;

public enum DownloadStatus
{
    NotStarted,   // دانلود هنوز شروع نشده است
    Started,      // دانلود شروع شده است
    Paused,       // دانلود متوقف شده است (موقتی)
    Finished,     // دانلود به اتمام رسیده است
    Error,        // مشکلی در دانلود رخ داده است
    Cancelling,   // دانلود در حال لغو شدن
    Cancelled,    // دانلود لغو شده است
    Retrying      // در حال تلاش مجدد برای دانلود
}
