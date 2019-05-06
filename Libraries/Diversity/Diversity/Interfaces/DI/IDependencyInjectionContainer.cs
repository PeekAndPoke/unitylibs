using System;
using System.Collections.Generic;
using De.Kjg.Diversity.Impl.DI;

namespace De.Kjg.Diversity.Interfaces.DI
{
    public interface IDependencyInjectionContainer
    {
        /// <summary>
        /// The bindings definitions.
        /// </summary>
        List<InjectionBinding> Bindings { get; }
        /// <summary>
        /// The injector.
        /// </summary>
        IInjector Injector { get; }
        /// <summary>
        /// Reference to the dependencyInjectionKernel of this DependencyInjectionContainer.
        /// </summary>
        IDependencyInjectionKernel Kernel { get; }
        /// <summary>
        /// Set the dependencyInjectionKernel.
        /// </summary>
        /// <param name="dependencyInjectionKernel"></param>
        void SetKernel(DependencyInjectionKernel dependencyInjectionKernel);
        /// <summary>
        /// Implement this methods and define your type binding in it.
        /// </summary>
        void Load();
        /// <summary>
        /// Begins the definition of a binding
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <returns></returns>
        InjectionBinding Bind<TType>();
        /// <summary>
        /// <see cref="IDependencyInjectionKernel.Get{TType}"/>
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <returns></returns>
        TType Get<TType>();
        /// <summary>
        /// <see cref="IDependencyInjectionKernel.Get{TType}"/>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        object Get(Type type);
        /// <summary>
        /// <see cref="IDependencyInjectionKernel.Inject"/>
        /// </summary>
        /// <param name="instanceToInjectInto"></param>
        void Inject(object instanceToInjectInto);
    }
}