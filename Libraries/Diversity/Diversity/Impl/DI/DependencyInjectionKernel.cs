using System;
using De.Kjg.Diversity.Interfaces.DI;

namespace De.Kjg.Diversity.Impl.DI
{
    /// <summary>
    /// The dependencyInjectionKernel is the central entity for the IoC-Container.
    /// </summary>
    public class DependencyInjectionKernel : IDependencyInjectionKernel
    {
        /// <summary>
        /// The DependencyInjectionContainer managed by the dependencyInjectionKernel
        /// </summary>
        protected readonly IDependencyInjectionContainer DependencyInjectionContainer;

        public DependencyInjectionKernel(IDependencyInjectionContainer dependencyInjectionContainer)
        {
            DependencyInjectionContainer = dependencyInjectionContainer;
            dependencyInjectionContainer.SetKernel(this);
            dependencyInjectionContainer.Load();
        }

        /// <summary>
        /// Get an instance of the given type. Depending on the defition of the Binding the requested
        /// Type is created or a singleton instance is returned.
        /// If there is no definition available the type is instantiated and injections are applied.
        /// </summary>
        /// <typeparam name="TType">The requested instances type</typeparam>
        /// <returns>
        /// The instance of an object
        /// </returns>
        public TType Get<TType> ()
        {
            return DependencyInjectionContainer.Get<TType>();
        }

        /// <summary>
        ///   <see cref="Get{TType}" />
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public object Get(Type type)
        {
            return DependencyInjectionContainer.Get(type);
        }

        /// <summary>
        /// Perform Field- and Property-Injections on an exiting object.
        /// </summary>
        /// <param name="instanceToInjectInto">The object to do the injections on.</param>
        public void Inject(object instanceToInjectInto)
        {
            DependencyInjectionContainer.Inject(instanceToInjectInto);
        }
    }
}
