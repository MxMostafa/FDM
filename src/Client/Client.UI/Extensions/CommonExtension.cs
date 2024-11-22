



using Client.Domain.Dtos;

namespace Client.UI.Extensions;

public static class CommonExtension
{

    public static void Handle(this Exception ex, Microsoft.Extensions.Logging.ILogger logger)
    {
        if (ex == null || logger == null) return;

        // لاگ خطا با استفاده از Serilog
        logger.LogError(ex, "An exception occurred: {Message}", ex.InnerException?.Message??ex.Message);

        ErrorHelper.ShowErrorAsMessageBox(ex);

    }

    public static void Handle<T>(this ResultPattern<T> result) 
    {

        ErrorHelper.ShowErrorAsMessageBox(result.ErrorMessage);

    }

    public static void Throw<T>(this ResultPattern<T> result)
    {

        throw new Exception(result.ErrorMessage);

    }
}
