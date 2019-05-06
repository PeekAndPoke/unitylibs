using De.Kjg.Diversity.Interfaces.MVC.Mediators;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.MVC.Mediators
{
    public class GenericMediator<TGuiElementType> : AbstractBaseMediator, IMediator where TGuiElementType : IGuiElement
    {
        protected TGuiElementType GuiElement;


        public void SetGuiElement(IGuiElement guiElement)
        {
            GuiElement = (TGuiElementType)guiElement;
        }

        public virtual void Initialize()
        {
        }
    }
}
