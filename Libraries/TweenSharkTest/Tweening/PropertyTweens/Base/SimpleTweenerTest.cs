using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Base;
using De.Kjg.TweenSharkPkg;
using De.Kjg.TweenSharkPkg.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TweenSharkTest.MockObjects;

namespace TweenSharkTest.Tweening.PropertyTweens.Base
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "SimpleTweenerTest" und soll
    ///alle SimpleTweenerTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class SimpleTweenerTest
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
        ///Ein Test für "AddValues"
        ///</summary>
        public void AddValuesTestHelper<TValueType>()
        {
        }

        private SimpleTweenerImpl<TValueType> CreateSimpleTweener<TValueType>()
        {
            return new SimpleTweenerImpl<TValueType>();
        }

        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void AddValuesTest()
        {
            AddValuesTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Ein Test für "CalculateAndSetValue"
        ///</summary>
        public void CalculateAndSetValueTestHelper<TValueType>()
        {
           // cannot test abstract method
        }

        [TestMethod()]
        public void CalculateAndSetValueTest()
        {
            CalculateAndSetValueTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Ein Test für "CalculateStartValue"
        ///</summary>
        public void CalculateStartValueTestHelper()
        {
            // test without given start value in property ops
            var tweener = new SimpleTweenerImpl<int>();
            var param0 = new PrivateObject(tweener);
            var target = new SimpleTweener_Accessor<int>(param0);

            tweener.Value = 100;
            tweener.Create(null, new PropertyOps("SomeName", 200, false));
            int expected = 100;
            int actual = target.CalculateStartValue();
            Assert.AreEqual(expected, actual);

            // test WITH given start value in property ops
            tweener = new SimpleTweenerImpl<int>();
            param0 = new PrivateObject(tweener);
            target = new SimpleTweener_Accessor<int>(param0);

            tweener.Value = 100;
            tweener.Create(null, new PropertyOps("SomeName", 200, false).Start(200));
            expected = 200;
            actual = target.CalculateStartValue();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void CalculateStartValueTest()
        {
            CalculateStartValueTestHelper();
        }

        /// <summary>
        ///Ein Test für "CalculateTargetValue"
        ///</summary>
        public void CalculateTargetValueTestHelper()
        {
            // test for absolute tween
            var tweener = new SimpleTweenerImpl<int>();
            var param0 = new PrivateObject(tweener);
            var target = new SimpleTweener_Accessor<int>(param0);

            var obj = new TweeningTestObject();
            tweener.Create(obj, new PropertyOps("SomeValue", 200, false));
            tweener.Value = 100;
            int expected = 200;
            int actual = target.CalculateTargetValue();
            Assert.AreEqual(expected, actual);

            // test for relative tween
            tweener = new SimpleTweenerImpl<int>();
            param0 = new PrivateObject(tweener);
            target = new SimpleTweener_Accessor<int>(param0);

            obj = new TweeningTestObject();
            tweener.Create(obj, new PropertyOps("SomeValue", 200, true));
            tweener.Value = 100;
            expected = 300;
            actual = target.CalculateTargetValue();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void CalculateTargetValueTest()
        {
            CalculateTargetValueTestHelper();
        }

        /// <summary>
        ///Ein Test für "CastSafe"
        ///</summary>
        public void CastSafeTestHelper<TValueType>()
        {
            var param0 = new PrivateObject(new SimpleTweenerImpl<TValueType>());
            var target = new SimpleTweener_Accessor<TValueType>(param0);
            object val = default(TValueType);
            TValueType expected = default(TValueType);
            TValueType actual;
            actual = target.CastSafe(val);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void CastSafeTest()
        {
            CastSafeTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Ein Test für "Create"
        ///</summary>
        public void CreateTestHelper<TValueType>()
        {
            var target = CreateSimpleTweener<TValueType>();
            var obj = new TweeningTestObject();
            const string propertyName = "GenericValue";
            const int targetValueContained = 100;
            var targetValue = new GenericParameterHelper(targetValueContained);
            const bool isRelative = true;
            var propOps = new PropertyOps(propertyName, targetValue, isRelative);
            target.Create(obj, propOps);

            var param0 = new PrivateObject(target);
            var accessor = new SimpleTweener_Accessor<TValueType>(param0);

            Assert.AreEqual(propertyName, accessor.PropOps.PropertyName);
            Assert.AreEqual(targetValue, accessor.PropOps.TargetValue);
            Assert.AreEqual(targetValueContained, ((GenericParameterHelper)accessor.PropOps.TargetValue).Data);
            Assert.AreEqual(isRelative, accessor.PropOps.IsRelative);
        }

        [TestMethod()]
        public void CreateTest()
        {
            CreateTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Ein Test für "Ease"
        ///</summary>
        public void EaseTestHelper<TValueType>()
        {
            var target = new SimpleTweenerImpl<TValueType>();
            var obj = new TweeningTestObject();
            var propOps = new PropertyOps("FloatValue", 100, false).Ease(Ease.Linear);
            target.Create(obj, propOps);

            var param0 = new PrivateObject(target);
            var accessor = new SimpleTweener_Accessor<TValueType>(param0);

            // assert that only the EaseFunc is set and not EaseEx
            Assert.IsNotNull(accessor.EaseFunc);
            Assert.IsNull(accessor.EaseExFunc);
            Assert.IsNull(accessor.EaseExParams);

            var startValue = 100F;
            var deltaValue = 200F;

            var actual = accessor.Ease(0F, startValue, deltaValue);
            Assert.AreEqual(100, actual);

            actual = accessor.Ease(1F, startValue, deltaValue);
            Assert.AreEqual(300, actual);
        }

        /// <summary>
        ///Ein Test für "Ease"
        ///</summary>
        public void EaseTestHelper2<TValueType>()
        {
            var target = new SimpleTweenerImpl<TValueType>();
            var obj = new TweeningTestObject();
            var propOps = new PropertyOps("FloatValue", 100, false).EaseEx(EaseEx.InElastic, new object[] { 0.3F, 0.3F });
            target.Create(obj, propOps);

            var param0 = new PrivateObject(target);
            var accessor = new SimpleTweener_Accessor<TValueType>(param0);

            // assert that only the EaseFunc is set and not EaseEx
            Assert.IsNull(accessor.EaseFunc);
            Assert.IsNotNull(accessor.EaseExFunc);
            Assert.IsNotNull(accessor.EaseExParams);

            var startValue = 100F;
            var deltaValue = 200F;

            Console.WriteLine("ret " + accessor.Ease(0F, startValue, deltaValue).GetType());
            var actual = accessor.Ease(0F, startValue, deltaValue);
            Assert.AreEqual(100, actual);

            actual = accessor.Ease(1F, startValue, deltaValue);
            Assert.AreEqual(300, actual);
        }

        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void EaseTest()
        {
            EaseTestHelper<float>();
            EaseTestHelper2<float>();
        }

        /// <summary>
        ///Ein Test für "GetFullPropertyName"
        ///</summary>
        public void GetFullPropertyNameTestHelper<TValueType>()
        {
            var target = new SimpleTweenerImplWithSubPropertyName<TValueType>();
            var obj = new TweeningTestObject();
            var propOps = new PropertyOps("FloatValue", 100, false);
            target.Create(obj, propOps);
            string actual = target.GetFullPropertyName();
            const string expected = "FloatValue_sub";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetFullPropertyNameTest()
        {
            GetFullPropertyNameTestHelper<float>();
        }

        /// <summary>
        ///Ein Test für "GetSubPropertyName"
        ///</summary>
        public void GetSubPropertyNameTestHelper<TValueType>()
        {
            var target = new SimpleTweenerImpl<TValueType>();
            var obj = new TweeningTestObject();
            var propOps = new PropertyOps("FloatValue", 100, false);
            target.Create(obj, propOps);
            string actual = target.GetSubPropertyName();
            const string expected = "";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetSubPropertyNameTest()
        {
            GetSubPropertyNameTestHelper<float>();
        }

        /// <summary>
        ///Ein Test für "GetTweenedObject"
        ///</summary>
        public void GetTweenedObjectTestHelper<TValueType>()
        {
            var tweener = new SimpleTweenerImpl<TValueType>();
            PrivateObject param0 = new PrivateObject(tweener);
            SimpleTweener_Accessor<TValueType> target = new SimpleTweener_Accessor<TValueType>(param0);
            var expected = new TweeningTestObject();
            tweener.Create(expected, new PropertyOps("IntValue", 100, false));
            TweeningTestObject actual;
            actual = target.GetTweenedObject<TweeningTestObject>();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void GetTweenedObjectTest()
        {
            GetTweenedObjectTestHelper<float>();
        }

        /// <summary>
        ///Ein Test für "Init"
        ///</summary>
        public void InitTestHelper<TValueType>()
        {
            SimpleTweenerImpl<TValueType> target = CreateSimpleTweener<TValueType>(); // TODO: Passenden Wert initialisieren
            target.Init();
            // init does nothing... it is just a virtual base method
        }

        [TestMethod()]
        public void InitTest()
        {
            InitTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Ein Test für "Setup"
        ///</summary>
        public void SetupTestHelperAbsoluteTweening()
        {
            var obj = new TweeningTestObject();
            SimpleTweenerImpl<int> target = CreateSimpleTweener<int>();
            target.Value = 100;
            // Create Calls Setup() and Init()
            target.Create(obj, new PropertyOps("SomeName", 200, false));
            // after setup start and target value must be set on the tweener

            PrivateObject param0 = new PrivateObject(target);
            SimpleTweener_Accessor<int> accessor = new SimpleTweener_Accessor<int>(param0);

            Assert.AreEqual(100, accessor.StartValue);
            Assert.AreEqual(200, accessor.TargetValue);
        }

        [TestMethod()]
        public void SetupTest()
        {
            SetupTestHelperAbsoluteTweening();
        }
    }
}
