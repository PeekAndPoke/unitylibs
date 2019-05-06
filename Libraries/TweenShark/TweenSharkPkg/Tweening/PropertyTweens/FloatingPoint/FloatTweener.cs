using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Base;

namespace De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.FloatingPoint
{
    class FloatTweener : GenericTweener<float>
    {
        public override void CalculateAndSetValue(float deltaTime)
        {
            var newValue = Ease(deltaTime, StartValue, TargetValue - StartValue);
            SetValue(newValue);
        }

        protected override float AddValues(float val1, float val2)
        {
            return val1 + val2;
        }
    }
}
