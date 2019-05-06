using System;
using System.Collections.Generic;
using De.Kjg.Diversity.Interfaces.DI;

namespace De.Kjg.Diversity.Impl.DI
{
    /// <summary>
    /// A basic DependencyInjectionContainer implementation.
    /// 
    /// Override the Load()-Method and do the Binding-Definitions there.
    /// </summary>
    public class DependencyInjectionContainer : IDependencyInjectionContainer
    {
        /// <summary>
        /// The bindings definitions.
        /// </summary>
        public List<InjectionBinding> Bindings { get; protected set; }
        /// <summary>
        /// The injector.
        /// </summary>
        public IInjector Injector { get; protected set; }
        /// <summary>
        /// Reference to the dependencyInjectionKernel of this DependencyInjectionContainer.
        /// </summary>
        public IDependencyInjectionKernel Kernel { get; protected set; }

        /// <summary>
        /// C'tor
        /// </summary>
        public DependencyInjectionContainer()
        {
            Bindings = new List<InjectionBinding>();
            Injector = new Injector();
        }

        /// <summary>
        /// Sets the IDependencyInjectionKernel managing this DependencyInjectionContainer.
        /// </summary>
        /// <param name="dependencyInjectionKernel"></param>
        public void SetKernel(DependencyInjectionKernel dependencyInjectionKernel)
        {
            Kernel = dependencyInjectionKernel;
        }

        /// <summary>
        /// Override this method and define the Bindings for the DependencyInjectionContainer.
        /// </summary>
        public virtual void Load()
        {
        }

        /// <summary>
        /// Define the requested type of a binding.
        /// 
        /// See class Binding.
        /// 
        /// Example:
        /// 
        /// Bind<ISomeObject>.To<SomeClass>() - always injects a new instance when "ISomeObject" is requested
        /// Bind<ISomeOther>.ToInstance(someObject) - always injects "someObject" when "ISomeOther" is requested
        /// </summary>
        /// <typeparam name="TType">The requested type</typeparam>
        /// <returns>A InjectionBinding</returns>
        public InjectionBinding Bind<TType>()
        {
            var type = typeof (TType);
            var binding = new InjectionBinding(type);
            Bindings.Add(binding);
            return binding;
        }

        /// <summary>
        /// <see cref="IDependencyInjectionKernel.Get{TType}"/>
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <returns></returns>
        public TType Get<TType>()
        {
            return (TType)Injector.Instantiate(typeof(TType), Bindings);
        }

        /// <summary>
        /// <see cref="IDependencyInjectionKernel.Get"/>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public object Get(Type type)
        {
            return Injector.Instantiate(type, Bindings);
        }

        /// <summary>
        /// <see cref="IDependencyInjectionKernel.Inject"/>
        /// </summary>
        /// <param name="instanceToInjectInto"></param>
        public void Inject(object instanceToInjectInto)
        {
            Injector.Inject(instanceToInjectInto, Bindings);
        }

    }
}
