using De.Kjg.TweenSharkPkg.Tweener.@base;
using UnityEngine;

namespace De.Kjg.TweenSharkPkg.Tweener
{
    public class UnityGameObjectRotateAxisTweener : UnityGameObjectVector3Tweener
    {
        public readonly V3Compnent V3Comp;

        public UnityGameObjectRotateAxisTweener(V3Compnent v3Comp)
        {
            V3Comp = v3Comp;
        }

        public override string GetSubPropertyName()
        {
            return "_" + V3Comp;
        }

        public override void CalculateAndSetValue(float deltaTime)
        {
            var current = GetValue();

            switch (V3Comp)
            {
                case V3Compnent.Forward:
                    current.z = Ease(deltaTime, StartValue.z, TargetValue.z - StartValue.z);
                    break;
                case V3Compnent.Right:
                    current.x = Ease(deltaTime, StartValue.x, TargetValue.x - StartValue.x);
                    break;
                case V3Compnent.Up:
                    current.y = Ease(deltaTime, StartValue.y, TargetValue.y - StartValue.y);
                    break;

            }

            SetValue(current);
        }

        protected override Vector3 GetValue()
        {
            return GameObject.transform.localEulerAngles;
        }

        protected override void SetValue(Vector3 val)
        {
            GameObject.transform.localEulerAngles = val;
        }
    }
}
