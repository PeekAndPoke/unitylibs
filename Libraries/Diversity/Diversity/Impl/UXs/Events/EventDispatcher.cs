using System;
using System.Collections.Generic;
using De.Kjg.Diversity.Impl.Signals;
using De.Kjg.Diversity.Interfaces.UXs.Events;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Events
{
    /// <summary>
    /// TODO: do UX-Event as Signals to ... with Bubbling
    /// </summary>
    public class EventDispatcher
    {
        private readonly IGuiElement _component;

        protected Dictionary<string, GenericSignal<Delegate>> Events = new Dictionary<string, GenericSignal<Delegate>>();

        public EventDispatcher(IGuiElement component)
        {
            _component = component;
        }

        public void Add(string eventName, Delegate listener, bool once, int priority)
        {
            if (!Events.ContainsKey(eventName))
            {
                Events[eventName] = new GenericSignal<Delegate>();
            }

            if (once)
            {
                Events[eventName].AddOnce(listener, priority);
            }
            else
            {
                Events[eventName].Add(listener, priority);
            }
        }

        public void Dispatch(string eventName, IEvent e = null)
        {
            // setup the event
            if (e == null)
            {
                e = new Event { Target = _component };
            }
            e.CurrentTarget = _component;

            if (Events.ContainsKey(eventName))
            {
                // todo: get all listeners and do them one by one. Watch if the event was stopped.
                Events[eventName].Dispatch(e);
            }

            // if the event was not stopped let it bubble
            if (_component.GetParent() != null && !e.IsStopped)
            {
                _component.GetParent().Dispatch(eventName, e);
            }
        }

        public void RemoveAllHandlersFromAllEvents()
        {
            Events = new Dictionary<string, GenericSignal<Delegate>>();
        }

        public void RemoveAllHandlers(string eventName)
        {
            Events.Remove(eventName);
        }

        public void Remove(string eventName, Delegate handler)
        {
            if (Events.ContainsKey(eventName))
            {
                Events[eventName].Remove(handler);   
            }
        }
    }
}
