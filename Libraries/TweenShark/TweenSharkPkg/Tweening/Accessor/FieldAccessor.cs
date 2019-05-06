using System.Reflection;

namespace De.Kjg.TweenSharkPkg.Tweening.Accessor
{
    class FieldAccessor<TValueType> : IAccessor<TValueType>
    {
        private readonly object _obj;
        private readonly FieldInfo _fieldInfo;

        public FieldAccessor(object obj, FieldInfo fieldInfo)
        {
            _obj = obj;
            _fieldInfo = fieldInfo;
        }

        public TValueType GetValue()
        {
            return (TValueType) _fieldInfo.GetValue(_obj);
        }

        public void SetValue(TValueType value)
        {
            _fieldInfo.SetValue(_obj, value);
        }
    }
}
