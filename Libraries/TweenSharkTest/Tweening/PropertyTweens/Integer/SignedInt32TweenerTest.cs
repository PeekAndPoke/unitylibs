using De.Kjg.TweenSharkPkg.Options;
using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Integer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TweenSharkTest.MockObjects;

namespace TweenSharkTest.Tweening.PropertyTweens.Integer
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "SignedInt32TweenerTest" und soll
    ///alle SignedInt32TweenerTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class SignedInt32TweenerTest
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
        ///Ein Test für "SignedInt32Tweener-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void SignedInt32TweenerConstructorTest()
        {
            SignedInt32Tweener target = new SignedInt32Tweener();
        }

        /// <summary>
        ///Ein Test für "AddValues"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void AddValuesTest()
        {
            var target = new SignedInt32Tweener_Accessor(); // TODO: Passenden Wert initialisieren

            int val1 = 0;
            int val2 = 0;
            int expected = 0;
            int actual = target.AddValues(val1, val2);
            Assert.AreEqual(expected, actual);

            val1 = 10;
            val2 = 20;
            expected = 30;
            actual = target.AddValues(val1, val2);
            Assert.AreEqual(expected, actual);

            val1 = -2147483648;
            val2 = -1;
            expected = 2147483647;
            actual = target.AddValues(val1, val2);
            Assert.AreEqual(expected, actual);

            val1 = 2147483647;
            val2 = 1;
            expected = -2147483648;
            actual = target.AddValues(val1, val2);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Ein Test für "CalculateAndSetValue"
        ///</summary>
        [TestMethod()]
        public void CalculateAndSetValueTest()
        {
            SignedInt32Tweener target;
            TweeningTestObject obj;
            float deltaTime;

            // test absolute tweening
            target = new SignedInt32Tweener();

            obj = new TweeningTestObject { IntValue = 10 };
            target.Create(obj, new PropertyOps("IntValue", 10f, false));

            deltaTime = 0f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(obj.IntValue, 10);

            deltaTime = 0.5f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(obj.IntValue, 10);

            deltaTime = 1f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(obj.IntValue, 10);

            // test relative tweening
            target = new SignedInt32Tweener();

            obj = new TweeningTestObject { IntValue = 10 };
            target.Create(obj, new PropertyOps("IntValue", 10, true));

            deltaTime = 0f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(obj.IntValue, 10);

            deltaTime = 0.5f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(obj.IntValue, 15);

            deltaTime = 1f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(obj.IntValue, 20);
        }
    }
}
