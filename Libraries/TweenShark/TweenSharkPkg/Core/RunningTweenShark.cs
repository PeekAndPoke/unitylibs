using System;
using System.Collections.Generic;
using De.Kjg.TweenSharkPkg.Options;

namespace De.Kjg.TweenSharkPkg.Core
{
    class RunningTweenShark
    {
        private readonly TweenShark _tweenShark;
        private readonly TweenOps _tweenOps;
        private readonly List<ITweenSharkTweener> _propertyTweeners = new List<ITweenSharkTweener>();

        public readonly long StartTicks;
        public readonly uint DurationTicks;
        private uint _deltaTicks;

        private readonly TweenSharkCallback _onStart;
        private readonly TweenSharkCallback _onUpdate;
        private readonly TweenSharkCallback _onComplete;

        public bool InternalHasStarted = false;
        public bool InternalIsPlaying = true;
        public bool InternalIsCompleted = false;

        public RunningTweenShark(TweenShark tweenShark)
        {
            _tweenShark = tweenShark;
            _tweenOps = tweenShark.TweenOps;

            StartTicks = DateTime.Now.Ticks;
            DurationTicks = (uint)(1000 * 10000 * tweenShark.Duration);
            _deltaTicks = 0;

            _onStart = _tweenOps.OnStartCallback;
            _onUpdate = _tweenOps.OnUpdateCallback;
            _onComplete = _tweenOps.OnCompleteCallback;
        }

        public TweenShark GetTweenShark()
        {
            return _tweenShark;
        }

        public void Add(ITweenSharkTweener tweener)
        {
            _propertyTweeners.Add(tweener);
        }

        public bool Remove(ITweenSharkTweener tweener)
        {
            _propertyTweeners.Remove(tweener);
            return _propertyTweeners.Count > 0;
        }

        internal bool Tick(long currentTicks)
        {
            // if there is no tweener left in the tween it is also done
            if (_propertyTweeners.Count == 0)
            {
                return false;
            }

            _deltaTicks = (uint)(currentTicks - StartTicks);

            var retVal = true;
            long ticksToUse;

            if (_deltaTicks >= DurationTicks)
            {
                ticksToUse = DurationTicks;
                retVal = false;
            }
            else
            {
                ticksToUse = _deltaTicks;
            }

            float deltaTime = (float)ticksToUse / DurationTicks;

            for (var i = 0; i < _propertyTweeners.Count; i++)
            {
                try
                {
                    //                _propertyTweeners[i].CalculateAndSetValue(deltaTime);
                    _propertyTweeners[i].CalculateAndSetValueDelegate(deltaTime);
                }
                catch (Exception)
                {
                    // TODO: we need some kind of logging here
                    // TODO: actually the tweener should take care that nothing happens
                    return false;
                }
            }

            return retVal;
        }

        public float Progress
        {
            get { return Math.Max(0, Math.Min(1.0f, (float)_deltaTicks / DurationTicks)); }
        }

        internal void EmitOnStart()
        {
            if (_onStart != null)
            {
                _onStart(_tweenShark);
            }
        }
        internal void EmitOnUpdate()
        {
            if (_onUpdate != null)
            {
                _onUpdate(_tweenShark);
            }
        }
        internal void EmitOnComplete()
        {
            if (_onComplete != null)
            {
                _onComplete(_tweenShark);
            }
        }
    }
}
