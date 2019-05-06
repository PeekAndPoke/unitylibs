using System.Reflection;
using De.Kjg.TweenSharkPkg;
using De.Kjg.TweenSharkPkg.Core;
using De.Kjg.TweenSharkPkg.Logging;
using De.Kjg.TweenSharkPkg.Options;
using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.FloatingPoint;
using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Integer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TweenSharkTest.MockObjects;

namespace TweenSharkTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "TweenSharkTest" und soll
    ///alle TweenSharkTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class TweenSharkTest
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
        ///Ein Test für "TweenShark-Konstruktor"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void TweenSharkConstructorTest()
        {
            var obj = new TweeningTestObject();
            const float duration = 1F;
            var tweenOps = new TweenOps();
            
            var tweenShark = new TweenShark(obj, duration, tweenOps);

            Assert.AreSame(obj, tweenShark.Obj);
            Assert.AreEqual(duration, tweenShark.Duration);
            Assert.AreSame(tweenOps, tweenShark.TweenOps);
        }

        /// <summary>
        ///Ein Test für "HasStarted"
        ///</summary>
        [TestMethod()]
        public void HasStartedTest()
        {
            Assert.Inconclusive("must be redone!");
//            var tween = new TweenShark(null, 1f, new TweenOps());
//            var param0 = new PrivateObject(tween);
//            var target = new TweenShark_Accessor(param0);
//            Assert.AreEqual(target.HasStarted(), tween.InternalHasStarted);
        }

        /// <summary>
        ///Ein Test für "IsCompleted"
        ///</summary>
        [TestMethod()]
        public void IsCompletedTest()
        {
            Assert.Inconclusive("must be redone!");
//            var tween = new TweenShark(null, 1f, new TweenOps());
//            var param0 = new PrivateObject(tween);
//            var target = new TweenShark_Accessor(param0);
//            Assert.AreEqual(target.IsCompleted(), tween.InternalIsCompleted);
        }

        /// <summary>
        ///Ein Test für "IsPlaying"
        ///</summary>
        [TestMethod()]
        public void IsPlayingTest()
        {
            Assert.Inconclusive("must be redone!");
//            var tween = new TweenShark(null, 1f, new TweenOps());
//            var param0 = new PrivateObject(tween);
//            var target = new TweenShark_Accessor(param0);
//            Assert.AreEqual(target.IsPlaying(), tween.InternalIsPlaying);
        }

        /// <summary>
        ///Ein Test für "Initialize"
        ///</summary>
        [TestMethod()]
        public void InitializeTest()
        {
            TweenShark.Initialize(new TweenSharkTickImpl(), new NullLogger());

            var type = typeof (TweenShark);
            var info = type.GetField("_core", BindingFlags.NonPublic | BindingFlags.Static);
            var core = (TweenSharkCore) info.GetValue(null);

            // the core must be created
            Assert.IsInstanceOfType(core, typeof(TweenSharkCore));

            var param0 = new PrivateObject(core);
            var accessor = new TweenSharkCore_Accessor(param0);

            // the standard property tweeners must be registered
            Assert.AreEqual(10, accessor._registeredPropertyTweeners.Count);
            // check that all tweeners are registerd correctly
            Assert.AreEqual(accessor._registeredPropertyTweeners[typeof(SByte).FullName], typeof(SignedByteTweener));
                Assert.AreEqual(accessor._registeredPropertyTweeners[typeof(Int16).FullName], typeof(SignedInt16Tweener));
            Assert.AreEqual(accessor._registeredPropertyTweeners[typeof(Int32).FullName], typeof(SignedInt32Tweener));
            Assert.AreEqual(accessor._registeredPropertyTweeners[typeof(Int64).FullName], typeof(SignedInt64Tweener));

            Assert.AreEqual(accessor._registeredPropertyTweeners[typeof(Byte).FullName], typeof(UnsignedByteTweener));
            Assert.AreEqual(accessor._registeredPropertyTweeners[typeof(UInt16).FullName], typeof(UnsignedInt16Tweener));
            Assert.AreEqual(accessor._registeredPropertyTweeners[typeof(UInt32).FullName], typeof(UnsignedInt32Tweener));
            Assert.AreEqual(accessor._registeredPropertyTweeners[typeof(UInt64).FullName], typeof(UnsignedInt64Tweener));

            Assert.AreEqual(accessor._registeredPropertyTweeners[typeof(Single).FullName], typeof(FloatTweener));
            Assert.AreEqual(accessor._registeredPropertyTweeners[typeof(Double).FullName], typeof(DoubleTweener));
        }

        /// <summary>
        ///Ein Test für "RegisterPropertyTweener"
        ///</summary>
        [TestMethod()]
        public void RegisterPropertyTweenerTest()
        {
            TweenShark.Initialize(new TweenSharkTickImpl(), new NullLogger());

            var type = typeof(TweenShark);
            var info = type.GetField("_core", BindingFlags.NonPublic | BindingFlags.Static);
            var core = (TweenSharkCore)info.GetValue(null);

            // the core must be created
            Assert.IsInstanceOfType(core, typeof(TweenSharkCore));

            var param0 = new PrivateObject(core);
            var accessor = new TweenSharkCore_Accessor(param0);

            var beforeCount = accessor._registeredPropertyTweeners.Count;

            // if we overwrite an existing type the number of registered tweeners must not change
            TweenShark.RegisterPropertyTweener(typeof(SimpleTweenerImpl<SByte>), typeof(SByte));
            Assert.AreEqual(beforeCount, accessor._registeredPropertyTweeners.Count);
            // the tweener for sbyte must be overwritten
            Assert.AreEqual(accessor._registeredPropertyTweeners[typeof(SByte).FullName], typeof(SimpleTweenerImpl<SByte>));

            // if we overwrite an existing type the number of registered tweeners must change
            TweenShark.RegisterPropertyTweener(typeof(SimpleTweenerImpl<SByte>), typeof(TweeningTestObject));
            Assert.AreEqual(beforeCount+1, accessor._registeredPropertyTweeners.Count);
            // the tweener for sbyte must be overwritten
            Assert.AreEqual(accessor._registeredPropertyTweeners[typeof(TweeningTestObject).FullName], typeof(SimpleTweenerImpl<SByte>));
        }

        /// <summary>
        ///Ein Test für "To"
        ///</summary>
        [TestMethod()]
        public void ToTest()
        {
            object obj = null; // TODO: Passenden Wert initialisieren
            float duration = 0F; // TODO: Passenden Wert initialisieren
            TweenOps tweenOps = null; // TODO: Passenden Wert initialisieren
            TweenShark expected = null; // TODO: Passenden Wert initialisieren
            TweenShark actual;
            actual = TweenShark.To(obj, duration, tweenOps);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "DeltaTicks"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void DeltaTicksTest()
        {
        }

        /// <summary>
        ///Ein Test für "Obj"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void ObjTest()
        {
        }

        /// <summary>
        ///Ein Test für "Progress"
        ///</summary>
        [TestMethod()]
        public void ProgressTest()
        {
            Assert.Inconclusive("must be redone!");
        }
    }
}
