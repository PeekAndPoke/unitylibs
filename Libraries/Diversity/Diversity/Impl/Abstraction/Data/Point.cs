using De.Kjg.Diversity.Interfaces.Abstraction.Data;

namespace De.Kjg.Diversity.Impl.Abstraction.Data
{
    public struct Point : IPoint
    {
        private float _x;
        private float _y;

        public Point(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public void Set(float x, float y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return "(" + X + ", " + Y + ")";
        }
    }
}
