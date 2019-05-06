using System.Reflection;

namespace De.Kjg.TweenSharkPkg.Tweening.Accessor
{
    class PropertyAccessor<TValueType> : IAccessor<TValueType>
    {
        private readonly object _obj;
        private readonly PropertyInfo _propertyInfo;

        public PropertyAccessor(object obj, PropertyInfo propertyInfo)
        {
            _obj = obj;
            _propertyInfo = propertyInfo;
        }

        public TValueType GetValue()
        {
//            Console.WriteLine("_obj: " + _obj);
//            Console.WriteLine("_propertyInfo: " + _propertyInfo);
            return (TValueType)_propertyInfo.GetValue(_obj, null);
        }

        public void SetValue(TValueType value)
        {
            _propertyInfo.SetValue(_obj, value, null);
        }
    }
}
