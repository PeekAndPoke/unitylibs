using De.Kjg.TweenSharkPkg;
using De.Kjg.TweenSharkPkg.Options;
using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.FloatingPoint;
using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Integer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TweenSharkTest.Options
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "TweenOpsTest" und soll
    ///alle TweenOpsTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class TweenOpsTest
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
        ///Ein Test für "TweenOps-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void TweenOpsConstructorTest()
        {
            EaseExFunction easeFunc = EaseEx.InElastic;
            var easeExParams = new object[] {10, 20, 30};
            var target = new TweenOps(easeFunc, easeExParams);

            Assert.IsNull(target.EaseFunc);
            Assert.AreEqual(easeFunc, target.EaseExFunc);
            Assert.AreEqual(easeExParams, target.EaseExParams);
            Assert.AreEqual(3, target.EaseExParams.Length);
        }

        /// <summary>
        ///Ein Test für "TweenOps-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void TweenOpsConstructorTest1()
        {
            EaseFunction easeFunc = Ease.Linear;
            var target = new TweenOps(easeFunc);

            Assert.AreEqual(easeFunc, target.EaseFunc);
            Assert.IsNull(target.EaseExFunc);
            Assert.IsNull(target.EaseExParams);
        }

        /// <summary>
        ///Ein Test für "TweenOps-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void TweenOpsConstructorTest2()
        {
            var target = new TweenOps();

            Assert.AreEqual(Ease.Linear, target.EaseFunc);
            Assert.IsNull(target.EaseExFunc);
            Assert.IsNull(target.EaseExParams);
        }

        /// <summary>
        ///Ein Test für "Ease"
        ///</summary>
        [TestMethod()]
        public void EaseTest()
        {
            var target = new TweenOps();
            EaseFunction easeFunc = Ease.Linear;
            TweenOps expected = target;
            TweenOps actual = target.Ease(easeFunc);
            // test chaining
            Assert.AreEqual(expected, actual);
            // test easing is set
            Assert.AreEqual(Ease.Linear, target.EaseFunc);
        }

        /// <summary>
        ///Ein Test für "OnComplete"
        ///</summary>
        [TestMethod()]
        public void OnCompleteTest()
        {
            var target = new TweenOps();
            TweenSharkCallback onComplete = tweenShark => {  };
            var expected = target;
            var actual = target.OnComplete(onComplete);
            // test chaining
            Assert.AreEqual(expected, actual);
            // test if OnComplete is set
            Assert.AreEqual(onComplete, target.OnCompleteCallback);
        }

        /// <summary>
        ///Ein Test für "OnStart"
        ///</summary>
        [TestMethod()]
        public void OnStartTest()
        {
            var target = new TweenOps();
            TweenSharkCallback onStart = tweenShark => { };
            var expected = target;
            var actual = target.OnStart(onStart);
            // test chaining
            Assert.AreEqual(expected, actual);
            // test if OnStart is set
            Assert.AreEqual(onStart, target.OnStartCallback);
        }

        /// <summary>
        ///Ein Test für "OnUpdate"
        ///</summary>
        [TestMethod()]
        public void OnUpdateTest()
        {
            var target = new TweenOps();
            TweenSharkCallback onUpdate = tweenShark => { };
            var expected = target;
            var actual = target.OnUpdate(onUpdate);
            // test chaining
            Assert.AreEqual(expected, actual);
            // test if onUpdate is set
            Assert.AreEqual(onUpdate, target.OnUpdateCallback);
        }

        /// <summary>
        ///Ein Test für "Prop"
        ///</summary>
        [TestMethod()]
        public void PropTest()
        {
            var target = new TweenOps();
            var ops1 = new PropertyOps("ops1", 100, false);
            var ops2 = new PropertyOps("ops2", 200, true);
            var ops3 = new PropertyOps("ops3", 300, new DoubleTweener(), false);
            var expected = target;
            var actual = target.Prop(ops1).Prop(ops2).Prop(ops3);
            
            // test chaining
            Assert.AreEqual(expected, actual);

            // test if PropertyOps are added
            Assert.AreEqual(3, target.PropertyOpses.Count);
            
            Assert.AreEqual("ops1", target.PropertyOpses[0].PropertyName);
            Assert.AreEqual(100, target.PropertyOpses[0].TargetValue);
            Assert.IsFalse(target.PropertyOpses[0].IsRelative);
            Assert.IsNull(target.PropertyOpses[0].Tweener);
            
            Assert.AreEqual("ops2", target.PropertyOpses[1].PropertyName);
            Assert.AreEqual(200, target.PropertyOpses[1].TargetValue);
            Assert.IsTrue(target.PropertyOpses[1].IsRelative);
            Assert.IsNull(target.PropertyOpses[1].Tweener);
            
            Assert.AreEqual(300, target.PropertyOpses[2].TargetValue);
            Assert.AreEqual("ops3", target.PropertyOpses[2].PropertyName);
            Assert.IsInstanceOfType(target.PropertyOpses[2].Tweener, typeof(DoubleTweener));
        }

        /// <summary>
        ///Ein Test für "PropTo"
        ///</summary>
        [TestMethod()]
        public void PropToTest()
        {
            var target = new TweenOps();
            TweenOps expected = target;
            TweenOps actual = target
                .PropTo("ops1", 100)
                .PropTo("ops2", 200)
                .PropTo("ops3", 300)
                ;
            // test chaining
            Assert.AreEqual(expected, actual);
            // test if values are set
            Assert.AreEqual(3, target.PropertyOpses.Count);

            Assert.AreEqual("ops1", target.PropertyOpses[0].PropertyName);
            Assert.AreEqual(100, target.PropertyOpses[0].TargetValue);
            Assert.IsFalse(target.PropertyOpses[0].IsRelative);
            Assert.IsNull(target.PropertyOpses[0].Tweener);

            Assert.AreEqual("ops2", target.PropertyOpses[1].PropertyName);
            Assert.AreEqual(200, target.PropertyOpses[1].TargetValue);
            Assert.IsFalse(target.PropertyOpses[1].IsRelative);
            Assert.IsNull(target.PropertyOpses[1].Tweener);

            Assert.AreEqual("ops3", target.PropertyOpses[2].PropertyName);
            Assert.AreEqual(300, target.PropertyOpses[2].TargetValue);
            Assert.IsFalse(target.PropertyOpses[2].IsRelative);
            Assert.IsNull(target.PropertyOpses[2].Tweener);
        }

        /// <summary>
        ///Ein Test für "Prop"
        ///</summary>
        [TestMethod()]
        public void PropToTest1()
        {
            var target = new TweenOps();
            TweenOps expected = target;
            // test chaining
            TweenOps actual = target
                .PropTo("ops1", 100, new DoubleTweener())
                .PropTo("ops2", 200, new FloatTweener())
                .PropTo("ops3", 300, new SignedInt32Tweener())
            ;
            Assert.AreEqual(expected, actual);
            // test if PropertyOps are added
            Assert.AreEqual(3, target.PropertyOpses.Count);

            Assert.AreEqual("ops1", target.PropertyOpses[0].PropertyName);
            Assert.IsFalse(target.PropertyOpses[0].IsRelative);
            Assert.AreEqual(100, target.PropertyOpses[0].TargetValue);
            Assert.IsInstanceOfType(target.PropertyOpses[0].Tweener, typeof(DoubleTweener));

            Assert.AreEqual("ops2", target.PropertyOpses[1].PropertyName);
            Assert.IsFalse(target.PropertyOpses[1].IsRelative);
            Assert.AreEqual(200, target.PropertyOpses[1].TargetValue);
            Assert.IsInstanceOfType(target.PropertyOpses[1].Tweener, typeof(FloatTweener));

            Assert.AreEqual("ops3", target.PropertyOpses[2].PropertyName);
            Assert.IsFalse(target.PropertyOpses[2].IsRelative);
            Assert.AreEqual(300, target.PropertyOpses[2].TargetValue);
            Assert.IsInstanceOfType(target.PropertyOpses[2].Tweener, typeof(SignedInt32Tweener));
        }

        /// <summary>
        ///Ein Test für "PropBy"
        ///</summary>
        [TestMethod()]
        public void PropByTest()
        {
            var target = new TweenOps();
            TweenOps expected = target;
            TweenOps actual = target
                .PropBy("ops1", 100)
                .PropBy("ops2", 200)
                .PropBy("ops3", 300)
                ;
            // test chaining
            Assert.AreEqual(expected, actual);
            // test if values are set
            Assert.AreEqual(3, target.PropertyOpses.Count);

            Assert.AreEqual("ops1", target.PropertyOpses[0].PropertyName);
            Assert.AreEqual(100, target.PropertyOpses[0].TargetValue);
            Assert.IsTrue(target.PropertyOpses[0].IsRelative);
            Assert.IsNull(target.PropertyOpses[0].Tweener);

            Assert.AreEqual("ops2", target.PropertyOpses[1].PropertyName);
            Assert.AreEqual(200, target.PropertyOpses[1].TargetValue);
            Assert.IsTrue(target.PropertyOpses[1].IsRelative);
            Assert.IsNull(target.PropertyOpses[1].Tweener);

            Assert.AreEqual("ops3", target.PropertyOpses[2].PropertyName);
            Assert.AreEqual(300, target.PropertyOpses[2].TargetValue);
            Assert.IsTrue(target.PropertyOpses[2].IsRelative);
            Assert.IsNull(target.PropertyOpses[2].Tweener);
        }

        /// <summary>
        ///Ein Test für "PropBy"
        ///</summary>
        [TestMethod()]
        public void PropByTest1()
        {
            var target = new TweenOps();
            TweenOps expected = target;
            // test chaining
            TweenOps actual = target
                .PropBy("ops1", 100, new DoubleTweener())
                .PropBy("ops2", 200, new FloatTweener())
                .PropBy("ops3", 300, new SignedInt32Tweener())
            ;
            Assert.AreEqual(expected, actual);
            // test if PropertyOps are added
            Assert.AreEqual(3, target.PropertyOpses.Count);

            Assert.AreEqual("ops1", target.PropertyOpses[0].PropertyName);
            Assert.IsTrue(target.PropertyOpses[0].IsRelative);
            Assert.AreEqual(100, target.PropertyOpses[0].TargetValue);
            Assert.IsInstanceOfType(target.PropertyOpses[0].Tweener, typeof(DoubleTweener));

            Assert.AreEqual("ops2", target.PropertyOpses[1].PropertyName);
            Assert.IsTrue(target.PropertyOpses[1].IsRelative);
            Assert.AreEqual(200, target.PropertyOpses[1].TargetValue);
            Assert.IsInstanceOfType(target.PropertyOpses[1].Tweener, typeof(FloatTweener));

            Assert.AreEqual("ops3", target.PropertyOpses[2].PropertyName);
            Assert.IsTrue(target.PropertyOpses[2].IsRelative);
            Assert.AreEqual(300, target.PropertyOpses[2].TargetValue);
            Assert.IsInstanceOfType(target.PropertyOpses[2].Tweener, typeof(SignedInt32Tweener));
        }


        /// <summary>
        ///Ein Test für "EaseExFunc"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void EaseExFuncTest()
        {
            var target = new TweenOps_Accessor();
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
            var target = new TweenOps_Accessor();
            var expected = new object[] {10, 20, 30};
            target.EaseExParams = expected;
            object[] actual = target.EaseExParams;
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(3, actual.Length);
        }

        /// <summary>
        ///Ein Test für "EaseFunc"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void EaseFuncTest()
        {
            var target = new TweenOps_Accessor();
            EaseFunction expected = Ease.Linear;
            target.EaseFunc = expected;
            EaseFunction actual = target.EaseFunc;
            Assert.AreEqual(expected, actual);
        }


    }
}
