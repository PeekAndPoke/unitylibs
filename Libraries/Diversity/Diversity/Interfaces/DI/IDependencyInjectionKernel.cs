using System;

namespace De.Kjg.Diversity.Interfaces.DI
{
    /// <summary>
    /// Defines the interface of central entity of the IoC-Container.
    /// 
    /// This small IoC-Container is inspired by NInject https://github.com/ninject/ninject.
    /// </summary>
    public interface IDependencyInjectionKernel
    {
        /// <summary>
        /// Get an instance of the given type. Depending on the defition of the InjectionBinding the requested
        /// Type is created or a singleton instance is returned.
        /// 
        /// If there is no definition available the type is instantiated and injections are applied.
        /// </summary>
        /// <typeparam name="TType">The requested instances type</typeparam>
        /// <returns>The instance of an object</returns>
        TType Get<TType>();
        /// <summary>
        /// <see cref="Get{TType}"/>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        object Get(Type type);

        /// <summary>
        /// Perform Field- and Property-Injections on an exiting object.
        /// </summary>
        /// <param name="instanceToInjectInto">The object to do the injections on.</param>
        void Inject(object instanceToInjectInto);
    }
}