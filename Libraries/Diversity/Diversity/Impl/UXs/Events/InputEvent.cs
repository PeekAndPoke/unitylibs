using De.Kjg.Diversity.Interfaces.UXs.Events;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Events
{
    public class InputEvent : Event, IInputEvent
    {
        public string Content
        {
            get { return ((IGuiInputElement) Target).GetContent(); }
            set { ((IGuiInputElement) Target).SetContent(value); }
        }
    }
}
