using System;

namespace De.Kjg.Diversity.Impl.DI
{
    /// <summary>
    /// Define the Binding from requested type to instance actually to be provided
    /// </summary>
    public class InjectionBinding
    {
        /// <summary>
        /// The definition of the request type.
        /// </summary>
        public Type BoundFrom { get; protected set; }
        /// <summary>
        /// The definition of the target type.
        /// </summary>
        public Type BoundTo { get; protected set; }

        /// <summary>
        /// Delegate that is called to instantiate the target types instance.
        /// </summary>
        public InstantiateFunc GetInstance;
        /// <summary>
        /// Defines if the Field and Property-Inject should be done.
        /// </summary>
        public bool DoFieldAndPropertyInjection = true;

        /// <summary>
        /// C'tor
        /// </summary>
        /// <param name="boundFrom"></param>
        public InjectionBinding (Type boundFrom)
        {
            BoundFrom = boundFrom;
        }

        /// <summary>
        /// Define that the requested type is bound to a target type.
        /// Every injection results in a new instance of the target type.
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <returns></returns>
        public InjectionBinding To<TType>()
        {
            BoundTo = typeof(TType);
            // create the instance by invoking the construtor
            GetInstance = (constructorInfo, constructorArgs) => constructorInfo.Invoke(constructorArgs);
            // injection of fields and properties should happen, since we have a newly created instance
            DoFieldAndPropertyInjection = true;
            return this;
        }

        public InjectionBinding ToInstance(object instance)
        {
            BoundTo = instance.GetType();
            // just use the instance
            GetInstance = (constructorInfo, constructorArgs) => instance;
            // prevent injection, since this is a singleton
            DoFieldAndPropertyInjection = false;
            return this;
        }
    }
}
