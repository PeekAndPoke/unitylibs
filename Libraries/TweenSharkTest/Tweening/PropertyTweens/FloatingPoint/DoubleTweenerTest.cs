using De.Kjg.TweenSharkPkg.Options;
using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.FloatingPoint;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TweenSharkTest.MockObjects;

namespace TweenSharkTest.Tweening.PropertyTweens.FloatingPoint
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "DoubleTweenerTest" und soll
    ///alle DoubleTweenerTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class DoubleTweenerTest
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
        ///Ein Test für "DoubleTweener-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void DoubleTweenerConstructorTest()
        {
            DoubleTweener target = new DoubleTweener();
        }

        /// <summary>
        ///Ein Test für "AddValues"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void AddValuesTest()
        {
            var target = new DoubleTweener_Accessor(); // TODO: Passenden Wert initialisieren
            
            double val1 = 0F;
            double val2 = 0F;
            double expected = 0F;
            double actual = target.AddValues(val1, val2);
            Assert.AreEqual(expected, actual);

            val1 = 10F;
            val2 = 20F;
            expected = 30F;
            actual = target.AddValues(val1, val2);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Ein Test für "CalculateAndSetValue"
        ///</summary>
        [TestMethod()]
        public void CalculateAndSetValueTest()
        {
            DoubleTweener target;
            TweeningTestObject obj;
            float deltaTime; 

            // test absolute tweening
            target = new DoubleTweener();

            obj = new TweeningTestObject {DoubleValue = 10F};
            target.Create(obj, new PropertyOps("DoubleValue", 10F, false));
            
            deltaTime = 0F;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(10F, obj.DoubleValue);

            deltaTime = 0.5F;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(10F, obj.DoubleValue);

            deltaTime = 1F;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(10F, obj.DoubleValue);

            // test relative tweening
            target = new DoubleTweener();

            obj = new TweeningTestObject {DoubleValue = 10F};
            target.Create(obj, new PropertyOps("DoubleValue", 10F, true));

            deltaTime = 0F;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(10F, obj.DoubleValue);

            deltaTime = 0.5F;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(15F, obj.DoubleValue);

            deltaTime = 1F;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(20F, obj.DoubleValue);
        }
    }
}
