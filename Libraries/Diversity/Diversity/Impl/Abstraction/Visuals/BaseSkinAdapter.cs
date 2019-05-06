using De.Kjg.Diversity.Interfaces.Abstraction.Visuals;

namespace De.Kjg.Diversity.Impl.Abstraction.Visuals
{
    public class BaseSkinAdapter : VisualsAdapter, ISkin
    {
        public BaseSkinAdapter(object wrapped) : base(wrapped)
        {
        }
    }
}
