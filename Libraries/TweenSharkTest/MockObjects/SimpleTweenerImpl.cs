using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TweenSharkTest.MockObjects
{
    class SimpleTweenerImpl<TValueType> : SimpleTweener<TValueType>
    {
        public TValueType Value;

        public override void CalculateAndSetValue(float deltaTime)
        {
            
        }

        protected override TValueType GetValue()
        {
            return Value;
        }

        protected override void SetValue(TValueType val)
        {
            Value = val;
        }

        protected override TValueType AddValues(TValueType val1, TValueType val2)
        {
            if (typeof(TValueType) == typeof(int))
            {
                return (TValueType) (object) ((int)Convert.ChangeType(val1, typeof(int)) + (int)Convert.ChangeType(val2, typeof(int)));
            }
            return default(TValueType);
        }
    }
}
