using De.Kjg.TweenSharkPkg;
using De.Kjg.TweenSharkPkg.Options;
using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Integer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TweenSharkTest.Options
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "PropertyOpsTest" und soll
    ///alle PropertyOpsTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class PropertyOpsTest
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
        ///Ein Test für "PropertyOps-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void PropertyOpsConstructorTest()
        {
            const string propertyName = "TestProperty";
            object targetValue = 123F;
            const bool isRelative = true;
            var target = new PropertyOps(propertyName, targetValue, isRelative);

            Assert.AreEqual(target.PropertyName, propertyName);
            Assert.AreEqual(target.TargetValue, targetValue);
            Assert.AreEqual(target.Tweener, null);
            Assert.AreEqual(target.IsRelative, isRelative);
        }

        /// <summary>
        ///Ein Test für "PropertyOps-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void PropertyOpsConstructorTest1()
        {
            const string propertyName = "OtherTestProperty";
            object targetValue = 1000;
            ITweenSharkTweener tweener = new UnsignedInt32Tweener();
            const bool isRelative = false;
            var target = new PropertyOps(propertyName, targetValue, tweener, isRelative);

            Assert.AreEqual(target.PropertyName, propertyName);
            Assert.AreEqual(target.TargetValue, targetValue);
            Assert.AreEqual(target.Tweener, tweener);
            Assert.AreEqual(target.IsRelative, isRelative);
        }

        /// <summary>
        ///Ein Test für "Ease"
        ///</summary>
        [TestMethod()]
        public void EaseTest()
        {
            // setup object
            const string propertyName = "IntValue";
            object targetValue = 200;
            const bool isRelative = false;
            var target = new PropertyOps(propertyName, targetValue, isRelative);

            // set ease func and look if it is really getting set
            EaseFunction easeFunc = Ease.Linear;
            EaseFunction expected = easeFunc;
            
            // also test chaining
            var ret = target.Ease(easeFunc);
            Assert.AreEqual(target, ret);

            EaseFunction actual = target.EaseFunc;
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        ///Ein Test für "EaseEx"
        ///</summary>
        [TestMethod()]
        public void EaseExTest()
        {
            // setup object
            const string propertyName = "IntValue";
            object targetValue = 200;
            const bool isRelative = false;
            var target = new PropertyOps(propertyName, targetValue, isRelative);
            
            // set ease func and look if it is really getting set
            EaseExFunction easeExFunc = EaseEx.InElastic;
            var easeParams = new object[] {10, 20, 30};
 
            // also test chaining
            var ret = target.EaseEx(easeExFunc, easeParams);
            Assert.AreEqual(target, ret);

            EaseExFunction expectedEaseFunc = easeExFunc;
            EaseExFunction actualEaseFunc = target.EaseExFunc;
            Assert.AreEqual(actualEaseFunc, expectedEaseFunc);

            var expectedEaseParams = easeParams;
            var actualEaseParams = target.EaseExParams;
            Assert.AreEqual(expectedEaseParams, actualEaseParams);
            Assert.AreEqual(3, actualEaseParams.Length);
        }

        /// <summary>
        ///Ein Test für "Start"
        ///</summary>
        [TestMethod()]
        public void StartTest()
        {
            // setup object
            const string propertyName = "IntValue";
            object targetValue = 200;
            const bool isRelative = false;
            var target = new PropertyOps(propertyName, targetValue, isRelative);

            // expect the StartValue to be Null when is was not set
            Assert.AreEqual(target.StartValue, null);

            // set a start value and check if it is there
            object startValue = 100;
            object expected = 100;
            object actual;

            // also test chaining
            var ret = target.Start(startValue);
            Assert.AreEqual(target, ret);

            actual = target.StartValue;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Ein Test für "EaseExFunc"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void EaseExFuncTest()
        {
            var param0 = new PrivateObject(new PropertyOps("", 0, false));
            var target = new PropertyOps_Accessor(param0);
            EaseExFunction expected = EaseEx.InElastic;
            target.EaseExFunc = expected;
            EaseExFunction actual = target.EaseExFunc;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Ein Test für "EaseExParams"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void EaseExParamsTest()
        {
            var param0 = new PrivateObject(new PropertyOps("", 0, false));
            var target = new PropertyOps_Accessor(param0);
            object[] expected = new object[] {10, "a", 10.0F};
            target.EaseExParams = expected;
            object[] actual = target.EaseExParams;
            // we need to get the same object back
            Assert.AreEqual(expected, actual);
            // the object need to have 3 elements in it
            Assert.AreEqual(3, actual.Length);
        }

        /// <summary>
        ///Ein Test für "EaseFunc"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void EaseFuncTest()
        {
            var param0 = new PrivateObject(new PropertyOps("", 0, false));
            var target = new PropertyOps_Accessor(param0);
            EaseFunction expected = Ease.Linear;
            target.EaseFunc = expected;
            EaseFunction actual = target.EaseFunc;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Ein Test für "StartValue"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void StartValueTest()
        {
            var param0 = new PrivateObject(new PropertyOps("", 0, false));
            var target = new PropertyOps_Accessor(param0);
            object expected = 10;
            target.StartValue = expected;
            object actual = target.StartValue;
            Assert.AreEqual(expected, actual);
        }
    }
}
