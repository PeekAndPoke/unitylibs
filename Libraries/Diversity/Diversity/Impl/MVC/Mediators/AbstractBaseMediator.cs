using System;
using System.Collections.Generic;
using De.Kjg.Diversity.Impl.MVC.DataBinding;
using De.Kjg.Diversity.Impl.MVC.DataBinding.Watchers;
using De.Kjg.Diversity.Impl.Signals;
using De.Kjg.Diversity.Impl.UXs.Events;
using De.Kjg.Diversity.Interfaces.MVC.DataBinding;
using De.Kjg.Diversity.Interfaces.MVC.DataBinding.Watchers;
using De.Kjg.Diversity.Interfaces.Signals;
using De.Kjg.Diversity.Interfaces.UXs.Events;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.MVC.Mediators
{
    public abstract class AbstractBaseMediator
    {
        protected List<KeyValuePair<IBindable, BindableCallback>> RegisteredDataBindings =
            new List<KeyValuePair<IBindable, BindableCallback>>();

        protected List<IBindableListWatcher> RegisteredBindableListWatchers = new List<IBindableListWatcher>();

        protected List<KeyValuePair<ISignal, Slot>> RegisteredSignalSlots = new List<KeyValuePair<ISignal, Slot>>(); 

        public virtual void Destroy()
        {
            // remove all data binding listeners
            foreach (var binding in RegisteredDataBindings)
            {
                binding.Key.RemoveOnChange(binding.Value);
            }
            RegisteredDataBindings.Clear();

            // destroy and remove all list watcher
            foreach (var watcher in RegisteredBindableListWatchers)
            {
                watcher.Destroy();
            }
            RegisteredBindableListWatchers.Clear();

            // remove all signal handlers
            foreach (var signalToSlot in RegisteredSignalSlots)
            {
                signalToSlot.Key.Remove(signalToSlot.Value);
            }
        }

        protected virtual void BindData<T>(IBindable<T> bindable, BindableCallback listener)
        {
            // remember the listener so it can be removed on destruction of the mediator
            RegisteredDataBindings.Add(
                new KeyValuePair<IBindable, BindableCallback>(
                    bindable,
                    listener
                )
            );
            // apply the listener
            bindable.OnChange(listener);
        }

        protected virtual void BindList<T>(BindableList<T> bindableList, BindableListWatcherCallback<T> listener) where T : IBindable
        {
            var watcher = new BindableListWatcher<T>(bindableList, listener);
            // remember the watcher so we can destroy it when the mediator is destroyed
            RegisteredBindableListWatchers.Add(watcher);
        }

        protected virtual void BindSignal<TSlotType>(GenericSignal<TSlotType> signal, TSlotType callback)
        {
            // make the callback handy for storing it
            Slot forwarded = (args => ((Delegate) (object) callback).DynamicInvoke(args));
            // remember it so we can remove on destruction of the mediator
            RegisteredSignalSlots.Add(new KeyValuePair<ISignal, Slot>(signal, forwarded));

            signal.Add(callback);
        }

        protected void ForwardSignal(ISignal from, ISignal to)
        {
            Slot callbackUsed = to.DispatchArgs;
            // remember it so we can remove on destruction of the mediator
            RegisteredSignalSlots.Add(new KeyValuePair<ISignal, Slot>(from, callbackUsed));
            
            from.Add(callbackUsed);
        }

        // TODO: the to-Signal needs an extra interface that has a slot that contains the event
        protected void ForwardChangeEvent(IGuiElement inputElement, ISignal to)
        {                                                  
            // TODO: remove forwared change event on destruction                                     
            inputElement.AddListener(GuiEventNames.Change, e => to.Dispatch(((InputEvent)e).Content));
        }
    }
}
