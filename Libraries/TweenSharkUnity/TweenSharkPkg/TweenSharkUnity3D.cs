using De.Kjg.Diversity.Unity.Modules;
using De.Kjg.TweenSharkPkg.Tick;
using De.Kjg.TweenSharkPkg.Tweener;
using UnityEngine;

namespace De.Kjg.TweenSharkPkg
{
    class TweenSharkUnity3D
    {
        protected TweenSharkUnity3D()  
        {
        }

        public static void InitializeUnity (TweenSharkUnity3DTick behaviour)
        {
            TweenShark.Initialize(new TweenSharkTick(behaviour), new UnityLogger());
            TweenShark.RegisterPropertyTweener(typeof(UnityVector3Tweener), typeof(Vector3));
        }
    }
}
