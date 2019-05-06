using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using De.Kjg.TweenSharkPkg;

namespace TweenSharkWinFormsPlayground
{
    class TweenSharkWinformsTick : ITweenSharkTick
    {
        private readonly int _fps;
        private Timer _timer;

        public TweenSharkWinformsTick(int fps = 100)
        {
            _fps = fps;
        }

        public void Run(TweenSharkTickDelegate tickDelegate)
        {
            _timer = new Timer();
            _timer.Interval = 1000/_fps;
            _timer.Tick += (source, e) => tickDelegate();

            _timer.Enabled = true;

            GC.KeepAlive(_timer);
        }

        public void Stop()
        {
            _timer.Enabled = false;
        }
    }
}
