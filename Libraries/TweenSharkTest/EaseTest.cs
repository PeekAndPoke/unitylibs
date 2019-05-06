using De.Kjg.TweenSharkPkg;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TweenSharkTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "EaseTest" und soll
    ///alle EaseTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class EaseTest
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
        ///Ein Test für "Ease-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void EaseConstructorTest()
        {
            Ease target = new Ease();
        }

        public void BasicTweenTestExHelper(EaseFunction easeFunc)
        {
            const float b = -100F;
            const float c = 200F;

            var expected = b;
            var actual = easeFunc(0F, b, c);
            Assert.AreEqual(expected, actual);

            expected = b + c;
            actual = easeFunc(1F, b, c);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Ein Test für "InExpo"
        ///</summary>
        [TestMethod()]
        public void InExpoTest()
        {
            BasicTweenTestExHelper(Ease.InExpo);
        }

        /// <summary>
        ///Ein Test für "InCubic"
        ///</summary>
        [TestMethod()]
        public void InCubicTest()
        {
            BasicTweenTestExHelper(Ease.InCubic);
        }

        /// <summary>
        ///Ein Test für "InCirc"
        ///</summary>
        [TestMethod()]
        public void InCircTest()
        {
            BasicTweenTestExHelper(Ease.InCirc);
        }

        /// <summary>
        ///Ein Test für "InBounce"
        ///</summary>
        [TestMethod()]
        public void InBounceTest()
        {
            BasicTweenTestExHelper(Ease.InBounce);
        }

        /// <summary>
        ///Ein Test für "InOutBounce"
        ///</summary>
        [TestMethod()]
        public void InOutBounceTest()
        {
            BasicTweenTestExHelper(Ease.InOutBounce);
        }

        /// <summary>
        ///Ein Test für "InOutCirc"
        ///</summary>
        [TestMethod()]
        public void InOutCircTest()
        {
            BasicTweenTestExHelper(Ease.InOutCirc);
        }

        /// <summary>
        ///Ein Test für "InOutCubic"
        ///</summary>
        [TestMethod()]
        public void InOutCubicTest()
        {
            BasicTweenTestExHelper(Ease.InOutCubic);
        }

        /// <summary>
        ///Ein Test für "InOutExpo"
        ///</summary>
        [TestMethod()]
        public void InOutExpoTest()
        {
            BasicTweenTestExHelper(Ease.InOutExpo);
        }

        /// <summary>
        ///Ein Test für "InOutQuad"
        ///</summary>
        [TestMethod()]
        public void InOutQuadTest()
        {
            BasicTweenTestExHelper(Ease.InOutQuad);
        }

        /// <summary>
        ///Ein Test für "InOutQuart"
        ///</summary>
        [TestMethod()]
        public void InOutQuartTest()
        {
            BasicTweenTestExHelper(Ease.InOutQuart);
        }

        /// <summary>
        ///Ein Test für "InOutQuint"
        ///</summary>
        [TestMethod()]
        public void InOutQuintTest()
        {
            BasicTweenTestExHelper(Ease.InOutQuint);
        }

        /// <summary>
        ///Ein Test für "InOutSine"
        ///</summary>
        [TestMethod()]
        public void InOutSineTest()
        {
            BasicTweenTestExHelper(Ease.InOutSine);
        }

        /// <summary>
        ///Ein Test für "InQuad"
        ///</summary>
        [TestMethod()]
        public void InQuadTest()
        {
            BasicTweenTestExHelper(Ease.InQuad);
        }

        /// <summary>
        ///Ein Test für "InQuart"
        ///</summary>
        [TestMethod()]
        public void InQuartTest()
        {
            BasicTweenTestExHelper(Ease.InQuart);
        }

        /// <summary>
        ///Ein Test für "InQuint"
        ///</summary>
        [TestMethod()]
        public void InQuintTest()
        {
            BasicTweenTestExHelper(Ease.InQuint);
        }

        /// <summary>
        ///Ein Test für "InSine"
        ///</summary>
        [TestMethod()]
        public void InSineTest()
        {
            BasicTweenTestExHelper(Ease.InSine);
        }

        /// <summary>
        ///Ein Test für "Linear"
        ///</summary>
        [TestMethod()]
        public void LinearTest()
        {
            BasicTweenTestExHelper(Ease.Linear);
        }

        /// <summary>
        ///Ein Test für "OutBounce"
        ///</summary>
        [TestMethod()]
        public void OutBounceTest()
        {
            BasicTweenTestExHelper(Ease.OutBounce);
        }

        /// <summary>
        ///Ein Test für "OutCirc"
        ///</summary>
        [TestMethod()]
        public void OutCircTest()
        {
            BasicTweenTestExHelper(Ease.OutCirc);
        }

        /// <summary>
        ///Ein Test für "OutCubic"
        ///</summary>
        [TestMethod()]
        public void OutCubicTest()
        {
            BasicTweenTestExHelper(Ease.OutCubic);
        }

        /// <summary>
        ///Ein Test für "OutExpo"
        ///</summary>
        [TestMethod()]
        public void OutExpoTest()
        {
            BasicTweenTestExHelper(Ease.OutExpo);
        }

        /// <summary>
        ///Ein Test für "OutQuad"
        ///</summary>
        [TestMethod()]
        public void OutQuadTest()
        {
            BasicTweenTestExHelper(Ease.OutQuad);
        }

        /// <summary>
        ///Ein Test für "OutQuart"
        ///</summary>
        [TestMethod()]
        public void OutQuartTest()
        {
            BasicTweenTestExHelper(Ease.OutQuart);
        }

        /// <summary>
        ///Ein Test für "OutQuint"
        ///</summary>
        [TestMethod()]
        public void OutQuintTest()
        {
            BasicTweenTestExHelper(Ease.OutQuint);
        }

        /// <summary>
        ///Ein Test für "OutSine"
        ///</summary>
        [TestMethod()]
        public void OutSineTest()
        {
            BasicTweenTestExHelper(Ease.OutSine);
        }
    }
}
