using System.Xml;
using De.Kjg.Diversity.Impl.I18n;
using NUnit.Framework;

namespace De.Kjg.Diversity.I18n
{
    [TestFixture]
    class XliffImporterTest
    {
        public static string TestData =
            "<xliff version='1.2'>" +
            "   <file original='hello.txt' source-language='en' target-language='fr' datatype='plaintext'>" +
            "       <body>" +
            "           <trans-unit id='hi'>" +
            "               <source>Hello world</source>" +
            "               <target>Bonjour le monde</target>" +
            "               <alt-trans>" +
            "                   <target xml:lang='es'>Hola mundo</target>" +
            "                   <target xml:lang='it'>Ciao mondo</target>" +
            "               </alt-trans>" +
            "               <alt-trans>" +
            "                   <target xml:lang='de'>Hallo Welt</target>" +
            "               </alt-trans>" +
            "           </trans-unit>" +
            "           <group id='group1'>" +
            "               <trans-unit id='hi'>" +
            "                   <source>Hello world</source>" +
            "                   <target>Bonjour le monde</target>" +
            "               </trans-unit>" +
            "               <group id='groupInGroup1'>" +
            "                   <trans-unit id='hi'>" +
            "                       <source>Hello world</source>" +
            "                       <target>Bonjour le monde</target>" +
            "                   </trans-unit>" +
            "               </group>" +
            "               <group id='groupInGroup2'>" +
            "               </group>" +
            "           </group>" +
            "           <group id='group2'>" +
            "           </group>" +
            "       </body>" +
            "   </file>" +
            "</xliff>"
        ;

        [Test]
        public void ImportTest()
        {
            var importer = new XliffImporter();
            var xml = new XmlDocument();
            xml.LoadXml(TestData);
            var holder = new LocalizedLanguageHolder();

            importer.Import(xml, holder);

            // check if the simple entry works for all languages
            Assert.AreEqual("Hello world", holder.GetData("hi", "en"));
            Assert.AreEqual("Bonjour le monde", holder.GetData("hi", "fr"));
            Assert.AreEqual("Hola mundo", holder.GetData("hi", "es"));
            Assert.AreEqual("Ciao mondo", holder.GetData("hi", "it"));
            Assert.AreEqual("Hallo Welt", holder.GetData("hi", "de"));

            // check if the groups work
            Assert.AreEqual("Hello world", holder.GetData("group1.hi", "en"));
            Assert.AreEqual("Bonjour le monde", holder.GetData("group1.hi", "fr"));
            Assert.AreEqual(null, holder.GetData("group1.hi", "es"));
            Assert.AreEqual(null, holder.GetData("group1.hi", "it"));
            Assert.AreEqual(null, holder.GetData("group1.hi", "de"));

            // check if nested groups work
            Assert.AreEqual("Hello world", holder.GetData("group1.groupInGroup1.hi", "en"));
            Assert.AreEqual("Bonjour le monde", holder.GetData("group1.groupInGroup1.hi", "fr"));
        }
    }
}
