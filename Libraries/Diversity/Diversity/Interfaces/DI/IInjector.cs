using System;
using System.Collections.Generic;
using De.Kjg.Diversity.Impl.DI;

namespace De.Kjg.Diversity.Interfaces.DI
{
    public interface IInjector
    {
        /// <summary>
        /// Instantiates an object of the requested type by using the provided binding definitions.
        /// </summary>
        /// <param name="type">The requested type</param>
        /// <param name="bindings">The bindings</param>
        /// <returns>The type create by applying the bindings</returns>
        object Instantiate(Type type, List<InjectionBinding> bindings);

        /// <summary>
        /// Get an instancy by applying the given Binding
        /// </summary>
        /// <param name="injectionBinding">The binding to use</param>
        /// <param name="bindings">All other bindings</param>
        /// <returns>The create instance</returns>
        object Instantiate(InjectionBinding injectionBinding, List<InjectionBinding> bindings);

        /// <summary>
        /// Does the field- and property-injection.
        /// 
        /// Looks up all fields and properties that have the [Inject] attribute set and injects an instance into it.
        /// </summary>
        /// <param name="instance">The instance to inject into.</param>
        /// <param name="bindings">The binding definitions to be used.</param>
        void Inject(object instance, List<InjectionBinding> bindings);
    }
}