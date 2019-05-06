using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Base;

namespace De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Integer
{
    class SignedInt64Tweener : GenericTweener<long>
    {
        public override void CalculateAndSetValue(float deltaTime)
        {
            var newValue = (long)Ease(deltaTime, StartValue, TargetValue - StartValue);
            SetValue(newValue);
        }

        protected override long AddValues(long val1, long val2)
        {
            return val1 + val2;
        }
    }
}
