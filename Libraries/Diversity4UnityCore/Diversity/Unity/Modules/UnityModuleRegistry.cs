using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace De.Kjg.Diversity.Unity.Modules
{
    public class UnityModuleRegistry
    {
        public static string RootGameObjectName = "__Diversity4Unity";

        protected Dictionary<IUnityModule, MonoBehaviour> Registered = new Dictionary<IUnityModule, MonoBehaviour>();

        public void Register(IUnityModule module)
        {
            var root = GetRootGameObject();

            var go = new GameObject();
            go.name = module.GetType().FullName;
            go.AddComponent<Persistor>();
            go.transform.parent = root.transform;

            module.Initialize(go);
        }

        private GameObject GetRootGameObject()
        {
            var root = GameObject.Find(RootGameObjectName);

            if (root == null)
            {
                root = new GameObject();
                root.name = RootGameObjectName;
                root.AddComponent<Persistor>();
            }

            return root;
        }
    }
}
