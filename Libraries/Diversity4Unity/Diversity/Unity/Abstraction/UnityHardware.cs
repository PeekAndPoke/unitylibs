using De.Kjg.Diversity.Impl.Abstraction.Data;
using De.Kjg.Diversity.Interfaces.Abstraction.Hardware;
using UnityEngine;

namespace De.Kjg.Diversity.Unity.Abstraction
{
    public class UnityHardware : IHardware
    {
        private Point _tempPoint = new Point();

        public virtual Point GetMousePosition()
        {
            _tempPoint.Set(Input.mousePosition.x, Input.mousePosition.y);
            return _tempPoint;
        }

        public virtual bool GetLeftMouseButton()
        {
            return Input.GetMouseButton(0);
        }

        public virtual bool GetMiddleMouseButton()
        {
            return Input.GetMouseButton(2);
        }

        public virtual bool GetRightMouseButton()
        {
            return Input.GetMouseButton(1);
        }

        public virtual Point GetApplicationDisplaySize()
        {
            _tempPoint.Set(Screen.width, Screen.height);
            return _tempPoint;
        }
    }
}
