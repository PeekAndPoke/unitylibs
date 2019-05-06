using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Unity.Debug.Interfaces
{
    public interface IDebugWindow : IGuiElementContainer
    {
        void SetTitle(string title);
        void AddPanel(IDebugPanel panel);
    }
}
