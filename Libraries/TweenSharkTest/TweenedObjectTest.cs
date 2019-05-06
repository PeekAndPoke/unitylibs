using System.Linq;
using De.Kjg.TweenSharkPkg;
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
    ///Dies ist eine Testklasse für "TweenedObjectTest" und soll
    ///alle TweenedObjectTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class TweenedObjectTest
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
        ///Ein Test für "TweenedObject-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void TweenedObjectConstructorTest()
        {
            var obj = new TweeningTestObject(); 
            var registeredPropertyTweens = new Dictionary<string, Type>();
            var target = new TweenedObject(obj, registeredPropertyTweens); 
            
            Assert.AreSame(obj, target.Obj);
            Assert.AreSame(registeredPropertyTweens, target.RegisteredPropertyTweens);
        }

        /// <summary>
        ///Ein Test für "AddTweenShark"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void AddTweenSharkTest()
        {
            Assert.Inconclusive("needs to be rewritten to prevent runtime errors");

            var obj = new TweeningTestObject();
            var registeredPropertyTweens = new Dictionary<string, Type>();
            registeredPropertyTweens.Add(typeof(SByte).FullName, typeof(SignedByteTweener));

            var target = new TweenedObject(obj, registeredPropertyTweens);
            var param0 = new PrivateObject(target);
            var accessor = new TweenedObject_Accessor(param0);

            var tweenShark = new TweenShark(obj, 1, new TweenOps().PropTo("DoubleValue", 100).PropTo("FloatValue", 101));
            target.AddTweenShark(tweenShark);


            // check for count of tweens and tweened properties
            Assert.AreEqual(1, accessor._tweens.Count);
            Assert.AreEqual(2, accessor._propertyTweens.Count);
            // check for target values
            Assert.AreEqual(100, ((DoubleTweener) (accessor._propertyTweens["DoubleValue"])).GetTargetValue());
            Assert.AreEqual(101, ((FloatTweener) (accessor._propertyTweens["FloatValue"])).GetTargetValue());

            // when adding a tween on another object the number of tweens must not change, because we do not add the tween
            tweenShark = new TweenShark(new TweeningTestObject(), 1, new TweenOps());
            target.AddTweenShark(tweenShark);
            // check for count of tweens and tweened properties
            Assert.AreEqual(1, accessor._tweens.Count);
            Assert.AreEqual(2, accessor._propertyTweens.Count);

            // when adding a tween on the correct object but with another property the numbers must change
            tweenShark = new TweenShark(obj, 1, new TweenOps().PropTo("IntValue", 102));
            target.AddTweenShark(tweenShark);
            // check for count of tweens and tweened properties
            Assert.AreEqual(2, accessor._tweens.Count);
            Assert.AreEqual(3, accessor._propertyTweens.Count);
            // check for target values
            Assert.AreEqual(100, ((DoubleTweener)(accessor._propertyTweens["DoubleValue"])).GetTargetValue());
            Assert.AreEqual(101, ((FloatTweener)(accessor._propertyTweens["FloatValue"])).GetTargetValue());
            Assert.AreEqual(102, ((SignedInt32Tweener)(accessor._propertyTweens["IntValue"])).GetTargetValue());

            // but when we now add another tween that overrides tweened properties, only the number of tweens may change
            tweenShark = new TweenShark(obj, 1, new TweenOps().PropTo("DoubleValue", 200).PropTo("FloatValue", 201).PropTo("IntValue", 202));
            target.AddTweenShark(tweenShark);
            // check for count of tweens and tweened properties
            Assert.AreEqual(3, accessor._tweens.Count);
            Assert.AreEqual(3, accessor._propertyTweens.Count);
            // check for target values
            Assert.AreEqual(200, ((DoubleTweener)(accessor._propertyTweens["DoubleValue"])).GetTargetValue());
            Assert.AreEqual(201, ((FloatTweener)(accessor._propertyTweens["FloatValue"])).GetTargetValue());
            Assert.AreEqual(202, ((SignedInt32Tweener)(accessor._propertyTweens["IntValue"])).GetTargetValue());
        }

        /// <summary>
        ///Ein Test für "CreateTweener"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void CreateTweenerTest()
        {
            var obj = new TweeningTestObject();
            var registeredPropertyTweens = new Dictionary<string, Type>();
            registeredPropertyTweens.Add(typeof(SByte).FullName, typeof(SignedByteTweener));

            var param0 = new PrivateObject(new TweenedObject(new TweeningTestObject(), registeredPropertyTweens));
            var target = new TweenedObject_Accessor(param0);

            // when we give a tweener we must get one returned
            ITweenSharkTweener tweener = target.CreateTweener(new PropertyOps("SbyteValue", 100, new GenericTweenerImpl<SByte>(), false));
            Assert.IsInstanceOfType(tweener, typeof(GenericTweenerImpl<SByte>));

            // when we dont give a tweener CreateTweener will try to create it
            tweener = target.CreateTweener(new PropertyOps("SbyteValue", 100, false));
            Assert.IsInstanceOfType(tweener, typeof(SignedByteTweener));
        }

        /// <summary>
        ///Ein Test für "CreateTweenerWithAccessor"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void CreateTweenerWithAccessorTest()
        {
            var obj = new TweeningTestObject();
            var registeredPropertyTweens = new Dictionary<string, Type>();
            // register tweener for ints
            registeredPropertyTweens.Add(typeof(SByte).FullName, typeof(SignedByteTweener));
            registeredPropertyTweens.Add(typeof(Int16).FullName, typeof(SignedInt16Tweener));
            registeredPropertyTweens.Add(typeof(Int32).FullName, typeof(SignedInt32Tweener));
            registeredPropertyTweens.Add(typeof(Int64).FullName, typeof(SignedInt64Tweener));
            // register tweener for unsigned ints
            registeredPropertyTweens.Add(typeof(Byte).FullName, typeof(UnsignedByteTweener));
            registeredPropertyTweens.Add(typeof(UInt16).FullName, typeof(UnsignedInt16Tweener));
            registeredPropertyTweens.Add(typeof(UInt32).FullName, typeof(UnsignedInt32Tweener));
            registeredPropertyTweens.Add(typeof(UInt64).FullName, typeof(UnsignedInt64Tweener));
            // register tweener for floats
            registeredPropertyTweens.Add(typeof(Single).FullName, typeof(FloatTweener));
            // register tweener for doubles
            registeredPropertyTweens.Add(typeof(Double).FullName, typeof(DoubleTweener));


            var param0 = new PrivateObject(new TweenedObject(new TweeningTestObject(), registeredPropertyTweens));
            var target = new TweenedObject_Accessor(param0);

            ITweenSharkTweener tweener = target.CreateTweener(new PropertyOps("SbyteValue", 100, false));
            Assert.IsInstanceOfType(tweener, typeof(SignedByteTweener));

            tweener = target.CreateTweener(new PropertyOps("ShortValue", 100, false));
            Assert.IsInstanceOfType(tweener, typeof(SignedInt16Tweener));

            tweener = target.CreateTweener(new PropertyOps("IntValue", 100, false));
            Assert.IsInstanceOfType(tweener, typeof(SignedInt32Tweener));

            tweener = target.CreateTweener(new PropertyOps("LongValue", 100, false));
            Assert.IsInstanceOfType(tweener, typeof(SignedInt64Tweener));

            tweener = target.CreateTweener(new PropertyOps("ByteValue", 100, false));
            Assert.IsInstanceOfType(tweener, typeof(UnsignedByteTweener));

            tweener = target.CreateTweener(new PropertyOps("UshortValue", 100, false));
            Assert.IsInstanceOfType(tweener, typeof(UnsignedInt16Tweener));

            tweener = target.CreateTweener(new PropertyOps("UintValue", 100, false));
            Assert.IsInstanceOfType(tweener, typeof(UnsignedInt32Tweener));

            tweener = target.CreateTweener(new PropertyOps("UlongValue", 100, false));
            Assert.IsInstanceOfType(tweener, typeof(UnsignedInt64Tweener));

            tweener = target.CreateTweener(new PropertyOps("DoubleValue", 100, false));
            Assert.IsInstanceOfType(tweener, typeof(DoubleTweener));

            tweener = target.CreateTweener(new PropertyOps("FloatValue", 100, false));
            Assert.IsInstanceOfType(tweener, typeof(FloatTweener));
        }

        /// <summary>
        ///Ein Test für "Tick"
        ///</summary>
        [TestMethod()]
        public void TickTest()
        {
            TestSimpleTickScenario();
        }

        /// <summary>
        /// We are testing three tweens, that endure 1, 3 and 5 seconds. Ever Tween has onStart, onComplete, onUpdate callbacks set.
        /// To ensure that ticks is working the way it should we count how oftern the callbacks are called for each Tweens.
        /// In the end we check if the the values where tweened correctly.
        /// </summary>
        private void TestSimpleTickScenario() 
        {
            var obj = new TweeningTestObject();
            var registeredPropertyTweens = new Dictionary<string, Type>();
            // register tweener for ints
            registeredPropertyTweens.Add(typeof(SByte).FullName, typeof(SignedByteTweener));
            registeredPropertyTweens.Add(typeof(Int16).FullName, typeof(SignedInt16Tweener));
            registeredPropertyTweens.Add(typeof(Int32).FullName, typeof(SignedInt32Tweener));
            registeredPropertyTweens.Add(typeof(Int64).FullName, typeof(SignedInt64Tweener));
            // register tweener for unsigned ints
            registeredPropertyTweens.Add(typeof(Byte).FullName, typeof(UnsignedByteTweener));
            registeredPropertyTweens.Add(typeof(UInt16).FullName, typeof(UnsignedInt16Tweener));
            registeredPropertyTweens.Add(typeof(UInt32).FullName, typeof(UnsignedInt32Tweener));
            registeredPropertyTweens.Add(typeof(UInt64).FullName, typeof(UnsignedInt64Tweener));
            // register tweener for floats
            registeredPropertyTweens.Add(typeof(Single).FullName, typeof(FloatTweener));
            // register tweener for doubles
            registeredPropertyTweens.Add(typeof(Double).FullName, typeof(DoubleTweener));

            var target = new TweenedObject(obj, registeredPropertyTweens); // TODO: Passenden Wert initialisieren

            var onStartTweens = new Dictionary<TweenShark, int>();
            TweenSharkCallback onStart = tween => onStartTweens[tween]++;

            var onUpdateTweens = new Dictionary<TweenShark, int>();
            TweenSharkCallback onUpdate = tween => onUpdateTweens[tween]++;

            var onCompleteTweens = new Dictionary<TweenShark, int>();
            TweenSharkCallback onComplete = tween => onCompleteTweens[tween]++;

            // first tween takes ONE second
            var tween1 = new TweenShark(obj, 1, new TweenOps()
                .PropTo("DoubleValue", 100).PropTo("FloatValue", 200)
                .OnStart(onStart).OnUpdate(onUpdate).OnComplete(onComplete));
            onStartTweens[tween1] = 0;
            onUpdateTweens[tween1] = 0;
            onCompleteTweens[tween1] = 0;
            target.AddTweenShark(tween1);

            // second tween takes THREE seconds
            var tween2 = new TweenShark(obj, 3, new TweenOps()
                .PropTo("IntValue", 300).PropTo("UintValue", 400)
                .OnStart(onStart).OnUpdate(onUpdate).OnComplete(onComplete));
            onStartTweens[tween2] = 0;
            onUpdateTweens[tween2] = 0;
            onCompleteTweens[tween2] = 0;
            target.AddTweenShark(tween2);

            // third tween takes FIVE seconds
            var tween3 = new TweenShark(obj, 5, new TweenOps()
                .PropTo("LongValue", 500).PropTo("UlongValue", 600)
                .OnStart(onStart).OnUpdate(onUpdate).OnComplete(onComplete));
            onStartTweens[tween3] = 0;
            onUpdateTweens[tween3] = 0;
            onCompleteTweens[tween3] = 0;
            target.AddTweenShark(tween3);

            //////////////////////////////////////////////////////////////////////////////////////////
            // do one tick now
            long currentTicks = DateTime.Now.Ticks;
            bool actual = target.Tick(currentTicks);
            Assert.AreEqual(true, actual);

            // oStart must be called 3 times now, each one time
            Assert.AreEqual(3, onStartTweens.Values.Sum());
            Assert.AreEqual(1, onStartTweens[tween1]);
            Assert.AreEqual(1, onStartTweens[tween2]);
            Assert.AreEqual(1, onStartTweens[tween3]);
            // onUpdate must also be called that often
            Assert.AreEqual(3, onUpdateTweens.Values.Sum());
            Assert.AreEqual(1, onUpdateTweens[tween1]);
            Assert.AreEqual(1, onUpdateTweens[tween2]);
            Assert.AreEqual(1, onUpdateTweens[tween3]);
            // onComplete must not have been called yet
            Assert.AreEqual(0, onCompleteTweens.Values.Sum());
            Assert.AreEqual(0, onCompleteTweens[tween1]);
            Assert.AreEqual(0, onCompleteTweens[tween2]);
            Assert.AreEqual(0, onCompleteTweens[tween3]);

            //////////////////////////////////////////////////////////////////////////////////////////
            System.Threading.Thread.Sleep(200);
            //////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////
            // do one tick now
            currentTicks = DateTime.Now.Ticks;
            actual = target.Tick(currentTicks);
            Assert.AreEqual(true, actual);

            // oStart must not be changed
            Assert.AreEqual(3, onStartTweens.Values.Sum());
            Assert.AreEqual(1, onStartTweens[tween1]);
            Assert.AreEqual(1, onStartTweens[tween2]);
            Assert.AreEqual(1, onStartTweens[tween3]);
            // onUpdate must be called again for every tween
            Assert.AreEqual(3 + 3, onUpdateTweens.Values.Sum());
            Assert.AreEqual(1 + 1, onUpdateTweens[tween1]);
            Assert.AreEqual(1 + 1, onUpdateTweens[tween2]);
            Assert.AreEqual(1 + 1, onUpdateTweens[tween3]);
            // onComplete must not have been called yet
            Assert.AreEqual(0, onCompleteTweens.Values.Sum());
            Assert.AreEqual(0, onCompleteTweens[tween1]);
            Assert.AreEqual(0, onCompleteTweens[tween2]);
            Assert.AreEqual(0, onCompleteTweens[tween3]);

            //////////////////////////////////////////////////////////////////////////////////////////
            System.Threading.Thread.Sleep(1000);
            //////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////
            // do one tick now
            currentTicks = DateTime.Now.Ticks;
            actual = target.Tick(currentTicks);
            Assert.AreEqual(true, actual);

            // oStart must not be changed
            Assert.AreEqual(3, onStartTweens.Values.Sum());
            Assert.AreEqual(1, onStartTweens[tween1]);
            Assert.AreEqual(1, onStartTweens[tween2]);
            Assert.AreEqual(1, onStartTweens[tween3]);
            // onUpdate must be called again for every tween
            Assert.AreEqual(3 + 3 + 3, onUpdateTweens.Values.Sum());
            Assert.AreEqual(1 + 1 + 1, onUpdateTweens[tween1]);
            Assert.AreEqual(1 + 1 + 1, onUpdateTweens[tween2]);
            Assert.AreEqual(1 + 1 + 1, onUpdateTweens[tween3]);
            // onComplete be called for the first and second tween
            Assert.AreEqual(1, onCompleteTweens.Values.Sum());
            Assert.AreEqual(1, onCompleteTweens[tween1]);
            Assert.AreEqual(0, onCompleteTweens[tween2]);
            Assert.AreEqual(0, onCompleteTweens[tween3]);

            //////////////////////////////////////////////////////////////////////////////////////////
            System.Threading.Thread.Sleep(2000);
            //////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////
            // do one tick now
            currentTicks = DateTime.Now.Ticks;
            actual = target.Tick(currentTicks);
            Assert.AreEqual(true, actual);

            // oStart must not be changed
            Assert.AreEqual(3, onStartTweens.Values.Sum());
            Assert.AreEqual(1, onStartTweens[tween1]);
            Assert.AreEqual(1, onStartTweens[tween2]);
            Assert.AreEqual(1, onStartTweens[tween3]);
            // onUpdate must be called again for every tween, but the first one
            Assert.AreEqual(3 + 3 + 3 + 2,  onUpdateTweens.Values.Sum());
            Assert.AreEqual(1 + 1 + 1,      onUpdateTweens[tween1]);
            Assert.AreEqual(1 + 1 + 1 + 1,  onUpdateTweens[tween2]);
            Assert.AreEqual(1 + 1 + 1 + 1,  onUpdateTweens[tween3]);
            // onComplete be called for all tweens
            Assert.AreEqual(2, onCompleteTweens.Values.Sum());
            Assert.AreEqual(1, onCompleteTweens[tween1]);
            Assert.AreEqual(1, onCompleteTweens[tween2]);
            Assert.AreEqual(0, onCompleteTweens[tween3]);

            //////////////////////////////////////////////////////////////////////////////////////////
            System.Threading.Thread.Sleep(2000);
            //////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////
            // do one tick now
            currentTicks = DateTime.Now.Ticks;
            actual = target.Tick(currentTicks);
            // there is no pending tween left, so we expect false as return value of Tick() 
            Assert.AreEqual(false, actual);

            // oStart must not be changed
            Assert.AreEqual(3, onStartTweens.Values.Sum());
            Assert.AreEqual(1, onStartTweens[tween1]);
            Assert.AreEqual(1, onStartTweens[tween2]);
            Assert.AreEqual(1, onStartTweens[tween3]);
            // onUpdate must be called again for every tween, but the first and second one
            Assert.AreEqual(3 + 3 + 3 + 2 + 1,  onUpdateTweens.Values.Sum());
            Assert.AreEqual(1 + 1 + 1,          onUpdateTweens[tween1]);
            Assert.AreEqual(1 + 1 + 1 + 1,      onUpdateTweens[tween2]);
            Assert.AreEqual(1 + 1 + 1 + 1 + 1,  onUpdateTweens[tween3]);
            // onComplete be called for all tweens
            Assert.AreEqual(3, onCompleteTweens.Values.Sum());
            Assert.AreEqual(1, onCompleteTweens[tween1]);
            Assert.AreEqual(1, onCompleteTweens[tween2]);
            Assert.AreEqual(1, onCompleteTweens[tween3]);

            //////////////////////////////////////////////////////////////////////////////////////////
            // test the results
            Assert.AreEqual(obj.DoubleValue, 100);
            Assert.AreEqual(obj.FloatValue, 200);
            Assert.AreEqual(obj.IntValue, 300);
            Assert.AreEqual(obj.UintValue, 400U);
            Assert.AreEqual(obj.LongValue, 500L);
            Assert.AreEqual(obj.UlongValue, 600UL);

            //////////////////////////////////////////////////////////////////////////////////////////
            System.Threading.Thread.Sleep(1000);
            //////////////////////////////////////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////////////////////////////////
            // the last tick... nothing can change, since there is no tween left
            currentTicks = DateTime.Now.Ticks;
            actual = target.Tick(currentTicks);
            // there is no pending tween left, so we expect false as return value of Tick() 
            Assert.AreEqual(false, actual);

            // oStart must not be changed
            Assert.AreEqual(3, onStartTweens.Values.Sum());
            Assert.AreEqual(1, onStartTweens[tween1]);
            Assert.AreEqual(1, onStartTweens[tween2]);
            Assert.AreEqual(1, onStartTweens[tween3]);
            // onUpdate must not be changed
            Assert.AreEqual(3 + 3 + 3 + 2 + 1, onUpdateTweens.Values.Sum());
            Assert.AreEqual(1 + 1 + 1, onUpdateTweens[tween1]);
            Assert.AreEqual(1 + 1 + 1 + 1, onUpdateTweens[tween2]);
            Assert.AreEqual(1 + 1 + 1 + 1 + 1, onUpdateTweens[tween3]);
            // onUpdate must not be changed
            Assert.AreEqual(3, onCompleteTweens.Values.Sum());
            Assert.AreEqual(1, onCompleteTweens[tween1]);
            Assert.AreEqual(1, onCompleteTweens[tween2]);
            Assert.AreEqual(1, onCompleteTweens[tween3]);
        }
    }
}
