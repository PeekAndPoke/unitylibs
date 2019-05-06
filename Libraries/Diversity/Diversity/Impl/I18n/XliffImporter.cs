using System.Collections.Generic;
using System.Xml;
using De.Kjg.Diversity.Impl.I18n.Exceptions;
using De.Kjg.Diversity.Interfaces.I18n;

namespace De.Kjg.Diversity.Impl.I18n
{
    public class XliffImporter : II18NXmlImporter
    {
		/** the localized language storage contains the data for all languages */
        protected LocalizedLanguageHolder LanguageHolder;
		/** the source language */
		protected string SourceLanguage;
		/** the target language */
		protected string TargetLanguage;
		
		/**
		 * import xml content from XLIFF-xml to the given languageHolder
		 * 
		 * @param xml the XLIFF-xml to be imported
		 * @param languageHolder the LocalizedLanguageHolder instance where the data will be imported to 
		 */
		public void Import(XmlDocument xml, LocalizedLanguageHolder languageHolder)
        {
			// store the reference
            LanguageHolder = languageHolder;

		    var fileInfo = xml.SelectSingleNode("/xliff/file");

			// get source and target language
			SourceLanguage = fileInfo.Attributes["source-language"].InnerText;

            if (!IsValidAttribute(SourceLanguage))
            {
				throw new I18NException("the file-tag needs to define the attribute 'source-language'!");
			}

            TargetLanguage = fileInfo.Attributes["target-language"].InnerText;
			
			// step inside the body tag
		    var bodies = xml.SelectSingleNode("/xliff/file");

			foreach(XmlNode body in bodies) {
				// start parsing with root path
                ParseContent(body, new List<string>());
			}
		}
		
		/**
		 * Parses the content of the given node for any trans-unit and group tags and add the content found to the LocalizedLanguageHolder
		 * 
		 * If groups are found a path is build to address the texts later. Groups will be processed recursivly.
		 * 
		 * @param xml the xml snippet to be parsed
		 * @param pathInDataHolder the path inside of the LocalizedLanguageHolder where the texts will be stored
		 */
		private void ParseContent(XmlNode rootNode, List<string> pathInDataHolder) 
        {
            foreach (XmlNode node in rootNode.ChildNodes)
			{
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                // is the given parameter an xml?
                if (node.Name == "trans-unit")
                {

				    // log.debug("transUnit: " + transUnit.toXMLString().replace("<", "^"));
				    // get the resource id
                    string id = node.Attributes["id"].InnerText;
				    // get the source text
                    var source = node.SelectSingleNode("source");
				    // if the source is defined we can go on
                    if (source != null)
                    {
                        // add the text to the language holder
                        LanguageHolder.SetData(SourceLanguage, pathInDataHolder, id, source.InnerText);

                        // do we have a target language set
                        if (TargetLanguage != null)
                        {
                            // get the target text
                            var target = node.SelectSingleNode("target");
                            // add the text to the language holder
                            LanguageHolder.SetData(TargetLanguage, pathInDataHolder, id, target.InnerText);
                        }

                        // get all alternative translations
                        var alternativeTranslations = node.SelectNodes("alt-trans");
                        if (alternativeTranslations != null)
                        {
                            foreach (XmlNode alternativeTranslation in alternativeTranslations)
                            {
                                var targets = alternativeTranslation.SelectNodes("target");

                                foreach (XmlNode target in targets)
                                {
                                    // get the language
                                    var lang = target.Attributes["xml:lang"];
                                    // get the text
                                    LanguageHolder.SetData(lang.InnerText, pathInDataHolder, id, target.InnerText);
                                }
                            }
                        }
                    }
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (node.Name == "group")
                {
                    var groupId = node.Attributes["id"].InnerText;
                    // make a copy of the current path
                    var path = new List<string>(pathInDataHolder); 
                    path.Add(groupId);

                    ParseContent(node, path);
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
		}

        private static bool IsValidAttribute(string attribute) 
        {
			return attribute != null;
		}

    }
}
