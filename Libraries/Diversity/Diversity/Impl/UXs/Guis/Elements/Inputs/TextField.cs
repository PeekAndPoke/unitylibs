using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Elements.Inputs
{
    /// <summary>
    /// Concrete implementation of a text field
    /// </summary>
    public class TextField : GenericTextField<TextField>
    {
        public TextField(int width, int height) : base(width, height)
        {
        }
    }

    /// <summary>
    /// Geneeric implementation of a text field
    /// </summary>
    /// <typeparam name="TElementType"></typeparam>
    public class GenericTextField<TElementType> : GenericAbstractInputElement<TElementType> where TElementType : IGuiInputElement
    {
        public GenericTextField(int width, int height)
        {
            SetWidth(width);
            SetHeight(height);
        }

        public override void Draw(IRenderer renderer)
        {
            var drawingGeometry = GetLayoutProcessingData().DrawingGeometry;

            var newContent = renderer.RenderTextField(
                UniqueId,
                Enabled,
                drawingGeometry,
                Content,
                GetStyle()
            );

            if (newContent != Content)
            {
                Content = newContent;
                DispatchChange();
            }
        }
    }
}
