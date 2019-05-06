using System.Xml;
using De.Kjg.Diversity.Impl.I18n;

namespace De.Kjg.Diversity.Interfaces.I18n
{
    public interface II18NXmlImporter
    {
        void Import(XmlDocument xml, LocalizedLanguageHolder languageHolder);
    }
}