using De.Kjg.Diversity.Interfaces.I18n;

namespace De.Kjg.Diversity.Impl.I18n.Strings
{
    public class LocalizedString : StringHolder
    {
        private readonly ITranslatable _translatable;
        private readonly string _fullPath;

        private bool _hasLanguageSet;
        private LanguageCode _language;

        public LocalizedString(ITranslatable translatable, string fullPath)
        {
            _translatable = translatable;
            _fullPath = fullPath;
        }

        public LocalizedString SetLanguage(LanguageCode language)
        {
            _hasLanguageSet = true;
            _language = language;
            return this;
        }

        public LocalizedString UseDefaultLanguage()
        {
            _hasLanguageSet = false;
            return this;
        }

        public override string ToString()
        {
            var localizedData = _translatable.GetI18N();

            if (localizedData == null)
            {
                return _fullPath;
            }

            if (_hasLanguageSet == false)
            {
                return localizedData.GetText(_fullPath);
            }

            return localizedData.GetText(_fullPath, _language.ToString());
        }
    }
}
