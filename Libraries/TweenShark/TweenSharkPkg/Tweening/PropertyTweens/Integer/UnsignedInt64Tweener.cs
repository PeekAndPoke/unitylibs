using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Base;

namespace De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Integer
{
    class UnsignedInt64Tweener : GenericTweener<ulong>
    {
        public override void CalculateAndSetValue(float deltaTime)
        {
            var newValue = (ulong)Ease(deltaTime, StartValue, TargetValue - StartValue);
            SetValue(newValue);
        }

        protected override ulong AddValues(ulong val1, ulong val2)
        {
            return val1 + val2;
        }
    }
}
