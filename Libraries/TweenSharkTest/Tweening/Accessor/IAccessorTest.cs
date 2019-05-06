using De.Kjg.TweenSharkPkg.Tweening.Accessor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TweenSharkTest.Tweening.Accessor
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "IAccessorTest" und soll
    ///alle IAccessorTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class IAccessorTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Ruft den Testkontext auf, der Informationen
        ///über und Funktionalität für den aktuellen Testlauf bietet, oder legt diesen fest.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Zusätzliche Testattribute
        // 
        //Sie können beim Verfassen Ihrer Tests die folgenden zusätzlichen Attribute verwenden:
        //
        //Mit ClassInitialize führen Sie Code aus, bevor Sie den ersten Test in der Klasse ausführen.
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Mit ClassCleanup führen Sie Code aus, nachdem alle Tests in einer Klasse ausgeführt wurden.
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Mit TestInitialize können Sie vor jedem einzelnen Test Code ausführen.
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Ein Test für "GetValue"
        ///</summary>
        public void GetValueTestHelper<TValueType>()
        {
//            IAccessor<TValueType> target = CreateIAccessor<TValueType>(); // TODO: Passenden Wert initialisieren
//            TValueType expected = default(TValueType); // TODO: Passenden Wert initialisieren
//            TValueType actual;
//            actual = target.GetValue();
//            Assert.AreEqual(expected, actual);
//            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        internal virtual IAccessor<TValueType> CreateIAccessor<TValueType>()
        {
            // TODO: Geeignete konkrete Klasse instanziieren
            IAccessor<TValueType> target = null;
            return target;
        }

        [TestMethod()]
        public void GetValueTest()
        {
            GetValueTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Ein Test für "SetValue"
        ///</summary>
        public void SetValueTestHelper<TValueType>()
        {
//            IAccessor<TValueType> target = CreateIAccessor<TValueType>(); // TODO: Passenden Wert initialisieren
//            TValueType value = default(TValueType); // TODO: Passenden Wert initialisieren
//            target.SetValue(value);
//            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        [TestMethod()]
        public void SetValueTest()
        {
            SetValueTestHelper<GenericParameterHelper>();
        }
    }
}
