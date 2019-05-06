using System;

namespace De.Kjg.TweenSharkPkg
{
    public delegate float EaseExFunction(float deltaTime, float startValue, float valueDelta, object[] easeParams);

    /**
     * special thanks to Robert Penner and:
     *  - http://upshots.org/actionscript/jsas-understanding-easing
     *  - http://gizma.com/easing/
     *  - http://snippets.dzone.com/posts/show/4005
     *
     * TODO: special easing functions for doubles
     */
    public class EaseEx
    {
        #region Elastic Easing

        // t: current time, b: beginning value, c: change in value, d: duration, a: amplitude (optional), p: period (optional)
        // t and d can be in frames or seconds/milliseconds

        public static float InElastic (float dt, float b, float c, object[] easeParams) 
        {
            float a = easeParams.Length > 0 ? (float) easeParams[0] : 0.3f;
            float p = easeParams.Length > 1 ? (float) easeParams[1] : 0.3f;
            
            if (Equals(dt, 0.0f)) return b;  
            if (Equals(dt, 1.0f)) return b + c;
            double s;
        	if (a < Math.Abs(c))
        	{
        	    a = c; 
                s = p / 4;
        	}
        	else
        	{
        	    s = p / (2.0 * Math.PI) * Math.Asin (c / a);
        	}

            return (float)(-(a * Math.Pow(2, 10 * (dt -= 1.0f)) * Math.Sin((dt - s) * (2 * Math.PI) / p)) + b);
        }
        
        public static float OutElastic (float dt, float b, float c, object[] easeParams) 
        {
            float a = easeParams.Length > 0 ? (float) easeParams[0] : 0.3f;
            float p = easeParams.Length > 1 ? (float) easeParams[1] : 0.3f;
        	if (Equals(dt, 0.0f)) return b;  
            if (Equals(dt, 1.0f)) return b + c;  
            double s;
        	if (a < Math.Abs(c))
        	{
        	    a = c; 
                s = p / 4;
        	}
        	else
        	{
        	    s = p / (2 * Math.PI) * Math.Asin (c/a);
        	}
        	return (float) (a * Math.Pow(2,-10 * dt) * Math.Sin((dt - s) * (2 * Math.PI) / p) + c + b);
        }
        
//                Math.easeInOutElastic = function (t, b, c, d, a, p) {
//        	        if (t==0) return b;  if ((t/=d/2)==2) return b+c;  if (!p) p=d*(.3*1.5);
//        	        if (a < Math.abs(c)) { a=c; var s=p/4; }
//        	        else var s = p/(2*Math.PI) * Math.asin (c/a);
//        	        if (t < 1) return -.5*(a*Math.pow(2,10*(t-=1)) * Math.sin( (t*d-s)*(2*Math.PI)/p )) + b;
//        	        return a*Math.pow(2,-10*(t-=1)) * Math.sin( (t*d-s)*(2*Math.PI)/p )*.5 + c + b;
//                };

        #endregion

        #region Back Easing

        // back easing in - backtracking slightly, then reversing direction and moving to target
        // t: current time, b: beginning value, c: change in value, d: duration, s: overshoot amount (optional)
        // t and d can be in frames or seconds/milliseconds
        // s controls the amount of overshoot: higher s means greater overshoot
        // s has a default value of 1.70158, which produces an overshoot of 10 percent
        // s==0 produces cubic easing with no overshoot

        //        Math.easeInBack = function (t, b, c, d, s) {
        //	        if (s == undefined) s = 1.70158;
        //	        return c*(t/=d)*t*((s+1)*t - s) + b;
        //        };
        //
        //        // back easing out - moving towards target, overshooting it slightly, then reversing and coming back to target
        //        Math.easeOutBack = function (t, b, c, d, s) {
        //	        if (s == undefined) s = 1.70158;
        //	        return c*((t=t/d-1)*t*((s+1)*t + s) + 1) + b;
        //        };
        //
        //        // back easing in/out - backtracking slightly, then reversing direction and moving to target,
        //        // then overshooting target, reversing, and finally coming back to target
        //        Math.easeInOutBack = function (t, b, c, d, s) {
        //	        if (s == undefined) s = 1.70158; 
        //	        if ((t/=d/2) < 1) return c/2*(t*t*(((s*=(1.525))+1)*t - s)) + b;
        //	        return c/2*((t-=2)*t*(((s*=(1.525))+1)*t + s) + 2) + b;
        //        };

        #endregion



    }
}
