using De.Kjg.TweenSharkPkg.Tweener.@base;
using UnityEngine;

namespace De.Kjg.TweenSharkPkg.Tweener
{
    // TODO: optimize me
    public class UnityGameObjectFadeMaterialTweener : UnityGameObjectBaseTweener<Color>
    {
        protected Material[] Materials;
        private Color _current = Color.white;

        public UnityGameObjectFadeMaterialTweener(Material[] materials)
        {
            Materials = materials;
        }


        public override void Init()
        {
            base.Init();
        }

        public override void CalculateAndSetValue(float deltaTime)
        {
            _current.a = Ease(deltaTime, StartValue.a, TargetValue.a - StartValue.a);

            Materials[0].color = _current;

            _current.a = 1.0f - _current.a;

            Materials[1].color = _current;

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
