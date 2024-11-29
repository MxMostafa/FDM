using Client.Domain.Interfaces.General.Errors;


namespace Client.Application.General.Errors;

public class AppErrors : IAppErrors
{
    public string NotFound => "یافت نشد";

    public string DuplicatedFileTypeGroupError => "گروه تکراری است";

    public string DuplicatedDownloadQueue => "نام صف تکراری است";

    public string DuplicatedDownloadFile => "این فایل قبلا در لیست دانلود اضافه شده است";
}
