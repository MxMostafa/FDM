

namespace Client.UI.Helpers;

public static class FormatHelper
{
    public static bool IsUrl(string input)
    {
        return Uri.TryCreate(input, UriKind.Absolute, out Uri uriResult)
               && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps || uriResult.Scheme == Uri.UriSchemeFtp);
    }

    public static string ConvertBytes(long bytes)
    {
        const long KB = 1024;
        const long MB = KB * 1024;
        const long GB = MB * 1024;
        const long TB = GB * 1024;

        if (bytes >= TB)
        {
            return string.Format("{0:0.##} ترابایت", (double)bytes / TB);
        }
        else if (bytes >= GB)
        {
            return string.Format("{0:0.##} گیگابایت", (double)bytes / GB);
        }
        else if (bytes >= MB)
        {
            return string.Format("{0:0.##} مگابایت", (double)bytes / MB);
        }
        else if (bytes >= KB)
        {
            return string.Format("{0:0.##} کیلوبایت", (double)bytes / KB);
        }
        else
        {
            return string.Format("{0} بایت", bytes);
        }
    }

    public static float GetPercent(long number,long total)
    {
        if (total == 0) return 0;

        var res= (float)((((decimal)(number * 100)) / (decimal)total));

        res = Math.Min(res, 100);

        return (float)Math.Round(res, 2);
    }
}
