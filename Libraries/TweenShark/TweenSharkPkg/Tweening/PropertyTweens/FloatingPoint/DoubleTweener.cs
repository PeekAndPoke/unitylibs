using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Base;

namespace De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.FloatingPoint
{
    class DoubleTweener : GenericTweener<double>
    {
        public override void CalculateAndSetValue(float deltaTime)
        {
            var newValue = Ease(deltaTime, (float)StartValue, (float)(TargetValue - StartValue));
            SetValue(newValue);
        }

        protected override double AddValues(double val1, double val2)
        {
            return val1 + val2;
        }
    }
}
