using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Base;

namespace De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Integer
{
    class UnsignedByteTweener : GenericTweener<byte>
    {
        public override void CalculateAndSetValue(float deltaTime)
        {
            var newValue = (byte)Ease(deltaTime, StartValue, TargetValue - StartValue);
            SetValue(newValue);
        }

        protected override byte AddValues(byte val1, byte val2)
        {
            return (byte) (val1 + val2);
        }
    }
}
