using System.Collections.Generic;
using System.Linq;
using De.Kjg.Diversity.Impl.MVC.DataBinding;
using De.Kjg.Diversity.Impl.Utils;
using De.Kjg.Diversity.Interfaces.MVC.DataBinding;
using NUnit.Framework;

namespace De.Kjg.Diversity.MVC.DataBinding
{
    [TestFixture]
    class BindableEventsTest
    {
        [Test]
        public void ConstructorTest()
        {
            var bindable = new Bindable<int>();
            var events = new BindableEvents(bindable);

            Assert.AreSame(events.GetBindable(), bindable, "The events object should hold the bindable.");
        }

        #region Testing Add() and Remove()

        [Test]
        public void AddTest()
        {
            var events = new BindableEvents(new Bindable<int>());
            
            BindableCallback listener1 = ((c, o) => { });
            BindableCallback listener2 = ((c, o) => { });
            // add two
            events.Add(listener1);
            events.Add(listener2);
            
            // get the listeners
            BindableCallback listeners = (BindableCallback)UnitTestUtil.GetProtected(events, "Listeners");
            Assert.AreEqual(listeners.GetInvocationList().Length, 2, "There should be two listeners by now");

            events.Remove(listener1); // remove the first one

            listeners = (BindableCallback)UnitTestUtil.GetProtected(events, "Listeners");
            Assert.AreEqual(listeners.GetInvocationList().Count(), 1, "There should only be one listener left");

            events.Remove(listener1); // try to remove it again

            listeners = (BindableCallback)UnitTestUtil.GetProtected(events, "Listeners");
            Assert.AreEqual(listeners.GetInvocationList().Count(), 1, "There should still be one listener left");

            events.Remove(listener2); // remove the other one

            listeners = (BindableCallback)UnitTestUtil.GetProtected(events, "Listeners");
            Assert.IsNull(listeners, "There should be no listener left");
        }

        [Test]
        public void AddingListenerMultipleTimesTest()
        {
            var events = new BindableEvents(new Bindable<int>());

            BindableCallback listener1 = ((c, o) => { });
            // add two
            events.Add(listener1);
            events.Add(listener1);

            // get the listeners
            BindableCallback listeners = (BindableCallback)UnitTestUtil.GetProtected(events, "Listeners");
            Assert.AreEqual(listeners.GetInvocationList().Length, 1, "There should only be listeners registered");
        }

        [Test]
        public void AddInvokeTest()
        {
            var events = new BindableEvents(new Bindable<int>());

            var counter1 = 0;
            var counter2 = 0;

            BindableCallback listener1 = ((c, o) => { counter1++; });
            BindableCallback listener2 = ((c, o) => { counter2++; });
            events.Add(listener1);
            events.Add(listener2);

            events.Dispatch(null);
            events.Dispatch(null);

            Assert.AreEqual(2, counter1, "listener1 should have been invoked 2 times");
            Assert.AreEqual(2, counter2, "listener2 should have been invoked 2 times");
        }

        #endregion

        #region Event Forwarding 

        [Test]
        public void ForwardOnChangeTest()
        {
            // setup 
            var events = new BindableEvents(new Bindable<int>());
            var bindableToForwardFrom = new Bindable<string>();
            bindableToForwardFrom.Set("test");
            // register forward
            events.ForwardOnChange(bindableToForwardFrom);
            
            var counter = 0;
            events.Add((c, o) => { counter++; });
            // dispatch
            bindableToForwardFrom.Dispatch();

            Assert.AreEqual(1, counter, "The event should be forwarded once.");

            // remove the listener and dispatch again
            events.RemoveForwardedOnChange(bindableToForwardFrom);
            bindableToForwardFrom.Dispatch();

            Assert.AreEqual(1, counter, "The event should not be forwarded again.");
        }

        [Test]
        public void AddForwardOnChangeMultipleTimes()
        {
            // setup
            var events = new BindableEvents(new Bindable<int>());
            var bindableToForwardFrom = new Bindable<string>();
            // add twice
            events.ForwardOnChange(bindableToForwardFrom);
            events.ForwardOnChange(bindableToForwardFrom);

            var forwarded = (Dictionary<IBindable, BindableCallback>) UnitTestUtil.GetProtected(events, "ForwardedBindables");

            Assert.IsTrue(forwarded.ContainsKey((IBindable) bindableToForwardFrom), "The forwareded bnindable should be known.");
            Assert.AreEqual(1, forwarded.Count, "There should only be one forward listener.");
        }

        #endregion
    }
}
