using System;
using System.Collections.Generic;
using De.Kjg.Diversity.Interfaces.Signals;

namespace De.Kjg.Diversity.Impl.Signals
{
    public class GenericSignal<TSignalType> : Signal
    {
        protected Dictionary<TSignalType, Slot> ForwardedListeners = new Dictionary<TSignalType, Slot>();

        public void Add(TSignalType slot, int priority = 0)
        {
            Slot forwarded = (args => ((Delegate) (object) slot).DynamicInvoke(args));
            if (!ForwardedListeners.ContainsKey(slot))
            {
                ForwardedListeners[slot] = forwarded;
                Add(forwarded, priority);
            }
        }

        public void AddOnce(TSignalType slot, int priority = 0)
        {
            Slot forwarded = (args => ((Delegate)(object)slot).DynamicInvoke(args));
            if (!ForwardedListeners.ContainsKey(slot))
            {
                ForwardedListeners[slot] = forwarded;
                AddOnce(forwarded, priority);
            }
        }

        public void Remove(TSignalType slot)
        {
            if (ForwardedListeners.ContainsKey(slot))
            {
                Remove(ForwardedListeners[slot]);
                ForwardedListeners.Remove(slot);
            }
        }
    }
}