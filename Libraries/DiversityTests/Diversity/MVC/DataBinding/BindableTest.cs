using De.Kjg.Diversity.Impl.MVC.DataBinding;
using De.Kjg.Diversity.Interfaces.MVC.DataBinding;
using NUnit.Framework;

namespace De.Kjg.Diversity.MVC.DataBinding
{
    [TestFixture]
    class BindableTest
    {
        [Test]
        public void GetSetTest()
        {
            var bindable = new Bindable<int>();

            bindable.Set(10);

            // ge the value using Get();
            var val = bindable.Get();

            Assert.AreEqual(10, val, "The value should be set correctly");

            // get the value using implicit assignment operator
            int val2 = bindable;

            Assert.AreEqual(10, val2, "The returned value should be 10");
        }

        [Test]
        public void OnChangeRemoveOnChangeTest()
        {
            var bindable = new Bindable<int>();

            var counter = 0;

            BindableCallback listener = ((c, o) => { counter++; });
            // add without immediate dispatch
            bindable.OnChange(listener, false);

            bindable.Dispatch();
            Assert.AreEqual(1, counter, "The callback should have been called once.");

            bindable.RemoveOnChange(listener);

            bindable.Dispatch();
            Assert.AreEqual(1, counter, "The callback should have not been called again.");
        }

        [Test]
        public void OnChangeWithImmediateDispatch()
        {
            var bindable = new Bindable<int>();

            var counter = 0;

            BindableCallback listener = ((c, o) => { counter++; });
            // add without immediate dispatch
            bindable.OnChange(listener);

            Assert.AreEqual(1, counter, "The listener should have been invoked onct through immediate dispatch.");
        }

        [Test]
        public void ForwardOnChangeTest()
        {
            // two bindables of different type
            var child = new Bindable<int>();
            var parent = new Bindable<string>();

            parent.ForwardOnChange(child);

            var counter = 0;
            BindableCallback listener = ((c, o) => { counter++; });
            // listener on parent without immediate dispatch
            parent.OnChange(listener, false);

            // dispatch on the child
            child.Dispatch();

            Assert.AreEqual(1, counter, "The OnChange should have been forwarded once to the parent");

            // remove the forwarding
            parent.RemoveForwardedOnChange(child);

            // dispatch again on the child
            child.Dispatch();

            Assert.AreEqual(1, counter, "The OnChange should not have been forwarded again.");
        }


    }
}
