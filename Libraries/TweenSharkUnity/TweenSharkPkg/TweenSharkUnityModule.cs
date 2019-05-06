using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using De.Kjg.Diversity.Unity.Modules;
using De.Kjg.TweenSharkPkg.Tick;
using UnityEngine;

namespace De.Kjg.TweenSharkPkg
{
    public class TweenSharkUnityModule : IUnityModule
    {
        public void Initialize(GameObject gameObject)
        {
            var behaviour = gameObject.AddComponent<TweenSharkUnity3DTick>();

            TweenSharkUnity3D.InitializeUnity(behaviour);
        }
    }
}
