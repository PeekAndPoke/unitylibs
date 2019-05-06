namespace De.Kjg.Diversity.Interfaces.Abstraction.Data
{
    public interface IRgbaColor
    {
        float R { get; set; }
        float G { get; set; }
        float B { get; set; }
        float A { get; set; }

        void Set(float r, float g, float b, float a);
    }
}