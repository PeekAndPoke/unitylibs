using De.Kjg.TweenSharkPkg.Options;
using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Base;

namespace De.Kjg.TweenSharkPkg
{
    public interface ITweenSharkTweener
    {
        void Create(object obj, PropertyOps propOps);
        void Setup();
        void Init();

        /**
         * @param deltaTime the time passed by (value between 0 and 1)
         */
        void CalculateAndSetValue(float deltaTime);
        CalculationDelegate CalculateAndSetValueDelegate { get; }

        /** 
         * The name of the subproperty that is tweened.
         * This name is necessary if you are tweening value of objects, that are not individually accessable.
         * F.E. Unity3Ds GameObject.transform.localEulerAngel is such an object. You can set the whole object of type Vector3.
         * But you can not set single properties of this Vector3.
         * 
         * So to prevent that Tweens are overwritten, one can specify the subproperties.
         */
        string GetSubPropertyName();
        string GetFullPropertyName();
    }
}
