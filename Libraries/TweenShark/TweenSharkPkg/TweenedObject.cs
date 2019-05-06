using System;
using System.Collections.Generic;
using System.Reflection;
using De.Kjg.TweenSharkPkg.Core;
using De.Kjg.TweenSharkPkg.Options;

namespace De.Kjg.TweenSharkPkg
{
    class TweenedObject
    {
        /** maps from property name to the tweener, that is handling the tweening of the property **/
        private readonly Dictionary<string, ITweenSharkTweener> _propertyTweens = new Dictionary<string, ITweenSharkTweener>();
        /** the object that is tweened */
        public readonly object Obj;
        /** store all tweened properties of the object... this is a cache, to know which properties are tweened */
        public readonly Dictionary<string, Type> RegisteredPropertyTweens;
        /** list of tweens running on this object, we need to keep all the tweens for methods like TweenShark.KillAllTweensOf() */
        private readonly List<RunningTweenShark> _tweens = new List<RunningTweenShark>(); 
        /** hold an instance of list of all tweenSharks that can be removed after tick -> avoid creating a new list every tick */
        private readonly List<RunningTweenShark> _tweenSharksMarkedAsComplete = new List<RunningTweenShark>();

        public TweenedObject(object obj, Dictionary<string, Type> registeredPropertyTweens)
        {
            Obj = obj;
            RegisteredPropertyTweens = registeredPropertyTweens;
        }

        /**
         * @return true if there is a tween left on this object, false if not
         */ 
        public bool Tick(long currentTicks)
        {
            _tweenSharksMarkedAsComplete.Clear();

            int count;

            // emit OnStart on tweens that have just started
            count = _tweens.Count;
            for (var i = 0; i < count; i++)
            {
                var ts = _tweens[i];
                // a tween that has not start but is playing will emit the OnStarted signal 
                if (!ts.InternalHasStarted && ts.InternalIsPlaying)
                {
                    ts.InternalHasStarted = true;
                    ts.EmitOnStart();
                }
            }

            // tick them all
            count = _tweens.Count;
            for (var i = 0; i < count; i++ )
            {
                var ts = _tweens[i];
                // if it returns false we mark it for removal
                if (!ts.Tick(currentTicks))
                {
                    _tweenSharksMarkedAsComplete.Add(ts);
                }

                _tweens[i].EmitOnUpdate();
            }

            // remove all tweenSharks that have been marked for removal
            count = _tweenSharksMarkedAsComplete.Count;
            for (var i = 0; i < count; i++)
            {
                var ts = _tweenSharksMarkedAsComplete[i];
                // TweenShark.Logger.Log("removing RunningTweenShark " + ts + " from obj " + Obj);
                // remove from list
                _tweens.Remove(ts);
                // emit the complete signal
                ts.EmitOnComplete();
            }

            return _tweens.Count > 0;
        }

        public void AddTweenShark(TweenShark tweenShark)
        {
            // we can only add tweens on the same object as this instance of TweenedObject is responsible for
            if (!Obj.Equals(tweenShark.Obj))
            {
                return;
            }

            var runningTweenShark = new RunningTweenShark(tweenShark);

            foreach (var propertyOps in tweenShark.TweenOps.PropertyOpses)
            {
                // if there is no easing set on the single property we us the easing of the whole tween
                if (propertyOps.EaseFunc == null && propertyOps.EaseExFunc == null)
                {
                    if (tweenShark.TweenOps.EaseFunc != null)
                    {
                        propertyOps.Ease(tweenShark.TweenOps.EaseFunc);
                    }
                    else
                    {
                        propertyOps.EaseEx(tweenShark.TweenOps.EaseExFunc, tweenShark.TweenOps.EaseExParams);
                    }
                }

                var tweener = CreateTweener(propertyOps);

                // could we create the tweener or did already have one?
                if (tweener != null)
                {
                    // setup the tweener
                    tweener.Create(Obj, propertyOps);

                    // get the full property name including sub name
                    var fullPropertyName = tweener.GetFullPropertyName();

                    // add the tweener to the internal cache list of property tweeners
                    
                    // TODO: overwrite handling
                    // if we nned to override go through all RunningTweenSharks 
                    // TODO: check if there allready exists a tweener for this property
                    _propertyTweens[fullPropertyName] = tweener;

                    runningTweenShark.Add(tweener);
                }
            }

            _tweens.Add(runningTweenShark);
            tweenShark.RunningTweenShark = runningTweenShark;
        }

        protected ITweenSharkTweener CreateTweener(PropertyOps propertyOps)
        {
            // we can have tweens that need a accessor to be created
            // if ne tweener is given we assume we need to create an accessor
            if (propertyOps.Tweener == null)
            {
                return CreateTweenerWithAccessor(propertyOps);
            }

            return propertyOps.Tweener;
        }

        protected ITweenSharkTweener CreateTweenerWithAccessor(PropertyOps propertyOps) 
        {
            // this is the instance of the tweener that will be created
            ITweenSharkTweener tweener = null;

            string propertyName = propertyOps.PropertyName;

            // look inside the given object
            var type = Obj.GetType();
            
            // for the type of the tweened property
            Type fieldType = null;

            // check if it a field or a property
            FieldInfo fieldInfo = type.GetField(propertyName);
            if (fieldInfo != null)
            {
                fieldType = fieldInfo.FieldType;
            }
            else
            {
                PropertyInfo propertyInfo = type.GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    fieldType = propertyInfo.PropertyType; 
                }
            }

            // could we find a property or a field?
            if (fieldType != null && fieldType.FullName != null)
            {
                // yes we could

                // try to determine the tweener type
                // do we have a tweener for this type?
                Type tweenerType;

                RegisteredPropertyTweens.TryGetValue(fieldType.FullName, out tweenerType);

                if (tweenerType != null)
                {
                    try
                    {
                        tweener = (ITweenSharkTweener)Activator.CreateInstance(tweenerType);
                    }
                    catch (Exception e)
                    {
                        TweenShark.Logger.Error("Could not instantiate Tweener " + tweenerType.FullName + " for " + Obj + "::" + propertyName + " which is of type " + fieldType.FullName + " - " + e.Message);
                    }
                }
                else
                {
                    TweenShark.Logger.Error("No tweener found for " + Obj + "::" + propertyName + " which is of type " + fieldType.FullName);
                }
            }
            else
            {
                TweenShark.Logger.Error("obj " + Obj + " has no field or property " + propertyName);    
            }

            return tweener;
        }


    }
}
