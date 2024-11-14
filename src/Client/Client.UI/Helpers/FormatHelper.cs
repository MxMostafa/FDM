

namespace Client.UI.Helpers;

public static class FormatHelper
{
    public static bool IsUrl(string input)
    {
        return Uri.TryCreate(input, UriKind.Absolute, out Uri uriResult)
               && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps || uriResult.Scheme == Uri.UriSchemeFtp);
    }
}
