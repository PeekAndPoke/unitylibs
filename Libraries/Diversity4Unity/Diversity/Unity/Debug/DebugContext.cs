using De.Kjg.Diversity.Impl.MVC;
using De.Kjg.Diversity.Interfaces.DI;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;
using De.Kjg.Diversity.Interfaces.UXs.Scenes;

namespace De.Kjg.Diversity.Unity.Debug
{
    public class DebugContext : DefaultContext
    {
        public DebugContext(IGuiElement guiElement, IScene scene, IDependencyInjectionKernel dependencyInjectionKernel) : 
            base(guiElement, scene, dependencyInjectionKernel)
        {
        }
    }
}
