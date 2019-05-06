using De.Kjg.TweenSharkPkg.Options;
using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Integer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TweenSharkTest.MockObjects;

namespace TweenSharkTest.Tweening.PropertyTweens.Integer
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "SignedByteTweenerTest" und soll
    ///alle SignedByteTweenerTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class SignedByteTweenerTest
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
        ///Ein Test für "SignedByteTweener-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void SignedByteTweenerConstructorTest()
        {
            SignedByteTweener target = new SignedByteTweener();
        }

        /// <summary>
        ///Ein Test für "AddValues"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void AddValuesTest()
        {
            var target = new SignedByteTweener_Accessor();
            
            SByte val1 = 0;
            SByte val2 = 0;
            SByte expected = 0;
            SByte actual = target.AddValues(val1, val2);
            Assert.AreEqual(expected, actual);

            val1 = 10;
            val2 = 20;
            expected = 30;
            actual = target.AddValues(val1, val2);
            Assert.AreEqual(expected, actual);

            val1 = -128;
            val2 = -1;
            expected = 127;
            actual = target.AddValues(val1, val2);
            Assert.AreEqual(expected, actual);

            val1 = 127;
            val2 = 1;
            expected = -128;
            actual = target.AddValues(val1, val2);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Ein Test für "CalculateAndSetValue"
        ///</summary>
        [TestMethod()]
        public void CalculateAndSetValueTest()
        {
            SignedByteTweener target;
            TweeningTestObject obj;
            float deltaTime;

            // test absolute tweening
            target = new SignedByteTweener();

            obj = new TweeningTestObject { SbyteValue = 10 };
            target.Create(obj, new PropertyOps("SbyteValue", 10f, false));

            deltaTime = 0f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(obj.SbyteValue, 10);

            deltaTime = 0.5f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(obj.SbyteValue, 10);

            deltaTime = 1f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(obj.SbyteValue, 10);

            // test relative tweening
            target = new SignedByteTweener();

            obj = new TweeningTestObject { SbyteValue = 10 };
            target.Create(obj, new PropertyOps("SbyteValue", 10, true));

            deltaTime = 0f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(obj.SbyteValue, 10);

            deltaTime = 0.5f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(obj.SbyteValue, 15);

            deltaTime = 1f;
            target.CalculateAndSetValue(deltaTime);
            Assert.AreEqual(obj.SbyteValue, 20);
        }
    }
}
