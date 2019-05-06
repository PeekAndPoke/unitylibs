using De.Kjg.TweenSharkPkg.Options;
using De.Kjg.TweenSharkPkg.Tweening.Accessor;

namespace De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Base
{
    public abstract class GenericTweener<TValueType> : SimpleTweener<TValueType>
    {
        private IAccessor<TValueType> _accessor;

        public override void Create(object obj, PropertyOps propOps)
        {
            // create the accessor
            CreateAccessor(obj, propOps);

            base.Create(obj, propOps);
       }

        private void CreateAccessor(object obj, PropertyOps propOps)
        {
            var type = obj.GetType();

            var fieldInfo = type.GetField(propOps.PropertyName);
            if (fieldInfo != null)
            {
                _accessor = new FieldAccessor<TValueType>(obj, fieldInfo);
            }
            else
            {
                var propertyInfo = type.GetProperty(propOps.PropertyName);
                if (propertyInfo != null)
                {
                    _accessor = new PropertyAccessor<TValueType>(obj, propertyInfo);
                }
            }

            if (_accessor == null)
            {
                TweenShark.Logger.Error("Obj " + obj + " has no field or property " + propOps.PropertyName);
            }
        }

        protected sealed override TValueType GetValue()
        {
            try
            {
                return _accessor.GetValue();
            }
            catch {}

            return CastSafe(TargetValue);
        }

        protected sealed override void SetValue(TValueType val)
        {
            try
            {
                _accessor.SetValue(val);   
            }
            catch {}
        }

        internal IAccessor<TValueType> GetAccessor()
        {
            return _accessor;
        } 
    }
}
