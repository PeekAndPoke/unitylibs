using De.Kjg.Diversity.Impl.UXs.Guis.Elements.Container;
using De.Kjg.Diversity.Interfaces.Abstraction.Hardware;
using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.UXs.Guis;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;
using De.Kjg.Diversity.Unity.Debug.Interfaces;

namespace De.Kjg.Diversity.Unity.Debug.Panels
{
    abstract class AbstractDebugPanel<TPanelType> : GenericBox<TPanelType>, IDebugPanel
        where TPanelType : IGuiElementContainer
    {
        protected IRenderer ClientRenderer;
        protected IHardware ClientHardware;
        protected IGuiStage ClientGuiStage;

        public void SetClientRenderer(IRenderer clientRenderer)
        {
            ClientRenderer = clientRenderer;
        }

        public void SetClientHardware(IHardware clientHardware)
        {
            ClientHardware = clientHardware;
        }

        public void SetClientGuiStage(IGuiStage clientGuiStage)
        {
            ClientGuiStage = clientGuiStage;
        }

        abstract public string GetName();
    }
}
