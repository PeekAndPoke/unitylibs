using System.Collections.Generic;

namespace De.Kjg.Diversity.Interfaces.I18n
{
    public interface II18N
    {
        void SetLanguage(string languageCode);
        string GetLanguage();

        string GetText(string fullPath);
        string GetText(string fullPath, string languageCode);
        string GetText(List<string> fullPath, string languageCode);

        object GetData(string fullPath, string languageCode);
        object GetData(List<string> fullPath, string languageCode);
    }
}
