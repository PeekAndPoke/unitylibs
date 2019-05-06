using System.Collections;
using UnityEngine;

namespace De.Kjg.TweenSharkPkg.Tick
{
    internal class TweenSharkUnity3DTick : MonoBehaviour
    {
        private TweenSharkTickDelegate _ticker;
        private bool _running;

        public void Run(TweenSharkTickDelegate ticker)
        {
            DontDestroyOnLoad(gameObject);

            _ticker = ticker;
            _running = true;

            //StartCoroutine(Tick());
        }

        public void Stop()
        {
            _running = false;
        }

        public void LateUpdate ()
        {
            if (_running)
            {
                _ticker();
            }
        }

        private IEnumerator Tick()
        {
            while (_running)
            {
                yield return null; // new WaitForSeconds(1.0f / 100);
                _ticker();
            }
        }
    }
}
