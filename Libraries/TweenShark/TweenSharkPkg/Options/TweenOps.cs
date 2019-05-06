using System.Collections.Generic;

namespace De.Kjg.TweenSharkPkg.Options
{
    public class TweenOps
    {
        /** list of tweener options **/
        public readonly List<PropertyOps> PropertyOpses = new List<PropertyOps>();
        /** easing function **/
        public EaseFunction EaseFunc { get; private set; }
        /** extended easing function **/
        public EaseExFunction EaseExFunc { get; private set; }
        /** extended easing params **/
        public object[] EaseExParams { get; private set; }
        /** onStart callback -> emitted when the tween starts **/
        public TweenSharkCallback OnStartCallback;
        /** onUpdate callback -> emitted every tick **/
        public TweenSharkCallback OnUpdateCallback;
        /** onUpdate callback -> emitted every tick **/
        public TweenSharkCallback OnCompleteCallback;

        #region ctros
 
        public TweenOps ()
        {
            EaseFunc = TweenSharkPkg.Ease.Linear;
        }

        public TweenOps(EaseFunction easeFunc)
        {
            EaseFunc = easeFunc;
        }

        public TweenOps(EaseExFunction easeFunc, object [] easeExParams = null)
        {
            EaseFunc = null;
            EaseExFunc = easeFunc;
            EaseExParams = easeExParams ?? new object[] {}; 
        }

        #endregion

        #region Add Properties

        public TweenOps Prop(PropertyOps ops)
        {
            PropertyOpses.Add(ops);
            return this;
        }

        public TweenOps PropTo(string propertyName, object targetValue)
        {
            PropertyOpses.Add(new PropertyOps(propertyName, targetValue, false));
            return this;
        }

        public TweenOps PropBy(string propertyName, object targetValue)
        {
            PropertyOpses.Add(new PropertyOps(propertyName, targetValue, true));
            return this;
        }

        public TweenOps PropTo(string propertyName, object targetValue, ITweenSharkTweener tweenerType)
        {
            var po = new PropertyOps(propertyName, targetValue, tweenerType, false);
            PropertyOpses.Add(po);
            return this;
        }

        public TweenOps PropBy(string propertyName, object targetValue, ITweenSharkTweener tweenerType)
        {
            var po = new PropertyOps(propertyName, targetValue, tweenerType, true);
            PropertyOpses.Add(po);
            return this;
        }

        #endregion

        #region Easing

        public TweenOps Ease(EaseFunction easeFunc)
        {
            EaseFunc = easeFunc;
            return this;
        }

        #endregion

        #region Callbacks

        public TweenOps OnStart(TweenSharkCallback onStart)
        {
            OnStartCallback = onStart;
            return this;
        }

        public TweenOps OnUpdate(TweenSharkCallback onUpdate)
        {
            OnUpdateCallback = onUpdate;
            return this;
        }

        public TweenOps OnComplete(TweenSharkCallback onComplete)
        {
            OnCompleteCallback = onComplete;
            return this;
        }

        #endregion
    }

}
