using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace De.Kjg.Diversity.Unity.Modules
{
    class Persistor : MonoBehaviour
    {
        public void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
        }
    }
}
