using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Elements.Basic
{
    /// <summary>
    /// Concrete spacer
    /// </summary>
    public sealed class Spacer : GenericSpacer<Spacer>
    {
        public Spacer(float width, float height) : base(width, height)
        {
        }
    }

    /// <summary>
    /// Generic spacer
    /// </summary>
    /// <typeparam name="TElementType"></typeparam>
    public class GenericSpacer<TElementType> : GenericAbstractGuiElement<TElementType> where TElementType : IGuiElement
    {
        public GenericSpacer(float width, float height)
        {
            SetWidth(width);
            SetHeight(height);
        }

        public override void Draw(IRenderer renderer)
        {
            var drawingGeometry = GetLayoutProcessingData().DrawingGeometry;

            renderer.RenderSpacer(
                UniqueId,
                drawingGeometry
                );
        }
    }
}
