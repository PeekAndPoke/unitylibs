using De.Kjg.TweenSharkPkg;
using De.Kjg.TweenSharkPkg.Core;
using De.Kjg.TweenSharkPkg.Logging;
using De.Kjg.TweenSharkPkg.Options;
using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.FloatingPoint;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TweenSharkTest.MockObjects;

namespace TweenSharkTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "TweenSharkCoreTest" und soll
    ///alle TweenSharkCoreTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class TweenSharkCoreTest
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
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
        }
        
        //Mit ClassCleanup führen Sie Code aus, nachdem alle Tests in einer Klasse ausgeführt wurden.
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Mit TestInitialize können Sie vor jedem einzelnen Test Code ausführen.
        [TestInitialize()]
        public void MyTestInitialize()
        {
            TweenShark.Initialize(new TweenSharkTickImpl(), new ConsoleLogger());
        }
        
        //Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Ein Test für "TweenSharkCore-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void TweenSharkCoreConstructorTest()
        {
            var ticker = new TweenSharkTickImpl();
            var target = new TweenSharkCore(ticker);
        }

        /// <summary>
        ///Ein Test für "RegisterPropertyTweener"
        ///</summary>
        [TestMethod()]
        public void RegisterPropertyTweenerTest()
        {
            var ticker = new TweenSharkTickImpl();
            var target = new TweenSharkCore(ticker);
            target.RegisterPropertyTweener(typeof(DoubleTweener), typeof(Double));
            target.RegisterPropertyTweener(typeof(FloatTweener), typeof(Single));

            var param0 = new PrivateObject(target);
            var accessor = new TweenSharkCore_Accessor(param0);

            Assert.AreEqual(2, accessor._registeredPropertyTweeners.Count);
            Assert.AreEqual(typeof(DoubleTweener), accessor._registeredPropertyTweeners[typeof(Double).FullName]);
            Assert.AreEqual(typeof(FloatTweener), accessor._registeredPropertyTweeners[typeof(Single).FullName]);
        }

        private TweenSharkCore SetupCoreWithTweens()
        {
            var core = new TweenSharkCore(new TweenSharkTickImpl());
            core.RegisterPropertyTweener(typeof(DoubleTweener), typeof(Double));
            core.RegisterPropertyTweener(typeof(FloatTweener), typeof(Single));

            // short tweens (one second)
            var duration = 1;
            var to = new TweeningTestObject { DoubleValue = 100, FloatValue = 100 };
            var tween = new TweenShark(to, duration, new TweenOps().PropTo("DoubleValue", 200));
            core.To(tween);
            tween = new TweenShark(to, duration, new TweenOps().PropTo("FloatValue", 200));
            core.To(tween);

            // medium duration tweens (3 seconds)
            duration = 3;
            to = new TweeningTestObject { DoubleValue = 100 };
            tween = new TweenShark(to, duration, new TweenOps().PropTo("DoubleValue", 200));
            core.To(tween);
            tween = new TweenShark(to, duration, new TweenOps().PropTo("FloatValue", 200));
            core.To(tween);

            // medium duration tweens (5 seconds)
            duration = 5;
            to = new TweeningTestObject { DoubleValue = 100 };
            tween = new TweenShark(to, duration, new TweenOps().PropTo("DoubleValue", 200));
            core.To(tween);
            tween = new TweenShark(to, duration, new TweenOps().PropTo("FloatValue", 200));
            core.To(tween);

            return core;
        }

        private void TestAllTweenedObjectsAreTicked(TweenSharkCore core)
        {
            var param0 = new PrivateObject(core);
            var accessor = new TweenSharkCore_Accessor(param0);

            accessor.Tick();
            // all 3 tweened objects must still be there
            Assert.AreEqual(3, core.GetObjects().Count);
            Assert.AreEqual(3, core.GetObjectsTweenedObjects().Count);

            System.Threading.Thread.Sleep(1500);
            
            accessor.Tick();
            // now the two fast tweens must be removed and only for are left
            Assert.AreEqual(2, core.GetObjects().Count);
            Assert.AreEqual(2, core.GetObjectsTweenedObjects().Count);

            System.Threading.Thread.Sleep(1500);

            accessor.Tick();
            // now the two medium tweens must be removed and only for are left
            Assert.AreEqual(1, core.GetObjects().Count);
            Assert.AreEqual(1, core.GetObjectsTweenedObjects().Count);

            System.Threading.Thread.Sleep(2000);

            accessor.Tick();
            // now all tweens must be removed and only for are left
            Assert.AreEqual(0, core.GetObjects().Count);
            Assert.AreEqual(0, core.GetObjectsTweenedObjects().Count);
        }

        /// <summary>
        ///Ein Test für "Tick"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void TickTest()
        {
            TestAllTweenedObjectsAreTicked(SetupCoreWithTweens());
        }

        /// <summary>
        ///Ein Test für "To"
        ///</summary>
        [TestMethod()]
        public void ToTest()
        {
            var core = SetupCoreWithTweens();

            Assert.AreEqual(3, core.GetObjects().Count);
            Assert.AreEqual(3, core.GetObjectsTweenedObjects().Count);
        }
    }
}
