using De.Kjg.TweenSharkPkg.Logging;
using UnityEngine;

namespace De.Kjg.TweenSharkPkg
{
    class UnityLogger : ILogger
    {
        public void Log(string what)
        {
            Debug.Log(what);
        }

        public void Error(string what)
        {
            Debug.LogError(what);
        }
    }
}
