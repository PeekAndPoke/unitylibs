using System;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Layout;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Layout.Container
{
    /// <summary>
    /// Base implementation of a container layouts
    /// </summary>
    public class ContainerLayout : BaseLayout, IContainerLayout
    {
        /// <summary>
        /// The gui element container
        /// </summary>
        protected readonly IGuiElementContainer Container;

        public ContainerLayout(IGuiElement guiElement) : base(guiElement)
        {
            if (!(guiElement is IGuiElementContainer))
            {
                throw new ArgumentException("ContainerLayouts can only be applied to classes implementing the IGuiElementContainer interface");
            }
            Container = (IGuiElementContainer) guiElement;
        }

        public override float GetCalculatedContentWidth()
        {
            float ret = 0;
            // go through all that do not have percentual width
            foreach (IGuiElement child in Container.GetChildren())
            {
                var childLayout = child.GetLayout();
                if (!childLayout.HasPercentualWidth)
                {
                    ret = Math.Max(ret, childLayout.X + childLayout.GetCalculatedWidth());
                }
            }
            return ret;
        }

        public override float GetCalculatedContentHeight()
        {
            float ret = 0;
            // go through all that do not have percentual height
            foreach (IGuiElement child in Container.GetChildren())
            {
                var childLayout = child.GetLayout();
                if (!childLayout.HasPercentualHeight)
                {
                    ret = Math.Max(ret, child.Y + childLayout.GetCalculatedHeight());
                }
            }
            return ret;
        }

        public virtual void CalculateChildLayouts(float x, float y, float parentWidth, float parentHeight, float absoluteX, float absoluteY)
        {
            var contentWidth = GetCalculatedOrPercentualContentWidth(parentWidth, PaddingLeft, PaddingRight);
            var contentHeight = GetCalculatedOrPercentualContentHeight(parentHeight, PaddingTop, PaddingBottom);

            foreach (IGuiElement child in Container.GetChildren())
            {
                var childLayout = child.GetLayout();

                // handle horizontal align
                var xPos = PaddingLeft + ProcessChildsHAlign(childLayout, contentWidth);
                // handle vertical align
                var yPos = PaddingTop + ProcessChildsVAlign(childLayout, contentHeight);

                CalculateChild(childLayout, xPos, yPos, contentWidth, contentHeight, xPos + absoluteX, yPos + absoluteY);
            }
        }

        protected virtual void CalculateChild(ILayout childLayout, float x, float y, float contentWidth, float contentHeight, float absoluteX, float absoluteY)
        {
            // check if item has a percentual width
            var calcedWidth = childLayout.HasPercentualWidth ? contentWidth * childLayout.PercentualWidth : childLayout.GetCalculatedWidth();
            // check if item hat a percentual height
            var calcedHeight = childLayout.HasPercentualHeight ? contentHeight * childLayout.PercentualHeight : childLayout.GetCalculatedHeight();

            var processingData = childLayout.GetProcessingData();

            processingData.SetAbsoluteGeometry(absoluteX, absoluteY, calcedWidth, calcedHeight);
            processingData.SetDrawingGeometry(x, y, calcedWidth, calcedHeight);
            processingData.SetClipRect(absoluteX, absoluteY, calcedWidth, calcedHeight);

            if (childLayout is IContainerLayout)
            {
                ((IContainerLayout)childLayout).CalculateChildLayouts(x, y, calcedWidth, calcedHeight, absoluteX, absoluteY);
            }
        }

        protected float ProcessChildsHAlign(ILayout childLayout, float contentWidth)
        {
            float xPos = 0;
            switch (childLayout.HorizontalAlign)
            {
                case HorizontalAlign.None:
                    xPos = childLayout.X;
                    break;
                case HorizontalAlign.Left:
                    xPos = 0;
                    break;
                case HorizontalAlign.Center:
                    xPos = (contentWidth - childLayout.GetCalculatedWidth()) * 0.5f;
                    break;
                case HorizontalAlign.Right:
                    xPos = contentWidth - childLayout.GetCalculatedWidth();
                    break;
            }
            return xPos;
        }

        protected float ProcessChildsVAlign(ILayout childLayout, float contentHeight)
        {
            float yPos = 0;
            switch (childLayout.VerticalAlign)
            {
                case VerticalAlign.None:
                    yPos = childLayout.Y;
                    break;
                case VerticalAlign.Top:
                    yPos = 0;
                    break;
                case VerticalAlign.Middle:
                    yPos = (contentHeight - childLayout.GetCalculatedHeight()) * 0.5f;
                    break;
                case VerticalAlign.Bottom:
                    yPos = contentHeight - childLayout.GetCalculatedHeight();
                    break;
            }
            return yPos;
        }
    }
}