using De.Kjg.TweenSharkPkg.Tweening.Accessor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TweenSharkTest.MockObjects;

namespace TweenSharkTest.Tweening.Accessor
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "PropertyAccessorTest" und soll
    ///alle PropertyAccessorTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class PropertyAccessorTest
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
        ///Ein Test für "PropertyAccessor`1-Konstruktor"
        ///</summary>
        public void PropertyAccessorConstructorTestHelper<TValueType>()
        {
            var obj = new TweeningTestObject();
            var propertyInfo = obj.GetType().GetProperty("GenericValue");
            var target = new PropertyAccessor<TValueType>(obj, propertyInfo);
        }

        [TestMethod()]
        public void PropertyAccessorConstructorTest()
        {
            PropertyAccessorConstructorTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Ein Test für "GetValue"
        ///</summary>
        public void GetValueTestHelper<TValueType>()
        {
            var obj = new TweeningTestObject();
            var propertyInfo = obj.GetType().GetProperty("GenericProperty");
            var target = new PropertyAccessor<TValueType>(obj, propertyInfo);

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
            var propertyInfo = obj.GetType().GetProperty("GenericProperty");
            var target = new PropertyAccessor<TValueType>(obj, propertyInfo);

            const int containedValue = 100;
            var value = (TValueType) Convert.ChangeType(new GenericParameterHelper(containedValue), typeof(TValueType));
            target.SetValue(value);
            var expected = (TValueType) Convert.ChangeType(obj.GenericProperty, typeof(TValueType));
            Assert.AreEqual(expected, value);
            Assert.AreEqual(obj.GenericProperty.Data, containedValue);
        }

        [TestMethod()]
        public void SetValueTest()
        {
            SetValueTestHelper<GenericParameterHelper>();
        }
    }
}
