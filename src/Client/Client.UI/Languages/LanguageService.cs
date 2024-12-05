using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Client.UI.Languages;

public class LanguageService
{
    private ResourceManager _resourceManager;
    private CultureInfo _culture;

    public LanguageService(string baseName )
    {
        _resourceManager = new ResourceManager(baseName, typeof(LanguageService).Assembly);
        _culture = CultureInfo.CurrentCulture;
    }

    public void SetLanguage(string languageCode)
    {
        _culture = new CultureInfo(languageCode);
        CultureInfo.DefaultThreadCurrentCulture = _culture;
        CultureInfo.DefaultThreadCurrentUICulture = _culture;
    }

    public string GetString(string key)
    {
        return _resourceManager.GetString(key, _culture);
    }
}
