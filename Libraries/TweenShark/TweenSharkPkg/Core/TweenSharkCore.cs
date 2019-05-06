using System;
using System.Collections.Generic;

namespace De.Kjg.TweenSharkPkg.Core
{
    class TweenSharkCore
    {
        /** the clock instance -> calls Tick() over and over again **/
        private readonly ITweenSharkTick _ticker;
        /** dictionary with all objects that are tweened at the moment **/
        private readonly Dictionary<object, TweenedObject> _objects = new Dictionary<object, TweenedObject>();
        /** for faster iteration a list that just contains TweenedObjects **/
        private readonly List<TweenedObject> _objectsTweenedObjects = new List<TweenedObject>();
        /** registered ITweenSharkPropertyTweens **/
        private readonly Dictionary<string, Type> _registeredPropertyTweeners;

        /** hold an instance of list of all tweenedObject that can be removed after tick -> avoid creating a new list every tick */
        private readonly List<TweenedObject> _tweenedObjectMarkedForRemoval = new List<TweenedObject>();


        public TweenSharkCore(ITweenSharkTick ticker)
        {
            _registeredPropertyTweeners = new Dictionary<string, Type>();

            _ticker = ticker;
            _ticker.Run(Tick);
        }

        /**
        * ITweenSharkPropertyTween propertyTween
        */
        public void RegisterPropertyTweener(Type typeOfTweener, Type forValueType)
        {
//            TweenShark.Logger.Log("registering tweener " + typeOfTweener.FullName + " for type " + forValueType.FullName);
            _registeredPropertyTweeners[forValueType.FullName] = typeOfTweener;
        }

        private void Tick()
        {
            lock(this)
            {
                //            Debug.Log("#objects: " + _objects.Count);
                //            Debug.Log("#TweenedObject: " + _objectsTweenedObjects.Count);

                _tweenedObjectMarkedForRemoval.Clear();

                //            Debug.Log("we have " + _tweenedObjects.Values.Count + " objects to tween");

                var currentTicks = DateTime.Now.Ticks;

                var count = _objectsTweenedObjects.Count;
                for (var i = 0; i < count; i++)
                {
                    var tweenedObject = _objectsTweenedObjects[i];
                    if (!tweenedObject.Tick(currentTicks))
                    {
                        _tweenedObjectMarkedForRemoval.Add(tweenedObject);
                    }

                }

                // remove all tweened objects that have no more tweens running
                count = _tweenedObjectMarkedForRemoval.Count;
                for (var i = 0; i < count; i++)
                {
                    var tweenedObject = _tweenedObjectMarkedForRemoval[i];
                    // TweenShark.Logger.Log("removing tweened object " + tweenedObject + " for obj " + tweenedObject.Obj);
                    // remove the instance of TweenedObject for the object
                    _objectsTweenedObjects.Remove(tweenedObject);
                    // remove the object itself
                    _objects.Remove(tweenedObject.Obj);
                }
            }
        }

        public void To(TweenShark tweenShark)
        {
            if (tweenShark.Obj == null)
            {
                TweenShark.Logger.Error("given object is null!");
                return;
            }

            TweenedObject tweenedObject;
            if (!_objects.TryGetValue(tweenShark.Obj, out tweenedObject))
            {
                tweenedObject = new TweenedObject(tweenShark.Obj, _registeredPropertyTweeners);
                _objectsTweenedObjects.Add(tweenedObject);
                _objects[tweenShark.Obj] = tweenedObject;
            }

            // TODO: clone the tweenShark given or make some other class containing all the tweeners
            //- für die interne Verarbeitung brauchen wir Kopien der Tweens
            //	-> so kann der User seine TweenShark instanzen aufheben und wieder benutzen
            //	-> ohne die Kopie bekommt der Nutzer aus seiner Instanz die einzelnen Tweener rausgelöscht, wenn es zu einen overwrite kommt 

            tweenedObject.AddTweenShark(tweenShark);
        }

        internal Dictionary<object, TweenedObject> GetObjects()
        {
            return _objects;
        }

        internal List<TweenedObject> GetObjectsTweenedObjects()
        {
            return _objectsTweenedObjects;
        }
    }
}
