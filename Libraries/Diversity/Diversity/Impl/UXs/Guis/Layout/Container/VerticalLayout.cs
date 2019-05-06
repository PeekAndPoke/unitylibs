using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Layout.Container
{
    public class VerticalLayout : ContainerLayout
    {
        protected float Spacing;

        public VerticalLayout(IGuiElement guiElement) : base(guiElement)
        {
        }

        public override float GetCalculatedContentHeight()
        {
            var children = Container.GetChildren();
            var count = children.Count;
            if (count == 0)
            {
                return 0;
            }

            float ret = 0;
            
            for (var i = 0; i < count; i++)
            {
                var child = children[i];
                ret += child.GetLayout().GetCalculatedHeight() + Spacing;
            }
            // substract the last added spacing
            return ret - Spacing;
        }

        public void SetSpacing(float spacing)
        {
            Spacing = spacing;
        }

        public float GetSpacing()
        {
            return Spacing;
        }

        public override void CalculateChildLayouts(float x, float y, float parentWidth, float parentHeight, float absoluteX, float absoluteY)
        {
            x = PaddingLeft;
            y = PaddingTop;

            var contentWidth = GetCalculatedOrPercentualContentWidth(parentWidth, PaddingLeft, PaddingRight);
            var contentHeight = GetCalculatedOrPercentualContentHeight(parentHeight, PaddingTop, PaddingBottom);

            foreach (IGuiElement child in Container.GetChildren())
            {
                var childLayout = child.GetLayout();

                // handle vertical align
                x = PaddingLeft + ProcessChildsHAlign(child.GetLayout(), contentWidth);

                CalculateChild(childLayout, x, y, contentWidth, contentHeight, absoluteX + x, absoluteY + y);

                // do the vertical layout
                y += childLayout.GetCalculatedHeight() + Spacing;
            }
        }

    }
}