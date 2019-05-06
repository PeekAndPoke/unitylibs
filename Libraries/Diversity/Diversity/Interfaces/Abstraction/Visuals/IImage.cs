namespace De.Kjg.Diversity.Interfaces.Abstraction.Visuals
{
    public interface IImage
    {
        object GetWrapped();

        float Width { get; }

        float Height { get; }
    }
}
