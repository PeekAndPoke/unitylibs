using System;
using System.Collections.Generic;
using System.Linq;
using De.Kjg.Diversity.Interfaces.MVC.DataBinding;

namespace De.Kjg.Diversity.Impl.MVC.DataBinding
{
    /// <summary>
    /// Manages all OnChange-listeners attached to a bindable
    /// </summary>
    /// <typeparam name="T">The type the is wrapped by a bindable</typeparam>
    public class BindableEvents
    {
        /// <summary>
        /// Reference to the bindable, to which this instance belongs to.
        /// </summary>
        protected readonly IBindable Bindable;
        /// <summary>
        /// The event that holds all listeners
        /// </summary>
        protected BindableCallback Listeners;
        /// <summary>
        /// A Dictionary to remember all the forwareded events.
        /// This is used in ForwardOnChange() and RemoveForwardedOnChange()
        /// <see cref="ForwardOnChange"/>
        /// <see cref="RemoveForwardedOnChange"/>
        /// </summary>
        protected readonly Dictionary<IBindable, BindableCallback> ForwardedBindables = new Dictionary<IBindable, BindableCallback>();
        /// <summary>
        /// C'tor
        /// </summary>
        /// <param name="bindable">The bindable that this instance belongs to</param>
        public BindableEvents(IBindable bindable)
        {
            Bindable = bindable;
        }

        public IBindable GetBindable()
        {
            return Bindable;
        }

        /// <summary>
        /// Add a listener.
        /// </summary>
        /// <param name="listener">The listener</param>
        public void Add(BindableCallback listener)
        {
            // prevent that the same listener is added multiple times
            if (Listeners == null || !Listeners.GetInvocationList().Contains(listener))
            {
                Listeners += listener;
            }
        }

        /// <summary>
        /// Remove a listener.
        /// </summary>
        /// <param name="listener"></param>
        public void Remove(BindableCallback listener)
        {
            // no, just remove the listener itself
            Console.WriteLine("removing listener");
            Listeners -= listener;
        }

        /// <summary>
        /// Dispatch the OnChange-Event
        /// </summary>
        /// <param name="originalDispatcher">The original dispatcher, in case we are forwarding the event</param>
        public void Dispatch(IBindable originalDispatcher)
        {
            if (Listeners != null)
            {
                Listeners.DynamicInvoke(Bindable, originalDispatcher);
            }
        }

        /// <summary>
        /// Register a forwarding listener to another bindable
        /// </summary>
        /// <param name="originalDispatcher">The bindable to forward from</param>
        public void ForwardOnChange(IBindable originalDispatcher)
        {
            if (!ForwardedBindables.ContainsKey(originalDispatcher))
            {
                // create an anonymous function the is used for forwarding
                var forwarding = (BindableCallback)((c, o) => Dispatch(o));
                // add it and dont immediatly dispatch
                originalDispatcher.OnChange(forwarding, false);
                // remember the anonymous function
                ForwardedBindables[originalDispatcher] = forwarding;
            }
        }

        /// <summary>
        /// Remove a forwarding listener.
        /// </summary>
        /// <param name="originalDispatcher">The bindable to forward from</param>
        public void RemoveForwardedOnChange(IBindable originalDispatcher)
        {
            // do we know the listener
            if (ForwardedBindables.ContainsKey(originalDispatcher))
            {
                // remove it
                originalDispatcher.RemoveOnChange(ForwardedBindables[originalDispatcher]);
                ForwardedBindables.Remove(originalDispatcher);
            }
        }
    }
}
