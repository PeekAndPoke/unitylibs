using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Base;

namespace De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Integer
{
    class SignedByteTweener : GenericTweener<sbyte>
    {
        public override void CalculateAndSetValue(float deltaTime)
        {
            var newValue = (sbyte)Ease(deltaTime, StartValue, TargetValue - StartValue);
            SetValue(newValue);
        }

        protected override sbyte AddValues(sbyte val1, sbyte val2)
        {
            return (sbyte) (val1 + val2);
        }
    }
}
