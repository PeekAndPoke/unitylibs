using De.Kjg.Diversity.Impl.Abstraction.Data;
using De.Kjg.Diversity.Interfaces.Abstraction.Visuals;

namespace De.Kjg.Diversity.Impl.Abstraction.Visuals
{
    public class BaseStyleAdapter : VisualsAdapter, IStyle
    {
        public BaseStyleAdapter(object wrapped) : base(wrapped)
        {
        }

        public virtual Point GetBackgroundImageSize()
        {
            return new Point(0, 0);
        }
    }
}
