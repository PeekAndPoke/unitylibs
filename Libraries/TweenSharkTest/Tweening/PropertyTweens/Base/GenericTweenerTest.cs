using System;
using De.Kjg.TweenSharkPkg.Options;
using De.Kjg.TweenSharkPkg.Tweening.Accessor;
using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TweenSharkTest.MockObjects;

namespace TweenSharkTest.Tweening.PropertyTweens.Base
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "GenericTweenerTest" und soll
    ///alle GenericTweenerTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class GenericTweenerTest
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
        ///Ein Test für "Create"
        ///</summary>
        public void CreateTestHelper<TValueType>()
        {
            var target = CreateGenericTweener<TValueType>();
            var obj = new TweeningTestObject();
            const string propertyName = "GenericValue";
            const int targetValueContained = 100;
            var targetValue = new GenericParameterHelper(targetValueContained);
            const bool isRelative = true;
            var propOps = new PropertyOps(propertyName, targetValue, isRelative);
            target.Create(obj, propOps);

            PrivateObject param0 = new PrivateObject(target);
            GenericTweener_Accessor<TValueType> accessor = new GenericTweener_Accessor<TValueType>(param0); // TODO: Passenden Wert initialisieren


//            Assert.AreEqual(propertyName, accessor.PropertyName);
//            Assert.AreEqual(targetValue, accessor.TargetValue);
//            Assert.AreEqual(targetValueContained, ((GenericParameterHelper) accessor.TargetValue).Data);
//            Assert.AreEqual(isRelative, accessor.IsRelative);
//            Assert.AreEqual(createAccessor, accessor.CreateAccessor);
        }

        internal virtual GenericTweener<TValueType> CreateGenericTweener<TValueType>()
        {
            GenericTweener<TValueType> target = new GenericTweenerImpl<TValueType>();
            return target;
        }

        [TestMethod()]
        public void CreateTest()
        {
            CreateTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Ein Test für "CreateAccessor"
        ///</summary>
        public void CreateAccessorTestHelper()
        {
            var tweener = new GenericTweenerImpl<int>();
            PrivateObject param0 = new PrivateObject(tweener, new PrivateType(typeof(GenericTweener<int>)));
            var target = new GenericTweener_Accessor<int>(param0);
            var obj = new TweeningTestObject();
            
            // test creation of field accessor
            var propOps = new PropertyOps("IntValue", 0, false);
            target.CreateAccessor(obj, propOps);
            Console.WriteLine("t " + tweener.GetAccessor());
            Assert.IsInstanceOfType(
                tweener.GetAccessor(),
                typeof(FieldAccessor<int>)
            );

            // test creation of field accessor
            propOps = new PropertyOps("IntProperty", 0, false);
            target.CreateAccessor(obj, propOps);
            Console.WriteLine("t " + tweener.GetAccessor());
            Assert.IsInstanceOfType(
                tweener.GetAccessor(),
                typeof(PropertyAccessor<int>)
            );
        }

        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void CreateAccessorTest()
        {
            CreateAccessorTestHelper();
        }

        /// <summary>
        ///Ein Test für "GetValue"
        ///</summary>
        public void GetValueTestHelper()
        {
            var tweener = new GenericTweenerImpl<int>();
            PrivateObject param0 = new PrivateObject(tweener, new PrivateType(typeof(GenericTweener<int>)));
            var target = new GenericTweener_Accessor<int>(param0);
            var obj = new TweeningTestObject() {IntValue = 100, IntProperty = 200};

            var propOps = new PropertyOps("IntValue", 0, false);
            target.CreateAccessor(obj, propOps);
            int actual = target.GetValue();
            Assert.AreEqual(100, actual);

            propOps = new PropertyOps("IntProperty", 0, false);
            target.CreateAccessor(obj, propOps);
            actual = target.GetValue();
            Assert.AreEqual(200, actual);
        }

        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void GetValueTest()
        {
            GetValueTestHelper();
        }

        /// <summary>
        ///Ein Test für "SetValue"
        ///</summary>
        public void SetValueTestHelper()
        {
            var tweener = new GenericTweenerImpl<int>();
            PrivateObject param0 = new PrivateObject(tweener, new PrivateType(typeof(GenericTweener<int>)));
            var target = new GenericTweener_Accessor<int>(param0);
            var obj = new TweeningTestObject() { IntValue = 100, IntProperty = 200 };

            var propOps = new PropertyOps("IntValue", 0, false);
            target.CreateAccessor(obj, propOps);
            target.SetValue(300);
            int actual = target.GetValue();
            Assert.AreEqual(300, actual);

            propOps = new PropertyOps("IntProperty", 0, false);
            target.CreateAccessor(obj, propOps);
            target.SetValue(400);
            actual = target.GetValue();
            Assert.AreEqual(400, actual);
        }

        [TestMethod()]
        [DeploymentItem("TweenShark.dll")]
        public void SetValueTest()
        {
            SetValueTestHelper();
        }
    }
}
