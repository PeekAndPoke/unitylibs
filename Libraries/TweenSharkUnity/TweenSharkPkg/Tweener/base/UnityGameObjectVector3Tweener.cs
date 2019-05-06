using UnityEngine;

namespace De.Kjg.TweenSharkPkg.Tweener.@base
{
    public abstract class UnityGameObjectVector3Tweener : UnityGameObjectBaseTweener<Vector3>
    {
        protected override Vector3 AddValues(Vector3 val1, Vector3 val2)
        {
            return val1 + val2;
        }
    }
}
