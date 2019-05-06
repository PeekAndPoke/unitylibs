using De.Kjg.Diversity.Impl.Abstraction.Data;
using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Elements.Container
{
    /// <summary>
    /// Concrete Box.
    /// 
    /// A box is container. It has its background displayed by standard.
    /// All children in a box have must have their own position defined.
    /// </summary>
    public sealed class Box : GenericBox<Box>
    {

    }

    /// <summary>
    /// Generic Box
    /// </summary>
    /// <typeparam name="TContainerType"></typeparam>
    public class GenericBox<TContainerType> : GenericAbstractGuiContainer<TContainerType> where TContainerType : IGuiElementContainer
    {
        protected bool DrawBackground = true;

        private Rectangle _backgroundRect = new Rectangle();

        /// <summary>
        /// Draws the container and its children
        /// </summary>
        public override void Draw(IRenderer renderer)
        {
            var drawingGeometry = GetLayoutProcessingData().DrawingGeometry;

            renderer.BeginGroup(
                UniqueId, 
                drawingGeometry
                );

            DoDrawBackground(renderer, 0, 0, drawingGeometry.Width, drawingGeometry.Height);

            base.Draw(renderer);

            renderer.EndGroup();
        }

        /// <summary>
        /// Enable or display drawing of the background
        /// </summary>
        /// <param name="show">True to show the background</param>
        /// <returns></returns>
        public TContainerType SetDrawBackground(bool show = true)
        {
            DrawBackground = show;
            return AsElementType();
        }

        protected virtual void DoDrawBackground(IRenderer renderer, float x, float y, float w, float h)
        {
            if (DrawBackground)
            {
                _backgroundRect.Set(0, 0, w, h);
                renderer.RenderBox(
                    UniqueId,
                    _backgroundRect, 
                    "", 
                    GetStyle()
                );
            }
        }
    }
}
