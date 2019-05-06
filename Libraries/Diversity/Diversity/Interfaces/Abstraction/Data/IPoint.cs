namespace De.Kjg.Diversity.Interfaces.Abstraction.Data
{
    public interface IPoint
    {
        float X { get; set; }
        float Y { get; set; }

        void Set(float x, float y);
        string ToString();
    }
}