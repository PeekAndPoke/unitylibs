using De.Kjg.Diversity.Interfaces.UXs.Events;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Events
{
    public class Event : IEvent
    {
        public bool IsStopped { get; private set; }

        public IGuiElement Target { get; set; }
        public IGuiElement CurrentTarget { get; set; }

        public Event()
        {
            IsStopped = false;
        }

        public void StopPropagation()
        {
            IsStopped = true;
        }
    }
}
