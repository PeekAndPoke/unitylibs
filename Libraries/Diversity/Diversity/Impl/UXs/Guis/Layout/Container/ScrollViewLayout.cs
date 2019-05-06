using De.Kjg.Diversity.Interfaces.Abstraction.Data;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Layout;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Layout.Container
{
    public class ScrollViewLayout : ContainerLayout
    {
        public IPoint ScrollPosition;

        public ScrollViewLayout(IGuiElement guiElement)
            : base(guiElement)
        {
        }

        protected override void CalculateChild(
            ILayout childLayout, float xPos, float yPos, float contentWidth, float contentHeight, float absoluteX, float absoluteY)
        {
            base.CalculateChild(
                childLayout, 
                xPos, 
                yPos, 
                contentWidth, 
                contentHeight, 
                absoluteX - ScrollPosition.X, 
                absoluteY - ScrollPosition.Y
            );
        }
    }
}