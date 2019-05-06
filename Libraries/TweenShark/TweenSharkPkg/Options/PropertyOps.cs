namespace De.Kjg.TweenSharkPkg.Options
{
    public class PropertyOps
    {
        /** the tweener used to calculate the values **/
        public readonly ITweenSharkTweener Tweener;
        /** the name of the property of the operation **/
        public readonly string PropertyName;
        /** the target value or the relative value **/
        public readonly object TargetValue;
        /** true if the tweening should be done relative to the current value **/
        public readonly bool IsRelative;
        /** the easing function used for tweening the value **/
        public EaseFunction EaseFunc { get; private set; }
        /** extended easing function **/
        public EaseExFunction EaseExFunc { get; private set; }
        /** extended easing params **/
        public object[] EaseExParams { get; private set; }
        /** a custom start value - null if no start value is set **/
        public object StartValue { get; private set; }

        public PropertyOps(string propertyName, object targetValue, bool isRelative)
        {
            PropertyName = propertyName;
            TargetValue = targetValue;
            IsRelative = isRelative;
        }

        public PropertyOps(string propertyName, object targetValue, ITweenSharkTweener tweener, bool isRelative)
        {
            Tweener = tweener;
            PropertyName = propertyName;
            TargetValue = targetValue;
            IsRelative = isRelative;
        }

        public PropertyOps Ease (EaseFunction easeFunc)
        {
            EaseFunc = easeFunc;
            return this;
        }

        public PropertyOps EaseEx(EaseExFunction easeExFunc, object [] easeExParams)
        {
            EaseExFunc = easeExFunc;
            EaseExParams = easeExParams;
            return this;
        }

        public PropertyOps Start (object startValue)
        {
            StartValue = startValue;
            return this;
        }
    }
}
