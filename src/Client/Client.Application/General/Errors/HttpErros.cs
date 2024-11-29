

using Client.Domain.Interfaces.General.Errors;

namespace Client.Application.General.Errors;

public class HttpErros : IHttpErros
{
    public string InvalidURL => "آدرس دانلود نامعتبر است";
}
