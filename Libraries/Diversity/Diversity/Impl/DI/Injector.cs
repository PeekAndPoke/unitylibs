using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using De.Kjg.Diversity.Interfaces.DI;

namespace De.Kjg.Diversity.Impl.DI
{
    public delegate object InstantiateFunc(ConstructorInfo constructorInfo, object[] constructorArgs);

    /// <summary>
    /// The injector created instances and does Field and Property injection.
    /// 
    /// The injection works recursively. All injected instances are created by the injector as well.
    /// </summary>
    public class Injector : IInjector
    {
        /// <summary>
        /// Instantiates an object of the requested type by using the provided binding definitions.
        /// </summary>
        /// <param name="type">The requested type</param>
        /// <param name="bindings">The bindings</param>
        /// <returns>The type create by applying the bindings</returns>
        public object Instantiate(Type type, List<InjectionBinding> bindings)
        {
            // look if there is a binding defined for this type
            var availableBindings = bindings.Where(binding => binding.BoundFrom == type).ToList();
            // TODO: what if there is more than one -> we need rules like in Ninject 
            if (availableBindings.Count > 0)
            {
                // instantiate using the found binding defintion
                return Instantiate(availableBindings[0], bindings);
            }
            // if not just instantiate the type and try to inject            
            return InstantiateInternal(type, bindings, InvokeConstructor, true);
        }

        /// <summary>
        /// Get an instancy by applying the given Binding
        /// </summary>
        /// <param name="injectionBinding">The binding to use</param>
        /// <param name="bindings">All other bindings</param>
        /// <returns>The create instance</returns>
        public object Instantiate(InjectionBinding injectionBinding, List<InjectionBinding> bindings)
        {
            return InstantiateInternal(injectionBinding.BoundTo, bindings, injectionBinding.GetInstance, injectionBinding.DoFieldAndPropertyInjection);
        }

        /// <summary>
        /// Instantiates the target type.
        /// </summary>
        /// <param name="type">The target type</param>
        /// <param name="bindings">All binding definitions to be used</param>
        /// <param name="invoker">Function that is used to create the instance</param>
        /// <param name="doInjection">True if field- and property injections should be applied</param>
        /// <returns>The target type instance</returns>
        private object InstantiateInternal(Type type, List<InjectionBinding> bindings, InstantiateFunc invoker, bool doInjection)
        {
            object instance = null;

            // search for constructor injection
            var constructors = type.GetConstructors();

            var constructorParams = new ArrayList();

            // look for a constructor that fits
            // TODO: we use the first constructor that is defined on the target type, does this work in every case?
            foreach (var constructor in constructors)
            {
                // only use constructors that where really defined on the class and not on base classes
                if (constructor.DeclaringType == constructor.ReflectedType)
                {
                    var parameters = constructor.GetParameters();

                    // only do the injection if we shall do it (f.e. for singleton instance injection we will not do it)
                    if (doInjection)
                    {
                        // check all constructor parameters 
                        foreach (var parameter in parameters)
                        {
                            // create an instance of the parameter type
                            var constructorParameter = Instantiate(parameter.ParameterType, bindings);
                            constructorParams.Add(constructorParameter);
                        }
                    }

                    // instantiate the first constructor found
                    instance = invoker.Invoke(constructor, constructorParams.ToArray());

                    // we use the first constructor that fits
                    break;
                }
            }

            // only do the injection if we shall do it (f.e. for singleton instance injection we will not do it)
            if (doInjection)
            {
                Inject(instance, bindings);                   
            }

            return instance;
        }

        /// <summary>
        /// Does the field- and property-injection.
        /// 
        /// Looks up all fields and properties that have the [Inject] attribute set and injects an instance into it.
        /// </summary>
        /// <param name="instance">The instance to inject into.</param>
        /// <param name="bindings">The binding definitions to be used.</param>
        public void Inject(object instance, List<InjectionBinding> bindings)
        {
            if (instance != null)
            {
                // search for setter method injection via [Inject]

                // inject into proterties having [Inject]
                var properties = instance.GetType().GetProperties();
                foreach (var property in properties)
                {
                    if (property.GetCustomAttributes(typeof(InjectAttribute), true).Any())
                    {
                        property.SetValue(instance, Instantiate(property.PropertyType, bindings), null);
                    }
                }

                // inject into field having [Inject]
                var fields = instance.GetType().GetFields();
                foreach (var field in fields)
                {
                    if (field.GetCustomAttributes(typeof(InjectAttribute), true).Any())
                    {
                        field.SetValue(instance, Instantiate(field.FieldType, bindings));
                    }
                }
            }             
        }

        /// <summary>
        /// Used to create an objet instance by invoking a constructor.
        /// </summary>
        /// <param name="constructorInfo">The constructor to be invoked.</param>
        /// <param name="constructorArgs">The arguments to passed to the constructor.</param>
        /// <returns></returns>
        private object InvokeConstructor(ConstructorInfo constructorInfo, object[] constructorArgs)
        {
            return constructorInfo.Invoke(constructorArgs);
        }
    }
}
