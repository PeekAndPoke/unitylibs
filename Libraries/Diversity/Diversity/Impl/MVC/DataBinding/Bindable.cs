using System;
using System.Runtime.Serialization;
using De.Kjg.Diversity.Interfaces.MVC.DataBinding;

namespace De.Kjg.Diversity.Impl.MVC.DataBinding
{
    /// <summary>
    /// The generic implementation of a bindable.
    /// 
    /// A bindable dispatches an event its value is changed. You can subscribe to the event using OnChange().
    /// 
    /// You should create bindables by using the BindableFactory <see cref="BindableFactory"/>
    /// If you need a list of bindable objects you should use BindableList <see cref="BindableList{T}"/>
    /// For more datails see IBindable <see cref="IBindable{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Bindable<T> : IBindable<T>
    {
        /// <summary>
        /// Manages all the change listeners bound to the bindable
        /// </summary>
        protected BindableEvents BindableEvents;

        /// <summary>
        /// Instance of the real value
        /// </summary>
        public T Value { get; protected set; }

        /// <summary>
        /// C'tor
        /// </summary>
        public Bindable()
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

            var type = typeof(T);
            if (type == typeof(String))
            {
                //                UnityEngine.Debug.Log("Setting value to string for " + GetType().Name + " is it null: " + (this == null));
                Value = (T)(object)"";
            }
            else if (type.IsPrimitive)
            {
                //                UnityEngine.Debug.Log("Setting value to default for " + GetType().Name + " is it null: " + (this == null));
                Value = default(T);
            }
            else
            {
                //                UnityEngine.Debug.Log("Setting value of type " + type.Name + " to this for " + GetType().Name + " is it null: " + (this == null));

                // explicitly convert the type because pure cast is not enough
                Value = default(T);
            }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="newValue"></param>
        /// <param name="dispatchIfChanged"></param>
        public IBindable<T> Set(T newValue, bool dispatchIfChanged = true)
        {
            if ((Value == null && newValue != null) || !Value.Equals(newValue))
            {
                // if the previous value was a bindable for itself, we remove the forwarding
                if (Value is IBindable)
                {
                    RemoveForwardedOnChange((IBindable) Value);
                }
                // if the new value is a bindable we apply a forwarding
                if (newValue is IBindable)
                {
                    ForwardOnChange((IBindable) newValue);
                }

                Value = newValue;
                if (dispatchIfChanged)
                {
                    Dispatch();
                }
            }

            return this;
        }

        /// <summary>
        /// Get the wrapped value
        /// </summary>
        /// <returns></returns>
        public T Get()
        {
            return Value;
        }

        /// <summary>
        /// <see cref="IBindable{T}.OnChange"/>
        /// </summary>
        /// <param name="listener"></param>
        /// <param name="dispatchImmediate"></param>
        public void OnChange(BindableCallback listener, bool dispatchImmediate = true)
        {
            if (dispatchImmediate)
            {
                listener(this, this);
            }
            BindableEvents.Add(listener);
        }

        /// <summary>
        /// <see cref="IBindable{T}.RemoveOnChange"/>
        /// </summary>
        /// <param name="listener"></param>
        public void RemoveOnChange(BindableCallback listener)
        {
            BindableEvents.Remove(listener);
        }

        /// <summary>
        /// <see cref="IBindable.ForwardOnChange"/>
        /// </summary>
        /// <param name="originalDispatcher"></param>
        public void ForwardOnChange(IBindable originalDispatcher)
        {
            BindableEvents.ForwardOnChange(originalDispatcher);
        }

        /// <summary>
        /// <see cref="IBindable.RemoveForwardedOnChange"/>
        /// </summary>
        /// <param name="originalDispatcher"></param>
        public void RemoveForwardedOnChange(IBindable originalDispatcher)
        {
            BindableEvents.RemoveForwardedOnChange(originalDispatcher);
        }

        /// <summary>
        /// <see cref="IBindable.Dispatch"/>
        /// </summary>
        public virtual void Dispatch()
        {
            BindableEvents.Dispatch(this);
        }

        /// <summary>
        /// Defines an implicit assignment operator for assigning the bindable to its wrapped type. 
        /// 
        /// When the Bindable is assigned to its wrapped type the wrapped value is returned.
        /// </summary>
        /// <param name="b">The bindable</param>
        /// <returns>The bindables wrapped value</returns>
        public static implicit operator T(Bindable<T> b)
        {
            return b.Get();
        }

        /// <summary>
        /// Converts the value to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Value != null ? Value.ToString() : "";
        }
    }
}
