using De.Kjg.TweenSharkPkg.Options;
using De.Kjg.TweenSharkPkg.Tweener;
using UnityEngine;

namespace De.Kjg.TweenSharkPkg
{
    public enum V3Compnent
    {
        Forward,
        Up,
        Right
    }

    public static class UnityTweenOptsExtension
    {
        /**
         * tween one component of a Vector3 TO a specific value
         */
        public static TweenOps UV3CompTo(this TweenOps tweenOps, string propertyName, float targetValue, V3Compnent component, UnityVector3ComponentTweener tweener = null)
        {
            if (tweener == null)
            {
                tweener = new UnityVector3ComponentTweener(component);
            }

            tweenOps.PropTo(propertyName, new Vector3(targetValue, targetValue, targetValue), tweener);

            return tweenOps;
        }

        /**
         * tween one component of a Vector3 BY a specific value
         */
        public static TweenOps UV3CompBy(this TweenOps tweenOps, string propertyName, float targetValue, V3Compnent component, UnityVector3ComponentTweener tweener = null)
        {
            if (tweener == null)
            {
                tweener = new UnityVector3ComponentTweener(component);
            }

            tweenOps.PropBy(propertyName, new Vector3(targetValue, targetValue, targetValue), tweener);

            return tweenOps;
        }

        /**
         * locally rotate GameObject around one axis TO a specific value
         */
        public static TweenOps URotateTo(this TweenOps tweenOps, float targetValue, V3Compnent axis, UnityGameObjectRotateAxisTweener axisTweener = null)
        {
            if (axisTweener == null)
            {
                axisTweener = new UnityGameObjectRotateAxisTweener(axis);
            }

            tweenOps.PropTo("URotate", new Vector3(targetValue, targetValue, targetValue), axisTweener);

            return tweenOps;
        }

        /**
         * locally rotate GameObject around on axis BY a specific value
         */
        public static TweenOps URotateBy(this TweenOps tweenOps, float targetValue, V3Compnent axis, UnityGameObjectRotateAxisTweener axisTweener = null)
        {
            if (axisTweener == null)
            {
                axisTweener = new UnityGameObjectRotateAxisTweener(axis);
            }

            tweenOps.PropBy("URotate", new Vector3(targetValue, targetValue, targetValue), axisTweener);

            return tweenOps;
        }


        /**
         * move GameObject TO the given position
         */
        public static TweenOps UMoveTo(this TweenOps tweenOps, Vector3 targetValue, UnityGameObjectMoveTweener tweener = null)
        {
            if (tweener == null)
            {
                tweener = new UnityGameObjectMoveTweener();
            }

            tweenOps.PropTo("UMove", targetValue, tweener);

            return tweenOps;
        }

        /**
         * move GameObject BY the given position
         */
        public static TweenOps UMoveBy(this TweenOps tweenOps, Vector3 targetValue, UnityGameObjectMoveTweener tweener = null)
        {
            if (tweener == null)
            {
                tweener = new UnityGameObjectMoveTweener();
            }

            tweenOps.PropBy("UMove", targetValue, tweener);

            return tweenOps;
        }

        /**
         * move on axis of a GameObject TO a given position
         */
        public static TweenOps UMoveTo(this TweenOps tweenOps, float targetValue, V3Compnent component, UnityGameObjectMoveAxisTweener axisTweener = null)
        {
            if (axisTweener == null)
            {
                axisTweener = new UnityGameObjectMoveAxisTweener(component);
            }

            tweenOps.PropTo("UMove", new Vector3(targetValue, targetValue, targetValue), axisTweener);

            return tweenOps;
        }

        /**
         * move on axis of a GameObject BY a given position
         */
        public static TweenOps UMoveBy(this TweenOps tweenOps, float targetValue, V3Compnent component, UnityGameObjectMoveAxisTweener axisTweener = null)
        {
            if (axisTweener == null)
            {
                axisTweener = new UnityGameObjectMoveAxisTweener(component);
            }

            tweenOps.PropBy("UMove", new Vector3(targetValue, targetValue, targetValue), axisTweener);

            return tweenOps;
        }

        /**
         * move on axis of a GameObject TO a given position
         */
        public static TweenOps UColorTo(this TweenOps tweenOps, Color targetValue, UnityGameObjectColorTweener colorTweener = null)
        {
            if (colorTweener == null)
            {
                colorTweener = new UnityGameObjectColorTweener();
            }

            tweenOps.PropTo("UColor", targetValue, colorTweener);

            return tweenOps;
        }

        /**
         * move on axis of a GameObject TO a given position
         */
        public static TweenOps UColorBy(this TweenOps tweenOps, Color targetValue, UnityGameObjectColorTweener colorTweener = null)
        {
            if (colorTweener == null)
            {
                colorTweener = new UnityGameObjectColorTweener();
            }

            tweenOps.PropBy("UColor", targetValue, colorTweener);

            return tweenOps;
        }

        /**
         * move on axis of a GameObject TO a given position
         */
        public static TweenOps UFadeMaterials(this TweenOps tweenOps, Material[] materials, UnityGameObjectFadeMaterialTweener fadeTweener = null)
        {
            if (fadeTweener == null)
            {
                fadeTweener = new UnityGameObjectFadeMaterialTweener(materials);
            }

            tweenOps.PropTo("UColor", Color.white, fadeTweener);

            return tweenOps;
        }
    }
}
