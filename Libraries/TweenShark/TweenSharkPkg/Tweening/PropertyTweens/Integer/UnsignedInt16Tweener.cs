using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Base;

namespace De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Integer
{
    class UnsignedInt16Tweener : GenericTweener<ushort>
    {
        public override void CalculateAndSetValue(float deltaTime)
        {
            var newValue = (ushort)Ease(deltaTime, StartValue, TargetValue - StartValue);
            SetValue(newValue);
        }

        protected override ushort AddValues(ushort val1, ushort val2)
        {
            return (ushort) (val1 + val2);
        }
    }
}
