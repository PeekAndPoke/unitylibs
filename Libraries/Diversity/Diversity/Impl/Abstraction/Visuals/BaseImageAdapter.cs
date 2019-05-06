using De.Kjg.Diversity.Interfaces.Abstraction.Visuals;

namespace De.Kjg.Diversity.Impl.Abstraction.Visuals
{
    public class BaseImageAdapter : VisualsAdapter, IImage
    {
        public BaseImageAdapter(object wrapped) : base(wrapped)
        {
        }

        public virtual float Width { get { return 0; } }

        public virtual float Height { get { return 0; } }
    }
}
