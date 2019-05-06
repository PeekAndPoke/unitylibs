using De.Kjg.Diversity.Impl.Abstraction.Data;
using De.Kjg.Diversity.Interfaces.Abstraction.Hardware;

namespace De.Kjg.Diversity.Impl.Abstraction.Hardware
{
    public class NullHardware : IHardware
    {
        private readonly float _displayWidth;
        private readonly float _displayHeight;

        public NullHardware(float displayWidth, float displayHeight)
        {
            _displayWidth = displayWidth;
            _displayHeight = displayHeight;
        }

        public Point GetMousePosition()
        {
            return new Point();
        }

        public bool GetLeftMouseButton()
        {
            return false;
        }

        public bool GetMiddleMouseButton()
        {
            return false;
        }

        public bool GetRightMouseButton()
        {
            return false;
        }

        public Point GetApplicationDisplaySize()
        {
            return new Point(_displayWidth, _displayHeight);
        }
    }
}
