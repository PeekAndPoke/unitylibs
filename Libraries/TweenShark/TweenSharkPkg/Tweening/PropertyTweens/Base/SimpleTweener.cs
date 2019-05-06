using System;
using De.Kjg.TweenSharkPkg.Options;

namespace De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Base
{
    public delegate void CalculationDelegate(float deltaTime);

    public abstract class SimpleTweener<TValueType> : ITweenSharkTweener
    {
        protected object Obj;
        protected PropertyOps PropOps;
        protected EaseFunction EaseFunc;
        protected EaseExFunction EaseExFunc;
        protected object[] EaseExParams;

        protected TValueType StartValue;
        protected TValueType TargetValue;

        #region Abstract Methods

        public abstract void CalculateAndSetValue(float deltaTime);
        public CalculationDelegate CalculateAndSetValueDelegate { get; private set; }

        protected abstract TValueType GetValue();
        protected abstract void SetValue(TValueType val);
        protected abstract TValueType AddValues(TValueType val1, TValueType val2);

        #endregion

        public virtual void Create(object obj, PropertyOps propOps)
        {
            Obj = obj;
            PropOps = propOps;
            EaseFunc = propOps.EaseFunc;
            EaseExFunc = propOps.EaseExFunc;
            EaseExParams = propOps.EaseExParams;

            if (EaseFunc == null && EaseExFunc == null)
            {
                EaseFunc = TweenSharkPkg.Ease.Linear;
            }

            CalculateAndSetValueDelegate = CalculateAndSetValue;

            Setup();
            Init();
        }

        public virtual void Setup() {
            // set the start value for the tweeining
            StartValue = CalculateStartValue();
            // otherwise the implicit cast to TValueType fails
            TargetValue = CalculateTargetValue();
        }

        public virtual void Init()
        {

        }

        public TValueType GetStartValue()
        {
            return StartValue;
        }

        public TValueType GetTargetValue()
        {
            return TargetValue;
        }

        protected virtual TValueType CalculateStartValue ()
        {
            TValueType val;
            if (PropOps.StartValue != null)
            {
                // use the explicitly given start value
                val = CastSafe(PropOps.StartValue);
            }
            else
            {
                // use the objects property value as the start value
                val = GetValue();
            }
            return val;
        }

        protected virtual TValueType CalculateTargetValue()
        {
            var target = CastSafe(PropOps.TargetValue);
            if (PropOps.IsRelative)
            {
                return AddValues(GetValue(), target);
            }
            return target;
        }

        public virtual string GetSubPropertyName()
        {
            return "";
        }

        public virtual string GetFullPropertyName()
        {
            return PropOps.PropertyName + GetSubPropertyName();
        }

        protected TObjectType GetTweenedObject<TObjectType>()
        {
            return (TObjectType) Obj;
        }

        protected float Ease(float deltaTime, float startValue, float valueDelta)
        {
            if (EaseFunc != null)
            {
                return EaseFunc(deltaTime, startValue, valueDelta);
            }
            Console.WriteLine("now! " + EaseExFunc(deltaTime, startValue, valueDelta, EaseExParams));
            return EaseExFunc(deltaTime, startValue, valueDelta, EaseExParams);
        }

        protected TValueType CastSafe(object val)
        {
            return (TValueType)Convert.ChangeType(val, typeof(TValueType));
        }
    }
}
