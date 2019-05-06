using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Base;

namespace De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Integer
{
    class SignedInt32Tweener : GenericTweener<int>
    {

        public override void CalculateAndSetValue(float deltaTime)
        {
            var newValue = (int)Ease(deltaTime, StartValue, TargetValue - StartValue);
            SetValue(newValue);
        }

        protected override int AddValues(int val1, int val2)
        {
            return (val1 + val2);
        }
    }
}
