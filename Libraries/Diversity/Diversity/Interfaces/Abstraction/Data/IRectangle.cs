namespace De.Kjg.Diversity.Interfaces.Abstraction.Data
{
    public interface IRectangle
    {
        float Left { get; set; }
        float Right { get; set; }
        float Top { get; set; }
        float Bottom { get; set; }

        float X { get; }
        float Y { get; }
        float Width { get; }
        float Height { get; }

        bool Contains(IPoint point);
        void Set(float x, float y, float width, float height);
        void SetPosition(float x, float y);
        void SetDimension(float width, float height);
        IRectangle Intersect(IRectangle intersectWith);
        string ToString();
    }
}
