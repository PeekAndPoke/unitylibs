using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Elements.Inputs
{
    /// <summary>
    /// Concrete implementation of a text are
    /// </summary>
    public class TextArea : GenericTextArea<TextArea>
    {
        public TextArea(int width, int height) : base(width, height)
        {
        }
    }

    /// <summary>
    /// generic implementation of a text area
    /// </summary>
    /// <typeparam name="TElementType"></typeparam>
    public class GenericTextArea<TElementType> : GenericAbstractInputElement<TElementType> where TElementType : IGuiInputElement
    {
        public GenericTextArea(int width, int height)
        {
            SetWidth(width);
            SetHeight(height);
        }

        public override void Draw(IRenderer renderer)
        {
            var drawingGeometry = GetLayoutProcessingData().DrawingGeometry;

            var newContent = renderer.RenderTextArea(
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
