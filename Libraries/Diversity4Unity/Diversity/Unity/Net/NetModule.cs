using UnityEngine;

namespace De.Kjg.Diversity.Unity.Net
{
    public class NetModule
    {
        public static MonoBehaviour Behaviour { get; private set; }

        protected NetModule()
        {
            
        }

        public static void Initialize(MonoBehaviour monoBehaviour)
        {
            Behaviour = monoBehaviour;
        }
    }
}
