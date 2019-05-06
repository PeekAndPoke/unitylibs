using De.Kjg.TweenSharkPkg;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TweenSharkTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "EaseExTest" und soll
    ///alle EaseExTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class EaseExTest
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


        public void BasicTweenTestExHelper(EaseExFunction easeExFunc)
        {
            const float b = -100F;
            const float c = 200F;
            var easeParams = new object[] { 0.3f, 0.3f };

            var expected = b;
            var actual = easeExFunc(0F, b, c, easeParams);
            Assert.AreEqual(expected, actual);

            expected = b + c;
            actual = easeExFunc(1F, b, c, easeParams);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Ein Test für "OutElastic"
        ///</summary>
        [TestMethod()]
        public void OutElasticTest()
        {
            BasicTweenTestExHelper(EaseEx.OutElastic);
        }

        /// <summary>
        ///Ein Test für "InElastic"
        ///</summary>
        [TestMethod()]
        public void InElasticTest()
        {
            BasicTweenTestExHelper(EaseEx.InElastic);
        }

        /// <summary>
        ///Ein Test für "EaseEx-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void EaseExConstructorTest()
        {
            EaseEx target = new EaseEx();
        }
    }
}
