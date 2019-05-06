using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Base;
using UnityEngine;

namespace De.Kjg.TweenSharkPkg.Tweener.@base
{
    public abstract class UnityGameObjectBaseTweener<TValueType> : SimpleTweener<TValueType>
    {
        public GameObject GameObject;
        public Transform Transform;

        public override void Setup()
        {
            GameObject = GetTweenedObject<GameObject>();
            Transform = GameObject.transform;

            base.Setup();
        }

    }
}
