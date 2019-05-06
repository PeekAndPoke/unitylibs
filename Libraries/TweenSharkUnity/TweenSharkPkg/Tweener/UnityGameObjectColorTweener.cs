using De.Kjg.TweenSharkPkg.Tweener.@base;
using UnityEngine;

namespace De.Kjg.TweenSharkPkg.Tweener
{
    // TODO: optimize me
    public class UnityGameObjectColorTweener : UnityGameObjectBaseTweener<Color>
    {
        private Color _current = Color.black;

        public override void Init()
        {
            base.Init();
        }

        public override void CalculateAndSetValue(float deltaTime)
        {
            // var currentVal = GetValue();

            // var current = GameObject.renderer.material.color;

            _current.a = Ease(deltaTime, StartValue.a, TargetValue.a - StartValue.a);
            _current.r = Ease(deltaTime, StartValue.r, TargetValue.r - StartValue.r);
            _current.g = Ease(deltaTime, StartValue.g, TargetValue.g - StartValue.g);
            _current.b = Ease(deltaTime, StartValue.b, TargetValue.b - StartValue.b);

            SetValue(_current);
        }

        protected override Color GetValue()
        {
            return GameObject.renderer.material.color;
        }

        protected override void SetValue(Color val)
        {
            GameObject.renderer.material.SetColor("_Color", val);
        }

        protected override Color AddValues(Color val1, Color val2)
        {
            return val1 + val2;
        }
    }
}
