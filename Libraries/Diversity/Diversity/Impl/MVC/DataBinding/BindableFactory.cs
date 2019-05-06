using System;
using System.Linq;
using De.Kjg.Diversity.Interfaces.MVC.DataBinding;

namespace De.Kjg.Diversity.Impl.MVC.DataBinding
{
    /// <summary>
    /// Factory for creating Bindable instances.
    /// 
    /// The main use of this factory is to create a bindable object and traverse through all its fields.
    /// <see cref="CreateObjectRecursive{T}"/>
    /// 
    /// It can also be used to create single instance f.e. 
    /// <code>
    ///     Bindable{int} bi = BindableFactory.CreateInt();
    /// </code>
    /// </summary>
    public class BindableFactory
    {
        public static void ApplyBindingsRecursive(IBindable obj)
        {
            var type = obj.GetType();

            // if it has children (f.e. BindableList) we forward all their events and child events to
            if (obj is IBindableContainer)
            {
                foreach (var child in ((IBindableContainer) obj).GetBindableChildren())
                {
                    ApplyBindingsRecursive(child);
                }
            }

            // go through all field an look for the [CreateBindable] attribute
            var fields = type.GetFields();
            foreach (var field in fields)
            {
                var fieldValue = field.GetValue(obj);
                if (field.GetCustomAttributes(typeof(BindableAttribute), true).Any())
                {
                    var castedfieldValue = (IBindable) fieldValue;

                    obj.ForwardOnChange(castedfieldValue);
//                    UnityEngine.Debug.Log("forwarding from field '" + field.Name + "' " + castedfieldValue.GetType().Name + " to " + obj.GetType().Name);

                    ApplyBindingsRecursive(castedfieldValue);    
                }
            }
        }

        /// <summary>
        /// Create a bindable object and traverses through all its fields
        /// 
        /// If one the fields has the attribute [CreateBindable] set, the field is initialized with a new instance of a bindable
        /// according to the fields type. The same is done for all field definitions of the children and so on.
        /// 
        /// This way a tree of bindables is created. The method forwards all bindable events from child object to its parent.
        /// So in the end, one only need to listener at the root for OnChange-event to know that somewhere in the tree something
        /// was changed.
        /// </summary>
        /// <typeparam name="T">The type to be created</typeparam>
        /// <param name="parentObject">parent bindable object</param>
        /// <returns>The created instance of type T</returns>
        public static T CreateObjectRecursive<T>(IBindable parentObject = null)
        {
            return (T)CreateObjectRecursive(typeof(T), parentObject);
        }
        /// <summary>
        /// <see cref="CreateObjectRecursive{T}"/>
        /// </summary>
        /// <param name="type"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        protected static IBindable CreateObjectRecursive(Type type, IBindable parent)
        {   
            // some debug output                                                                       
//            UnityEngine.Debug.Log("Trying to create type: " + type.FullName + " isGeneric:" + type.IsGenericType);
//            if (type.IsGenericType)
//            {
//                UnityEngine.Debug.Log("It is a generic type: " + type.GetGenericArguments()[0].ToString());
//            }

            // create the objects instance
            var constructor = type.GetConstructor(Type.EmptyTypes);
            var obj = constructor.Invoke(null);
            // the object to be created must implement IBindable
            if (!(obj is IBindable))
            {
                throw new BindableException("All objects created by BindableFactory must implement the interface IBindable but " + type.Name + " does not!");
            }
            
            var objCasted = (IBindable) obj;
            // if the object has a parent then forward the events to the parent
            if (parent != null)
            {
                parent.ForwardOnChange(objCasted);
            }

            // go through all field an look for the [CreateBindable] attribute
            var fields = type.GetFields();
            foreach (var field in fields)
            {
                if (field.GetCustomAttributes(typeof(BindableAttribute), true).Any())
                {
                    var childObj = CreateObjectRecursive(field.FieldType, objCasted);
                    field.SetValue(objCasted, childObj);
                }
            }

            return objCasted;
        }

        /// <summary>
        /// Creates a bindable int
        /// </summary>
        /// <returns></returns>
        public static Bindable<int> CreateInt()
        {
            return new Bindable<int>();
        }

        /// <summary>
        /// Creates a bindable uint
        /// </summary>
        /// <returns></returns>
        public static Bindable<uint> CreateUInt()
        {
            return new Bindable<uint>();
        }

        /// <summary>
        /// Creates a bindable float
        /// </summary>
        /// <returns></returns>
        public static Bindable<float> CreateFloat()
        {
            return new Bindable<float>();
        }

        /// <summary>
        /// Creates a bindable double
        /// </summary>
        /// <returns></returns>
        public static Bindable<double> CreateDouble()
        {
            return new Bindable<double>();
        }

        /// <summary>
        /// Creates a bindable string
        /// </summary>
        /// <returns></returns>
        public static Bindable<string> CreateString()
        {
            return new Bindable<string>();
        } 

        /// <summary>
        /// Creates a bindable List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static BindableList<T> CreateList<T>() where T : IBindable
        {
            return new BindableList<T>();
        } 
    }
}
