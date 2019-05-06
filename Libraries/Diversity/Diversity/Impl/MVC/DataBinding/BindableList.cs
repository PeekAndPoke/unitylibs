using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using De.Kjg.Diversity.Interfaces.MVC.DataBinding;

namespace De.Kjg.Diversity.Impl.MVC.DataBinding
{
    public class BindableList<T> : List<T>, IBindable<List<T>>, IBindableContainer where T : IBindable
    {
        protected BindableEvents BindableEvents;

        public List<T> Value
        {
            get { return this; }
        } 

        public BindableList()
        {
            Initialize();
        }

        [OnDeserializing]
        void OnDeserializing(StreamingContext c)
        {
            Initialize();
        }

        private void Initialize()
        {
            BindableEvents = new BindableEvents(this);
        }

        public List<T> Get()
        {
            return this;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="newValue"></param>
        /// <param name="dispatchIfChanged"></param>
        public IBindable<List<T>> Set(List<T> newValue, bool dispatchIfChanged = true)
        {
            // TODO: prevent change event from being dispatched twice
            // TODO: take parameter dispatchIfChanged into account
            Clear();
            AddRange(newValue);

            return this;
        }

        public List<IBindable> GetBindableChildren()
        {
            // is the value type of our list bindable itself?
            if (typeof(T).GetInterfaces().Contains(typeof(IBindable)))
            {
                var ret = new List<IBindable>();
                ret.AddRange((IBindable[]) (object) ToArray());
                return ret;
            }
            return new List<IBindable>();
        } 

        public void OnChange(BindableCallback listener, bool dispatchImmediate)
        {
            if (dispatchImmediate)
            {
                listener(this, this);
            }
            BindableEvents.Add(listener);
        }

        public void RemoveOnChange(BindableCallback listener)
        {
            BindableEvents.Remove(listener);
        }

        public virtual void Dispatch()
        {
            BindableEvents.Dispatch(this);
        }

        public void ForwardOnChange(IBindable originalDispatcher)
        {
            if (originalDispatcher != null)
            {
                BindableEvents.ForwardOnChange(originalDispatcher);
            }
        }

        public void RemoveForwardedOnChange(IBindable originalDispatcher)
        {
            if (originalDispatcher != null)
            {
                BindableEvents.RemoveForwardedOnChange(originalDispatcher);
            }
        }

        // OVERRIDE OPERATORS that will trigger the dispatch

        public new T this[int key]
        {
            get { return base[key]; }
            set
            {
                base[key] = value;
                Dispatch();
            }
        }
        
        // OVERRIDE METHODS that will trigger the dispatch

        public new void Add(T item)
        {
            base.Add(item);
            // forward the change event of the added item
            ForwardOnChange(item);

            Dispatch();
        }

        public new void AddRange(IEnumerable<T> collection)
        {
            base.AddRange(collection);
            // add forward listener for all items
            foreach (var item in collection)
            {
                ForwardOnChange(item);
            }
            Dispatch();
        }

        public new void Clear()
        {
            // remove all forward listeners
            foreach (var item in this)
            {
                RemoveForwardedOnChange(item);
            }
            base.Clear();
            
            Dispatch();
        }

        public new void Insert(int index, T item)
        {
            base.Insert(index, item);
            ForwardOnChange(item);
            Dispatch();
        }

        public new void InsertRange(int index, IEnumerable<T> collection)
        {
            base.InsertRange(index, collection);
            // add forward listener for all items
            foreach (var item in collection)
            {
                ForwardOnChange(item);
            }
            Dispatch();
        }

        public new bool Remove(T item)
        {
            // remove forwarded listener
            RemoveForwardedOnChange(item);

            var ret = base.Remove(item);
            Dispatch();
            return ret;
        }

        public new void RemoveAll(Predicate<T> match)
        {
            // remove all forward listener
            var found = FindAll(match);
            foreach (var item in found)
            {
                RemoveForwardedOnChange(item);
            }

            base.RemoveAll(match);
            Dispatch();
        }

        public new void RemoveAt(int index)
        {
            // remove forwarded listener
            RemoveForwardedOnChange(this[index]);

            base.RemoveAt(index);
            Dispatch();
        }

        public new void RemoveRange(int index, int count)
        {
            // remove forwared listeners
            var range = GetRange(index, count);
            foreach (var item in range)
            {
                RemoveForwardedOnChange(item);
            }

            base.RemoveRange(index, count);
            Dispatch();
        }

        public new void Reverse()
        {
            base.Reverse();
            Dispatch();
        }

        public new void Reverse(int index, int count)
        {
            base.Reverse(index, count);
            Dispatch();
        }

        public new void Sort()
        {
            base.Sort();
            Dispatch();
        }

        public new void Sort(Comparison<T> comparison)
        {
            base.Sort(comparison);
            Dispatch();
        }

        public new void Sort(IComparer<T> comparer)
        {
            base.Sort(comparer);
            Dispatch();
        }

        public new void Sort(int index, int count, IComparer<T> comparer)
        {
            base.Sort(index, count, comparer);
            Dispatch();
        }

    }
}
