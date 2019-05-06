using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Base;

namespace TweenSharkTest.MockObjects
{
    class GenericTweenerImpl<TValueType> : GenericTweener<TValueType>
    {
        public override void CalculateAndSetValue(float deltaTime)
        {
        }

        protected override TValueType AddValues(TValueType val1, TValueType val2)
        {
            return (TValueType) Convert.ChangeType(null, typeof(TValueType));
        }
    }
}
