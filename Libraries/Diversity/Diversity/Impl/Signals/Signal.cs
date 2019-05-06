using System.Collections.Generic;
using De.Kjg.Diversity.Interfaces.Signals;

namespace De.Kjg.Diversity.Impl.Signals
{
    class ConnectedSlotInformation
    {
        public Slot Slot;
        public int Priority;
        public bool Once;
        public int AddedAtIndex;

        public ConnectedSlotInformation(Slot slot, int priority, bool once, int addedAtIndex)
        {
            Slot = slot;
            Priority = priority;
            Once = once;
            AddedAtIndex = addedAtIndex;
        }
    }

    public class Signal : ISignal
    {
        #region Members

        private List<ConnectedSlotInformation> _connectedSlotInformation = new List<ConnectedSlotInformation>();
        /// <summary>
        /// This is used to figure out if a slot is already connected before, to prevent it from being added twice
        /// </summary>
        private Dictionary<Slot, ConnectedSlotInformation> _knownSlots = new Dictionary<Slot, ConnectedSlotInformation>();

        private int _indexCounter = 0;

        #endregion

        public int NumListeners
        {
            get { return _knownSlots.Count; }
        }

        public void Add(Slot slot, int priority = 0)
        {
            AddInternal(slot, priority, false);
        }

        public void AddOnce(Slot slot, int priority = 0)
        {
            AddInternal(slot, priority, true);
        }

        public bool Has(Slot slot)
        {
            return _knownSlots.ContainsKey(slot);
        } 

        public void Remove(Slot slot)
        {
            if (_knownSlots.ContainsKey(slot))
            {
                Remove(_knownSlots[slot]);
            }
        }

        private void Remove(ConnectedSlotInformation info)
        {
            if (_knownSlots.ContainsKey(info.Slot))
            {
                _connectedSlotInformation.Remove(info);
                _knownSlots.Remove(info.Slot);
            }
        }

        public void RemoveAll()
        {
            _connectedSlotInformation = new List<ConnectedSlotInformation>();
            _knownSlots = new Dictionary<Slot, ConnectedSlotInformation>();
        }

        public void Dispatch(params object[] parameters)
        {
            DispatchArgs(parameters);
        }

        public void DispatchArgs(object[] args)
        {
            var toRemove = new List<ConnectedSlotInformation>();

            var copy = new List<ConnectedSlotInformation>(_connectedSlotInformation);
            foreach (var info in copy)
            {
                // execute the delegate
                info.Slot(args);
                // remove it if it is only listening once
                if (info.Once)
                {
                    toRemove.Add(info);
                }
            }

            foreach (var rem in toRemove)
            {
                Remove(rem);
            }
        }
        
        protected void AddInternal(Slot slot, int priority, bool once)
        {
            if (!_knownSlots.ContainsKey(slot))
            {
                var info = new ConnectedSlotInformation(slot, priority, once, _indexCounter++);
                _connectedSlotInformation.Add(info);
                _knownSlots.Add(slot, info);

                // sort
                _connectedSlotInformation.Sort(Sort);
            }
        }

        private int Sort(ConnectedSlotInformation x, ConnectedSlotInformation y)
        {
            if (x.Priority == y.Priority)
            {
                return x.AddedAtIndex < y.AddedAtIndex ? -1 : 1;
            }
            if (x.Priority > y.Priority) return -1;
            return 1;
        }
    }
}