using System;
using De.Kjg.TweenSharkPkg.Core;
using De.Kjg.TweenSharkPkg.Logging;
using De.Kjg.TweenSharkPkg.Options;
using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.FloatingPoint;
using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Integer;      

namespace De.Kjg.TweenSharkPkg
{
    public delegate void TweenSharkCallback (TweenShark tween);
    public delegate void TweenSharkTickDelegate ();

    public class TweenShark
    {
        public readonly object Obj;
        public readonly TweenOps TweenOps;
        public readonly float Duration;

        #region Public Methods

        internal TweenShark(object obj, float durationInSeconds, TweenOps tweenOps)
        {
            Obj = obj;
            Duration = durationInSeconds;
            TweenOps = tweenOps;
        }

        internal RunningTweenShark RunningTweenShark;

        public bool HasStarted()
        {
            if (RunningTweenShark != null)
            {
                return RunningTweenShark.InternalHasStarted;
            }
            return false;
        }

        public bool IsPlaying()
        {
            if (RunningTweenShark != null)
            {
                return RunningTweenShark.InternalIsPlaying;
            }
            return false;
        }

        public bool IsCompleted()
        {
            if (RunningTweenShark != null)
            {
                return RunningTweenShark.InternalIsCompleted;
            }
            return false;
        }

        public float Progress
        {
            get {
                if (RunningTweenShark != null)
                {
                    return RunningTweenShark.Progress;
                }
                return 0;
            }
        }

        #endregion

        #region Public Static Entrypoint

        /** the singleton instance **/
        private static TweenSharkCore _core;

        public static ILogger Logger = new NullLogger();

        public static void Initialize(ITweenSharkTick ticker, ILogger logger)
        {
            Logger = logger;

            if (_core == null)
            {
                _core = new TweenSharkCore(ticker);
                // register tweener for ints
                RegisterPropertyTweener(typeof(SignedByteTweener),    typeof(SByte));
                RegisterPropertyTweener(typeof(SignedInt16Tweener),   typeof(Int16));
                RegisterPropertyTweener(typeof(SignedInt32Tweener),   typeof(Int32));
                RegisterPropertyTweener(typeof(SignedInt64Tweener),   typeof(Int64));
                // register tweener for unsigned ints
                RegisterPropertyTweener(typeof(UnsignedByteTweener),  typeof(Byte));
                RegisterPropertyTweener(typeof(UnsignedInt16Tweener), typeof(UInt16));
                RegisterPropertyTweener(typeof(UnsignedInt32Tweener), typeof(UInt32));
                RegisterPropertyTweener(typeof(UnsignedInt64Tweener), typeof(UInt64));
                // register tweener for floats
                RegisterPropertyTweener(typeof(FloatTweener), typeof(Single));
                // register tweener for doubles
                RegisterPropertyTweener(typeof(DoubleTweener), typeof(Double));
            }
        }

        public static TweenShark To(object obj, float duration, TweenOps tweenOps)
        {
            var ts = new TweenShark(obj, duration, tweenOps);
            _core.To(ts);
            return ts;
        }

        /**
         * ITweenSharkPropertyTween propertyTween
         */
        public static void RegisterPropertyTweener(Type typeOfTweener, Type forValueType)
        {
            if (_core == null)
            {
                throw new Exception("TweenShark is not initialized yet! Please call Initialized() first.");
            }
            _core.RegisterPropertyTweener(typeOfTweener, forValueType);
        }

        #endregion

    }
}
