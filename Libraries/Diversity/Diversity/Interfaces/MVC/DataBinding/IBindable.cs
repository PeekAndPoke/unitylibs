namespace De.Kjg.Diversity.Interfaces.MVC.DataBinding
{
    /// <summary>
    /// Defines the signature of the callback methods that are invoked when a bindable dispatches its changes.
    /// </summary>
    /// <param name="dispatcher">The currently dispatching bindable (Differs from originalDispatcher when the event is forwarded)</param>
    /// <param name="originalDispatcher">The bindable that did the initial dispatch.</param>
    public delegate void BindableCallback(IBindable dispatcher, IBindable originalDispatcher);

    /// <summary>
    /// Concrete interface. This can be used when the wrapped type of the bindable is unknown.
    /// </summary>
    public interface IBindable
    {
        /// <summary>
        /// Register an OnChange listener. The event is dispatched when some changed inside of a bindable.
        /// </summary>
        /// <param name="listener">The listener</param>
        /// <param name="dispatchImmediate">If true the given listener is immediately dispatched once when added.</param>
        void OnChange(BindableCallback listener, bool dispatchImmediate = true);
        /// <summary>
        /// Removes a OnChange listener.
        /// </summary>
        /// <param name="listener"></param>
        void RemoveOnChange(BindableCallback listener);
        /// <summary>
        /// Forwards an OnChange listener from another bindable. This is usefull to built tree-structures, where you dont need to listen 
        /// for the OnChange-event on all leaves of the tree.
        /// </summary>
        /// <param name="originalDispatcher">The bindable to forward the event from</param>
        void ForwardOnChange(IBindable originalDispatcher);
        /// <summary>
        /// Remove a forwarding listener.
        /// </summary>
        /// <param name="originalDispatcher">The bindable to forward the event from</param>
        void RemoveForwardedOnChange(IBindable originalDispatcher);
        /// <summary>
        /// Dispatches the OnChange event.
        /// </summary>
        void Dispatch();
    }

    /// <summary>
    /// Generic bindable interface that is aware of the wrapped type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBindable<T> : IBindable
    {
        /// <summary>
        /// Contains the wrapped value.
        /// </summary>
        T Value { get; }

        /// <summary>
        /// Get the wrapped value
        /// </summary>
        /// <returns></returns>
        T Get();

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="newValue"></param>
        /// <param name="dispatchIfChanged"></param>
        IBindable<T> Set(T newValue, bool dispatchIfChanged = true);
    }
}
