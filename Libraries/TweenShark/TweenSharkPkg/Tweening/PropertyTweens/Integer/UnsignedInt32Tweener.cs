using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Base;

namespace De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Integer
{
    class UnsignedInt32Tweener : GenericTweener<uint>
    {
        public override void CalculateAndSetValue(float deltaTime)
        {
            var newValue = (uint)Ease(deltaTime, StartValue, TargetValue - StartValue);
            SetValue(newValue);
        }

        protected override uint AddValues(uint val1, uint val2)
        {
            return val1 + val2;
        }
    }
}
