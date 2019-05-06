using System;
using De.Kjg.Diversity.Interfaces.Abstraction.Data;

namespace De.Kjg.Diversity.Impl.Abstraction.Data
{
    ///
    /// TODO: methods to combine rectangles
    ///       (x) Intersect
    ///       ( ) Bounding-Box of Two Rectangles
    ///
    public struct Rectangle : IRectangle
    {
        private float _x;
        private float _y;
        private float _width;
        private float _height;

        public float Left
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Right
        {
            get { return _x + Width; }
            set { Width = value - _x; }
        }

        public float Top
        {
            get { return _y; }
            set { _y = value; }
        }

        public float Bottom
        {
            get { return _y + Height; }
            set { Height = value - _y; }
        }

        public float Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public float Height
        {
            get { return _height; }
            set { _height = value; }
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

        public Rectangle(float x, float y, float width, float height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }

        public bool Contains(IPoint point)
        {
            return
                    point.X >= _x && point.X <= _x + Width
                &&  point.Y >= _y && point.Y <= _y + Height
            ;
        }

        public void Set(float x, float y, float width, float height)
        {
            _x = x;
            _y = y;
            Width = width;
            Height = height;
        }

        public void SetPosition(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public void SetDimension(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public IRectangle Intersect(IRectangle intersectWith)
        {
            var xMin = Math.Max(Left, intersectWith.Left);
            var yMin = Math.Max(Top, intersectWith.Top);
            var xMax = Math.Min(Right, intersectWith.Right);
            var yMax = Math.Min(Bottom, intersectWith.Bottom);
            return new Rectangle(xMin, yMin, xMax - xMin, yMax - yMin);
        }

        public override string ToString()
        {
            return "Rectangle (" + Left + ", " + Top + ", " + Width + ", " + Height + ")";
        }
    }
}
