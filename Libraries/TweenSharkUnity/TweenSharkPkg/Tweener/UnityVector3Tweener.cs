using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Base;
using UnityEngine;

namespace De.Kjg.TweenSharkPkg.Tweener
{
    public class UnityVector3Tweener : GenericTweener<Vector3>
    {
        protected Vector3 NewValue = Vector3.zero;
        
        public override void CalculateAndSetValue(float deltaTime)
        {
            NewValue.x = Ease(deltaTime, StartValue.x, TargetValue.x - StartValue.x);
            NewValue.y = Ease(deltaTime, StartValue.y, TargetValue.y - StartValue.y);
            NewValue.z = Ease(deltaTime, StartValue.z, TargetValue.z - StartValue.z);

            SetValue(NewValue);
        }

        protected override Vector3 AddValues(Vector3 val1, Vector3 val2)
        {
            return val1 + val2;
        }
    }
}
