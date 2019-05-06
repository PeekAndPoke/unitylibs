using System.Collections.Generic;
using De.Kjg.Diversity.Impl.MVC.DataBinding;
using De.Kjg.Diversity.Impl.MVC.DataBinding.Watchers;
using De.Kjg.Diversity.Interfaces.MVC.DataBinding;
using NUnit.Framework;

namespace De.Kjg.Diversity.MVC.DataBinding.Watchers
{
    [TestFixture]
    class ListWatcherTest
    {
        protected BindableListWatcher<IBindable<int>> Watcher;
        protected BindableList<IBindable<int>> WatchedList;

        protected List<IBindable<int>> AddedItemsList;
        protected List<IBindable<int>> RemainingItemsList;
        protected List<IBindable<int>> RemovedItemsList;

        [SetUp]
        public void Init()
        {
            WatchedList = new BindableList<IBindable<int>>();

            Watcher = new BindableListWatcher<IBindable<int>>(
                WatchedList,
                (newItems, remainingItems, removedItems) =>
                {
                    AddedItemsList = newItems;
                    RemainingItemsList = remainingItems;
                    RemovedItemsList = removedItems;
                }
            );

            AddedItemsList = new List<IBindable<int>>();
            RemainingItemsList = new List<IBindable<int>>();
            RemovedItemsList = new List<IBindable<int>>();
        }

        [Test]
        public void AddItemsTest()
        {
            // add some before applying the watcher.., they must be in the remaining items
            WatchedList.Add(new Bindable<int>().Set(10));
            WatchedList.Add(new Bindable<int>().Set(20));

            // now add the items we will be testing against
            WatchedList.AddRange(new[] { 
                new Bindable<int>().Set(30), 
                new Bindable<int>().Set(40),
                new Bindable<int>().Set(50),
            });

            // 30, 40, 50 should be added
            Assert.That(new[] { 30, 40, 50 }, Is.EquivalentTo(ToListOfValues(AddedItemsList)));
            // 10, 20 should be remaining 
            Assert.That(new[] { 10, 20 }, Is.EquivalentTo(ToListOfValues(RemainingItemsList)));
            // none should be deleted
            Assert.That(new int[] {} , Is.EquivalentTo(ToListOfValues(RemovedItemsList)));
        }

        [Test]
        public void RemoveItemsTest()
        {
            // add some before applying the watcher.., they must be in the remaining items
            WatchedList.Add(new Bindable<int>().Set(10));
            WatchedList.Add(new Bindable<int>().Set(20));
            WatchedList.Add(new Bindable<int>().Set(30));

            // now remove some items
            WatchedList.RemoveRange(1, 2);

            // none should be added
            Assert.That(new int[] { }, Is.EquivalentTo(ToListOfValues(AddedItemsList)));
            // 10 should be remaining
            Assert.That(new[] { 10 }, Is.EquivalentTo(ToListOfValues(RemainingItemsList)));
            // 20, 30 should be deleted
            Assert.That(new[] { 20, 30 }, Is.EquivalentTo(ToListOfValues(RemovedItemsList)));
        }

        [Test]
        public void RemoveItemThatIsNotInTheListTest()
        {
            // add some before applying the watcher.., they must be in the remaining items
            WatchedList.Add(new Bindable<int>().Set(10));
            WatchedList.Add(new Bindable<int>().Set(20));
            WatchedList.Add(new Bindable<int>().Set(30));

            // now add the items we will be testing against
            WatchedList.Remove(new Bindable<int>());

            // none should be added
            Assert.That(new int[] { }, Is.EquivalentTo(ToListOfValues(AddedItemsList)));
            // 10, 20, 30 should be remaining
            Assert.That(new[] { 10, 20, 30 }, Is.EquivalentTo(ToListOfValues(RemainingItemsList)));
            // none should be deleted
            Assert.That(new int[] { }, Is.EquivalentTo(ToListOfValues(RemovedItemsList)));
        }

        /// <summary>
        /// Test to ensure that the watchers memory about the list is corret.
        /// 
        /// The watcher holds a list of items which it knows are in the list. This test is about testing if this
        /// internal memory is working correctly.
        /// </summary>
        [Test]
        public void WatcherInternalMemoryTest()
        {
            WatchedList.Add(new Bindable<int>().Set(10));
            Assert.That(new [] { 10 }, Is.EquivalentTo(ToListOfValues(AddedItemsList)));
            Assert.That(new int [] { }, Is.EquivalentTo(ToListOfValues(RemainingItemsList)));
            Assert.That(new int [] { }, Is.EquivalentTo(ToListOfValues(RemovedItemsList)));

            WatchedList.AddRange(new []{
                new Bindable<int>().Set(20), 
                new Bindable<int>().Set(30)
            });
            Assert.That(new[] { 20, 30 }, Is.EquivalentTo(ToListOfValues(AddedItemsList)));
            Assert.That(new[] { 10 }, Is.EquivalentTo(ToListOfValues(RemainingItemsList)));
            Assert.That(new int[] { }, Is.EquivalentTo(ToListOfValues(RemovedItemsList)));

            WatchedList.AddRange(new[]{
                new Bindable<int>().Set(40), 
                new Bindable<int>().Set(50)
            });
            Assert.That(new[] { 40, 50 }, Is.EquivalentTo(ToListOfValues(AddedItemsList)));
            Assert.That(new[] { 10, 20, 30 }, Is.EquivalentTo(ToListOfValues(RemainingItemsList)));
            Assert.That(new int[] { }, Is.EquivalentTo(ToListOfValues(RemovedItemsList)));

            WatchedList.RemoveRange(0, 2);
            Assert.That(new int[] { }, Is.EquivalentTo(ToListOfValues(AddedItemsList)));
            Assert.That(new[] { 30, 40, 50 }, Is.EquivalentTo(ToListOfValues(RemainingItemsList)));
            Assert.That(new[] { 10, 20 }, Is.EquivalentTo(ToListOfValues(RemovedItemsList)));

            WatchedList.RemoveRange(0, 2);
            Assert.That(new int[] { }, Is.EquivalentTo(ToListOfValues(AddedItemsList)));
            Assert.That(new[] { 50 }, Is.EquivalentTo(ToListOfValues(RemainingItemsList)));
            Assert.That(new[] { 30, 40 }, Is.EquivalentTo(ToListOfValues(RemovedItemsList)));
        }

        public List<T> ToListOfValues<T>(List<IBindable<T>> list)
        {
            var ret = new List<T>();
            foreach (var item in list)
            {
                ret.Add(item.Get());
            }
            return ret;
        }
    }

}
