using De.Kjg.TweenSharkPkg.Tweener.@base;
using UnityEngine;

namespace De.Kjg.TweenSharkPkg.Tweener
{
    public class UnityGameObjectMoveTweener : UnityGameObjectVector3Tweener
    {
        private float _deltaX;
        private float _deltaY;
        private float _deltaZ;
        private float _startX;
        private float _startY;
        private float _startZ;

        private Vector3 _current = Vector3.zero;

        public override void Init()
        {
            base.Init();

            _startX = StartValue.x;
            _startY = StartValue.y;
            _startZ = StartValue.z;
            _deltaX = TargetValue.x - _startX;
            _deltaY = TargetValue.y - _startY;
            _deltaZ = TargetValue.z - _startZ;
        }

        public override void CalculateAndSetValue(float deltaTime)
        {
            // var currentVal = GetValue();

            _current.x = Ease(deltaTime, _startX, _deltaX);
            _current.y = Ease(deltaTime, _startY, _deltaY);
            _current.z = Ease(deltaTime, _startZ, _deltaZ);

            Transform.position = _current;
        }

        protected override Vector3 GetValue()
        {
            return Transform.position;
        }

        protected override void SetValue(Vector3 val)
        {
            Transform.position = val;
        }
    }
}
