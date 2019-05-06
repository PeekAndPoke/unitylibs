using De.Kjg.TweenSharkPkg.Tweening.Accessor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using TweenSharkTest.MockObjects;

namespace TweenSharkTest.Tweening.Accessor
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "FieldAccessorTest" und soll
    ///alle FieldAccessorTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class FieldAccessorTest
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
        ///Ein Test für "FieldAccessor`1-Konstruktor"
        ///</summary>
        public void FieldAccessorConstructorTestHelper<TValueType>()
        {
            var obj = new TweeningTestObject();
            FieldInfo fieldInfo = obj.GetType().GetField("GenericValue");
            var target = new FieldAccessor<TValueType>(obj, fieldInfo);
        }

        [TestMethod()]
        public void FieldAccessorConstructorTest()
        {
            FieldAccessorConstructorTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Ein Test für "GetValue"
        ///</summary>
        public void GetValueTestHelper<TValueType>()
        {
            var obj = new TweeningTestObject();
            var fieldInfo = obj.GetType().GetField("GenericValue");
            var target = new FieldAccessor<TValueType>(obj, fieldInfo);

            var expected = default(TValueType);
            var actual = target.GetValue();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetValueTest()
        {
            GetValueTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Ein Test für "SetValue"
        ///</summary>
        public void SetValueTestHelper<TValueType>()
        {
            var obj = new TweeningTestObject();
            var fieldInfo = obj.GetType().GetField("GenericValue");
            var target = new FieldAccessor<TValueType>(obj, fieldInfo);

            const int containedValue = 100;
            var value = (TValueType)Convert.ChangeType(new GenericParameterHelper(containedValue), typeof(TValueType));
            target.SetValue(value);
            var expected = (TValueType)Convert.ChangeType(obj.GenericValue, typeof(TValueType));
            Assert.AreEqual(expected, value);
            Assert.AreEqual(obj.GenericValue.Data, containedValue);
        }

        [TestMethod()]
        public void SetValueTest()
        {
            SetValueTestHelper<GenericParameterHelper>();
        }
    }
}
