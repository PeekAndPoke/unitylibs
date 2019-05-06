using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Base;

namespace De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Integer
{
    class SignedInt16Tweener : GenericTweener<short>
    {
        public override void CalculateAndSetValue(float deltaTime)
        {
            var newValue = (short)Ease(deltaTime, StartValue, TargetValue - StartValue);
            SetValue(newValue);
        }

        protected override short AddValues(short val1, short val2)
        {
            return (short) (val1 + val2);
        }
    }
}
