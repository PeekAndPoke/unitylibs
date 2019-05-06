using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Interfaces.MVC.Mediators
{
    public interface IMediator
    {
        void SetGuiElement(IGuiElement guiElement);

        void Initialize();
        void Destroy();
    }
}
