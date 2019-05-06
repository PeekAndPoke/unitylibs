using De.Kjg.TweenSharkPkg.Options;
using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Integer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TweenSharkTest.MockObjects;

namespace TweenSharkTest.Tweening.PropertyTweens.Integer
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "UnsignedInt32TweenerTest" und soll
    ///alle UnsignedInt32TweenerTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class UnsignedInt32TweenerTest
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
        ///Ein Test für "UnsignedInt32Tweener-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void UnsignedInt32TweenerConstructorTest()
        {
            UnsignedInt32Tweener target = new UnsignedInt32Tweener();
        }

        /// <summary>
        ///Ein Test für "AddValues"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void AddValuesTest()
        {
            var target = new UnsignedInt32Tweener_Accessor();

            uint val1 = 0;
            uint val2 = 0;
            uint expected = 0;
            uint actual = target.AddValues(val1, val2);
            Assert.AreEqual(expected, actual);

            val1 = 10;
            val2 = 20;
            expected = 30;
            actual = target.AddValues(val1, val2);
            Assert.AreEqual(expected, actual);

            val1 = 4294967295;
            val2 = 1;
            expected = 0;
            actual = target.AddValues(val1, val2);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Ein Test für "CalculateAndSetValue"
        ///</summary>
        [TestMethod()]
        public void CalculateAndSetValueTest()
        {
            UnsignedInt32Tweener target;
            TweeningTestObject obj;
            float deltaTime;

            // test absolute UnsignedInt32Tweener
            target = new UnsignedInt32Tweener();

            obj = new TweeningTestObject { UintValue = 10 };
            target.Create(obj, new PropertyOps("UintValue", 10f, false));

            deltaTime = 0f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(10U, obj.UintValue);

            deltaTime = 0.5f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(10U, obj.UintValue);

            deltaTime = 1f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(10U, obj.UintValue);

            // test relative tweening
            target = new UnsignedInt32Tweener();

            obj = new TweeningTestObject { UintValue = 10 };
            target.Create(obj, new PropertyOps("UintValue", 10, true));

            deltaTime = 0f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(10U, obj.UintValue);

            deltaTime = 0.5f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(15U, obj.UintValue);

            deltaTime = 1f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(20U, obj.UintValue);
        }
    }
}
