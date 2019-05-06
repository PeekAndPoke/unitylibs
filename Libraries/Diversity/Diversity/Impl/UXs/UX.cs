using De.Kjg.Diversity.Interfaces.Abstraction.Hardware;
using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.UXs;
using De.Kjg.Diversity.Interfaces.UXs.Guis;
using De.Kjg.Diversity.Interfaces.UXs.Scenes;

namespace De.Kjg.Diversity.Impl.UXs
{
    abstract public class Ux : IUx
    {
        protected IGuiStage GuiStage;
        protected IRenderer Renderer;
        protected IHardware Hardware;
        protected IScene Scene;

        protected Ux(IGuiStage guiStage, IRenderer renderer, IHardware hardware, IScene scene)
        {
            GuiStage = guiStage;
            Renderer = renderer;
            Hardware = hardware;
            Scene = scene;
        }

        public IGuiStage GetGuiStage()
        {
            return GuiStage;
        }

        public IRenderer GetRenderer()
        {
            return Renderer;
        }

        public IHardware GetHardware()
        {
            return Hardware;
        }

        public IScene GetScene()
        {
            return Scene;
        }

        public abstract void Update();

        public abstract void UpdateGui();
    }
}
