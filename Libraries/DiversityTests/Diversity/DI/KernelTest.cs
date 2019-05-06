using De.Kjg.Diversity.Impl.DI;
using NUnit.Framework;

namespace De.Kjg.Diversity.DI
{
    /// <summary>
    /// This test suite pretty much test all the functionality that DI provides by now.
    /// These test can be seen more like an integration test.
    /// </summary>
    [TestFixture]
    class KernelTest
    {
        /// <summary>
        /// Test creation of registered binding that always creates new instances.
        /// </summary>
        [Test]
        public void NewInstanceInjectionTest()
        {
            var kernel = new DependencyInjectionKernel(new NewInstanceCreationDependencyInjectionContainer());

            var object1 = kernel.Get<ISomeInterface>();
            object1.SetText("first text");
            var object2 = kernel.Get<ISomeInterface>();
            object2.SetText("second text");

            Assert.AreNotSame(object1, object2, "The two objects must no be the same, there must be a new instance created for each of them.");
            Assert.IsInstanceOf<SomeClass>(object1, "The object should be of type SomeClass");
            Assert.IsInstanceOf<SomeClass>(object2, "The object should be of type SomeClass");
            Assert.AreEqual("first text", object1.GetText(), "The object should contain 'first text'");
            Assert.AreEqual("second text", object2.GetText(), "The object should contain 'second text'");
        }

        /// <summary>
        /// Test creation of registered binding that always returns the same instance of an object.
        /// </summary>
        [Test]
        public void SingletonInjectionTest()
        {
            var kernel = new DependencyInjectionKernel(new SingletonCreationDependencyInjectionContainer());

            var object1 = kernel.Get<ISomeInterface>();
            object1.SetText("first text");
            var object2 = kernel.Get<ISomeInterface>();
            object2.SetText("second text");

            Assert.AreSame(object1, object2, "The two object must be the same due to singleton injection");
            Assert.IsInstanceOf<SomeClass>(object1, "The object should be of type SomeClass");
            Assert.IsInstanceOf<SomeClass>(object2, "The object should be of type SomeClass");
            Assert.AreEqual("second text", object1.GetText(), "The object should contain 'second text'");
            Assert.AreEqual("second text", object2.GetText(), "The object should contain 'second text'");
        }

        /// <summary>
        /// This test tries to get an instance of an object that has not be registered by a binding
        /// </summary>
        [Test]
        public void GettingUnregisteredInstance()
        {
            var kernel = new DependencyInjectionKernel(new DependencyInjectionContainer()); // create a dependencyInjectionKernel with a DependencyInjectionContainer which has no bindings

            var obj = kernel.Get<SomeClass>();

            Assert.NotNull(obj, "The object must not be null");
            Assert.IsInstanceOf<SomeClass>(obj, "The object must be of type SomeClass");
        }

        /// <summary>
        /// Test constructor-, field- and property injection.
        /// </summary>
        [Test]
        public void InjectionTest()
        {
            var kernel = new DependencyInjectionKernel(new DependencyInjectionContainer()); // we dont need bindings to test the injection

            var obj = kernel.Get<ClassWithInjects>();

            Assert.NotNull(obj, "The object must not be null");
            Assert.IsInstanceOf<SomeClass>(obj.One,     "The constructor injected member 'One' must be of type SomeClass");
            Assert.IsInstanceOf<SomeClass2>(obj.Two,    "The constructor injected member 'Two' must be of type SomeClass2");
            Assert.IsInstanceOf<SomeClass>(obj.Three,   "The field injected member 'Three' must be of type SomeClass");
            Assert.IsInstanceOf<SomeClass2>(obj.Four,   "The property injected member 'Four' must be of type SomeClass2");
        }
    }

    #region classes needed for tests

    internal class NewInstanceCreationDependencyInjectionContainer : DependencyInjectionContainer
    {
        public override void Load()
        {
            Bind<ISomeInterface>().To<SomeClass>();
            // the second binding of ISomeInterface should not be used (only the first one will
            Bind<ISomeInterface>().To<SomeClass2>();
        }
    }

    internal class SingletonCreationDependencyInjectionContainer : DependencyInjectionContainer
    {
        public override void Load()
        {
            var instance = new SomeClass();

            Bind<ISomeInterface>().ToInstance(instance);
        }
    }

    internal interface ISomeInterface
    {
        void SetText(string text);
        string GetText();
    }

    internal class SomeClass : ISomeInterface
    {
        private string _text;

        public void SetText(string text)
        {
            _text = text;
        }

        public string GetText()
        {
            return _text;
        }
    }

    internal class SomeClass2 : ISomeInterface
    {
        private string _text;

        public void SetText(string text)
        {
            _text = text;
        }

        public string GetText()
        {
            return _text;
        }
    }

    internal class ClassWithInjects
    {
        public readonly SomeClass One;
        public readonly SomeClass2 Two;

        [Inject] public readonly SomeClass Three;
        [Inject] public SomeClass2 Four { get; set; }

        public ClassWithInjects(SomeClass one, SomeClass2 two)
        {
            One = one;
            Two = two;
        }
    }

    #endregion 
}
