using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Interfaces.UXs.Events
{
    public interface IEvent
    {
        bool IsStopped { get; }
        IGuiElement Target { get; set; }
        IGuiElement CurrentTarget { get; set; }
        void StopPropagation();
    }
}