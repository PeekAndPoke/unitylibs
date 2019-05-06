using De.Kjg.Diversity.Interfaces.Abstraction.Hardware;
using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.UXs.Guis;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Unity.Debug.Interfaces
{
    public interface IDebugPanel : IGuiElement
    {
        void SetClientRenderer(IRenderer clientRenderer);

        void SetClientHardware(IHardware clientHardware);

        void SetClientGuiStage(IGuiStage clientGuiStage);

        string GetName();
    }
}
