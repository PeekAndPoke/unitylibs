using De.Kjg.TweenSharkPkg.Options;
using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Integer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TweenSharkTest.MockObjects;

namespace TweenSharkTest.Tweening.PropertyTweens.Integer
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "UnsignedInt64TweenerTest" und soll
    ///alle UnsignedInt64TweenerTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class UnsignedInt64TweenerTest
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
        ///Ein Test für "UnsignedInt64Tweener-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void UnsignedInt64TweenerConstructorTest()
        {
            UnsignedInt64Tweener target = new UnsignedInt64Tweener();
        }

        /// <summary>
        ///Ein Test für "AddValues"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void AddValuesTest()
        {
            var target = new UnsignedInt64Tweener_Accessor(); // TODO: Passenden Wert initialisieren
        
            ulong val1 = 0;
            ulong val2 = 0;
            ulong expected = 0;
            ulong actual = target.AddValues(val1, val2);
            Assert.AreEqual(expected, actual);

            val1 = 10;
            val2 = 20;
            expected = 30;
            actual = target.AddValues(val1, val2);
            Assert.AreEqual(expected, actual);

            val1 = 18446744073709551615;
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
            UnsignedInt64Tweener target;
            TweeningTestObject obj;
            float deltaTime;

            // test absolute tweening
            target = new UnsignedInt64Tweener();

            obj = new TweeningTestObject { UlongValue = 10 };
            target.Create(obj, new PropertyOps("UlongValue", 10f, false));

            deltaTime = 0f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(10UL, obj.UlongValue);

            deltaTime = 0.5f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(10UL, obj.UlongValue);

            deltaTime = 1f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(10UL, obj.UlongValue);

            // test relative tweening
            target = new UnsignedInt64Tweener();

            obj = new TweeningTestObject { UlongValue = 10 };
            target.Create(obj, new PropertyOps("UlongValue", 10, true));

            deltaTime = 0f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(10UL, obj.UlongValue);

            deltaTime = 0.5f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(15UL, obj.UlongValue);

            deltaTime = 1f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(20UL, obj.UlongValue);
        }
    }
}
