using System;
using System.Collections.Generic;
using De.Kjg.Diversity.Interfaces.I18n;

namespace De.Kjg.Diversity.Impl.I18n
{
    public class LocalizedLanguageHolder : II18N
    {
		protected Dictionary<string, LocalizedDataHolder> LanguageHash = new Dictionary<string, LocalizedDataHolder>();

        protected string CurrentLanguage = "";

        public void SetLanguage(string language)
        {
            CurrentLanguage = language;
        }

        public string GetLanguage()
        {
            return CurrentLanguage;
        }

        public string GetText(string fullPath)
        {
            return GetText(fullPath, CurrentLanguage);
        }

        public string GetText(string fullPath, string language)
        {
            return GetData(fullPath, language) as string;
        }

        public string GetText(List<string> fullPath, string language)
        {
            return GetData(fullPath, language) as String;
        }
        
        public void SetData(string language, List<string> path, string id, string content) 
        {
			// get the language root
			var rootHolder = GetRootHolder(language, true);
			// resolve the path
			var targetHolder = rootHolder.ResolvePath(path, true);
			// set the text
			targetHolder.SetData(id, content);
		}

        public object GetData(string fullPath, string language)
        {
            return GetData(new List<string>(fullPath.Split('.')), language);
        }

        public object GetData(List<string> fullPath, string language)  
        {
			// create a copy
			var fullPathCopy = new List<string>(fullPath);
			// get the last item, which is the id
            var id = fullPathCopy[fullPathCopy.Count - 1];
            fullPathCopy.RemoveAt(fullPathCopy.Count - 1);
			
			// get the language root
			var rootHolder = GetRootHolder(language, false);
			if (rootHolder == null) {
				return null;
			}
			// resolve the path
			var targetHolder = rootHolder.ResolvePath(fullPathCopy, false);
			if (targetHolder == null) {
				return null;
			}
			// set the text
			return targetHolder.GetData(id);
		}

        protected LocalizedDataHolder GetRootHolder(string language, bool createIfNotExisting)
        {
            if (!LanguageHash.ContainsKey(language))
            {
                if (!createIfNotExisting)
                {
                    return null;
                }
                LanguageHash[language] = new LocalizedDataHolder(language);
            }
            return LanguageHash[language];
        }
    }
}
