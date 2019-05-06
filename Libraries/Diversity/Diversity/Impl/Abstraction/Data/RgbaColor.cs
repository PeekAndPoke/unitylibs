using De.Kjg.Diversity.Interfaces.Abstraction.Data;

namespace De.Kjg.Diversity.Impl.Abstraction.Data
{
    public struct RgbaColor : IRgbaColor
    {
        private float _r;
        private float _g;
        private float _b;
        private float _a;

        public RgbaColor(float r, float g, float b)
        {
            _r = r;
            _g = g;
            _b = b;
            _a = 1;
        }

        public RgbaColor(float r, float g, float b, float a)
        {
            _r = r;
            _g = g;
            _b = b;
            _a = a;
        }

        public float R
        {
            get { return _r; }
            set { _r = value; }
        }

        public float G
        {
            get { return _g; }
            set { _g = value; }
        }

        public float B
        {
            get { return _b; }
            set { _b = value; }
        }

        public float A
        {
            get { return _a; }
            set { _a = value; }
        }

        public void Set(float r, float g, float b, float a)
        {
            _r = r;
            _g = g;
            _b = b;
            _a = a;
        }
    }
}
