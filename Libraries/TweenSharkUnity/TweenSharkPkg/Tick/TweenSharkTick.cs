using UnityEngine;

namespace De.Kjg.TweenSharkPkg.Tick
{
    internal class TweenSharkTick : ITweenSharkTick
    {
        private readonly TweenSharkUnity3DTick _ticker;

        private TweenSharkTickDelegate _tickDelegate;

        public TweenSharkTick(TweenSharkUnity3DTick behaviour)
        {
            _ticker = behaviour;
        }

        public void Run (TweenSharkTickDelegate tickDelegate)
        {
            _tickDelegate = tickDelegate;
            _ticker.Run(tickDelegate);
        }

        public void Stop ()
        {
            _ticker.Stop();
        }
    }
}
