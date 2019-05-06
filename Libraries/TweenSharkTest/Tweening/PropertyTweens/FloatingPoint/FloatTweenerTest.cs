using De.Kjg.TweenSharkPkg.Options;
using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.FloatingPoint;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TweenSharkTest.MockObjects;

namespace TweenSharkTest.Tweening.PropertyTweens.FloatingPoint
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "FloatTweenerTest" und soll
    ///alle FloatTweenerTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class FloatTweenerTest
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
        ///Ein Test für "FloatTweener-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void FloatTweenerConstructorTest()
        {
            FloatTweener target = new FloatTweener();
        }

        /// <summary>
        ///Ein Test für "AddValues"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void AddValuesTest()
        {
            var target = new FloatTweener_Accessor();

            float val1 = 0f;
            float val2 = 0f;
            float expected = 0f;
            float actual = target.AddValues(val1, val2);
            Assert.AreEqual(expected, actual);

            val1 = 10f;
            val2 = 20f;
            expected = 30f;
            actual = target.AddValues(val1, val2);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Ein Test für "CalculateAndSetValue"
        ///</summary>
        [TestMethod()]
        public void CalculateAndSetValueTest()
        {
            FloatTweener target;
            TweeningTestObject obj;
            float deltaTime;

            // test absolute tweening
            target = new FloatTweener();

            obj = new TweeningTestObject { FloatValue = 10f };
            target.Create(obj, new PropertyOps("FloatValue", 10f, false));

            deltaTime = 0f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(obj.FloatValue, 10f);

            deltaTime = 0.5f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(obj.FloatValue, 10f);

            deltaTime = 1f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(obj.FloatValue, 10f);

            // test relative tweening
            target = new FloatTweener();

            obj = new TweeningTestObject { FloatValue = 10f };
            target.Create(obj, new PropertyOps("FloatValue", 10f, true));

            deltaTime = 0f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(obj.FloatValue, 10f);

            deltaTime = 0.5f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(obj.FloatValue, 15f);

            deltaTime = 1f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(obj.FloatValue, 20f);
        }
    }
}
