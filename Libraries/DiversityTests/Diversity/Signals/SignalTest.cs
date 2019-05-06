using De.Kjg.Diversity.Impl.Signals;
using De.Kjg.Diversity.Interfaces.Signals;
using NUnit.Framework;

namespace De.Kjg.Diversity.Signals
{
    [TestFixture]
    class SignalTest
    {
        [Test]
        public void AddTest()
        {
            var signal = new Signal();

            var counter = 0;

            Slot listener1 = ((args) => { counter += (int)args[0] + (int)args[1] + (int)args[2]; });
            Slot listener2 = ((args) => { counter += (int)args[0] + (int)args[1] + (int)args[2]; });

            signal.Add(listener1);
            signal.Add(listener2);

            signal.Dispatch(100, 10, 1);

            Assert.AreEqual(222, counter, "All listeners should have been called with all parameters");
        }

        [Test]
        public void AddSameListenerMultipleTimesTest()
        {
            var signal = new Signal();

            var counter = 0;

            Slot listener1 = ((args) => { counter++; });

            signal.Add(listener1);
            signal.Add(listener1);

            signal.Dispatch();

            Assert.AreEqual(1, counter, "The listener should only be added once");
        }

        [Test]
        public void AddOnceTest()
        {
            var signal = new Signal();

            var counter = 0;

            Slot listener1 = ((args) => { counter++; });

            signal.AddOnce(listener1);

            // dispatch zwei
            signal.Dispatch();
            signal.Dispatch();

            Assert.AreEqual(1, counter, "The listener should only be called once");
        }

        [Test]
        public void RemoveTest()
        {
            var signal = new Signal();

            var counter = 0;
            Slot listener1 = ((args) => { counter++; });

            // add the listener
            signal.Add(listener1);
            signal.Dispatch();
            // and remove it again
            signal.Remove(listener1);
            signal.Dispatch();

            Assert.AreEqual(1, counter, "The listener should only be called once");
        }

        [Test]
        public void RemoveAllTest()
        {
            var signal = new Signal();

            var counter = 0;

            Slot listener1 = ((args) => { counter += (int)args[0] + (int)args[1] + (int)args[2]; });
            Slot listener2 = ((args) => { counter += (int)args[0] + (int)args[1] + (int)args[2]; });

            signal.Add(listener1);
            signal.Add(listener2);

            signal.Dispatch(100, 10, 1);

            signal.RemoveAll();

            signal.Dispatch();

            Assert.AreEqual(222, counter, "All listeners should have been called only onces");
        }

        [Test]
        public void PriorityTest()
        {
            var signal = new Signal();

            var val = 0;

            Slot listener1 = ((args) => { val = 100; });
            Slot listener2 = ((args) => { val = 200; });

            signal.Add(listener1, 0);
            signal.Add(listener2, 100);

            signal.Dispatch();

            // we expect listener1 to be called the last
            Assert.AreEqual(100, val);
        }

        [Test]
        public void Priority2Test()
        {
            var signal = new Signal();

            var val = 0;

            Slot listener1 = ((args) => { val = 100; });
            Slot listener2 = ((args) => { val = 200; });

            signal.Add(listener1, 0);
            signal.Add(listener2, -100);

            signal.Dispatch();

            // we expect listener2 to be called the last
            Assert.AreEqual(200, val);
        }
    }
}
