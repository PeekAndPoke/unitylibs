using System;

namespace De.Kjg.TweenSharkPkg
{
    public delegate float EaseFunction(float deltaTime, float startValue, float valueDelta);

    /**
     * special thanks to Robert Penner and:
     *  - http://upshots.org/actionscript/jsas-understanding-easing
     *  - http://gizma.com/easing/
     *  - http://snippets.dzone.com/posts/show/4005
     *
     * TODO: special easing functions for doubles
     */
    public class Ease
    {
        #region No Easing

        public static float Linear(float deltaTime, float startValue, float valueDelta)
        {
            return valueDelta * deltaTime + startValue;
        }

        #endregion

        #region Quad Easing

        public static float InQuad (float dt, float b, float c) 
        {
            return c * dt * dt + b;
        }

        public static float OutQuad (float dt, float b, float c) 
        {
            return -c * dt * (dt - 2) + b;
        }

        public static float InOutQuad(float dt, float b, float c)
        {
            dt *= 2;
            if (dt < 1) return c / 2.0f * dt * dt + b;
            dt -= 1.0f;
            return -c / 2.0f * (dt * (dt - 2.0f) - 1.0f) + b;
        }

        #endregion

        #region Cubic Easing

        public static float InCubic(float dt, float b, float c)
        {
            return c * dt * dt * dt + b;
        }

        public static float OutCubic (float dt, float b, float c) 
        {
    	    dt -= 1.0f;
    	    return c * (dt * dt * dt + 1) + b;
        }

        public static float InOutCubic (float dt, float b, float c)
        {
            dt *= 2.0f;
	        if (dt < 1.0f) return c / 2.0f * dt * dt * dt + b;
	        dt -= 2.0f;
	        return c / 2.0f * (dt * dt * dt + 2.0f) + b;
        }

        #endregion

        #region Quart Easing

        public static float InQuart (float dt, float b, float c) 
        {
    	    return c * dt * dt * dt * dt + b;
        }

        public static float OutQuart (float dt, float b, float c) 
        {
    	    dt -= 1.0f;
    	    return -c * (dt * dt * dt * dt - 1.0f) + b;
        }

        public static float InOutQuart (float dt, float b, float c) 
        {
    	    dt *= 2.0f;
    	    if (dt < 1.0f) return c / 2.0f * dt * dt * dt * dt + b;
    	    dt -= 2.0f;
    	    return -c / 2.0f * (dt * dt * dt * dt - 2.0f) + b;
        }

        #endregion

        #region Quint Easing

        public static float InQuint (float dt, float b, float c)
        {
    	    return c * dt * dt * dt * dt * dt + b;
        }

    	public static float OutQuint (float dt, float b, float c) 
        {
    	    dt -= 1.0f;
    	    return c * (dt * dt * dt * dt * dt + 1.0f) + b;
        }

    	public static float InOutQuint (float dt, float b, float c) 
        {
    	    dt *= 2.0f;
    	    if (dt < 1.0f) return c / 2.0f * dt * dt * dt * dt * dt + b;
    	    dt -= 2.0f;
    	    return c / 2.0f * (dt * dt * dt * dt * dt + 2.0f) + b;
        }

        #endregion

        #region Sine Easing

        public static float InSine (float dt, float b, float c) 
        {
    	    return -c * (float)Math.Cos(dt * (Math.PI / 2.0f)) + c + b;
        }

    	public static float OutSine (float dt, float b, float c) 
        {
    	    return c * (float)Math.Sin(dt * (Math.PI / 2.0f)) + b;
        }


        public static float InOutSine (float dt, float b, float c) 
        {
    	    return -c / 2.0f * (float)(Math.Cos(Math.PI * dt) - 1.0f) + b;
        }

        #endregion

        #region Expo Easing

        public static float InExpo (float dt, float b, float c)
        {
            if (dt <= 0F) return b;
            return c * (float)Math.Pow(2.0, 10.0 * (dt - 1.0)) + b;
        }

        public static float OutExpo (float dt, float b, float c)
        {
            if (dt >= 1F) return b + c;
    	    return c * (float)( -Math.Pow(2.0, -10.0 * dt) + 1.0) + b;
        }

        public static float InOutExpo (float dt, float b, float c)
        {
            if (dt <= 0F) return b;
            if (dt >= 1F) return b + c;
            dt *= 2.0f;
    	    if (dt < 1.0f) return c / 2.0f * (float)Math.Pow(2.0, 10.0 * (dt - 1.0)) + b;
    	    dt -= 1.0f;
    	    return c / 2.0f * (float)( -Math.Pow(2.0, -10.0 * dt) + 2.0) + b;
        }
    		
        #endregion

        #region Circ Easing

        public static float InCirc (float dt, float b, float c) 
        {
    	    return -c * (float)(Math.Sqrt(1.0 - dt * dt) - 1.0) + b;
        }

        public static float OutCirc (float dt, float b, float c) 
        {
    	    dt -= 1.0f;
    	    return c * (float)Math.Sqrt(1.0 - dt * dt) + b;
        }

        public static float InOutCirc (float dt, float b, float c)
        {
            dt *= 2.0f;
    	    if (dt < 1.0f) return -c / 2.0f * (float)(Math.Sqrt(1 - dt * dt) - 1.0) + b;
    	    dt -= 2.0f;
    	    return c / 2.0f * (float)(Math.Sqrt(1.0 - dt * dt) + 1.0) + b;
        }

        #endregion

        #region Bounce Easing

        public static float InBounce(float dt, float b, float c)
        {
            return c - OutBounce(1.0f - dt, 0, c) + b;
        }

        public static float OutBounce(float dt, float b, float c)
        {
            if ((dt) < (1.0f / 2.75f))
            {
                return c * (7.5625f * dt * dt) + b;
            }
            else if (dt < (2.0f / 2.75f))
            {
                return c * (7.5625f * (dt -= (1.5f / 2.75f)) * dt + .75f) + b;
            }
            else if (dt < (2.5f / 2.75f))
            {
                return c * (7.5625f * (dt -= (2.25f / 2.75f)) * dt + .9375f) + b;
            }
            else
            {
                return c * (7.5625f * (dt -= (2.625f / 2.75f)) * dt + .984375f) + b;
            }
        }

        public static float InOutBounce(float dt, float b, float c)
        {
            if (dt < 0.5f) return InBounce(dt * 2.0f, 0, c) * .5f + b;
            return OutBounce(dt * 2.0f - 1.0f, 0, c) * .5f + c * .5f + b;
        }

        #endregion
    }
}
