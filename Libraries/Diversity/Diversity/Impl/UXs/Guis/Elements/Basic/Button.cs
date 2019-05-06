using De.Kjg.Diversity.Impl.I18n.Strings;
using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Elements.Basic
{
    /// <summary>
    /// Concrete button
    /// </summary>
    public sealed class Button : GenericButton<Button>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Button" /> class.
        /// </summary>
        /// <param name="text">The text.</param>
        public Button(StringHolder text)
            : base(text)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Button" /> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="text">The text.</param>
        public Button(float width, float height, StringHolder text)
            : base(width, height, text)
        {
        }
    }

    /// <summary>
    /// Generic button
    /// </summary>
    /// <typeparam name="TElementType"></typeparam>
    public class GenericButton<TElementType> : GenericAbstractGuiElement<TElementType> where TElementType : IGuiElement
    {
        /// <summary>
        /// The buttons text
        /// </summary>
        protected StringHolder Text;

        /// <summary>
        /// C'tor
        /// </summary>
        /// <param name="text">The text to display on the button</param>
        public GenericButton(StringHolder text)
        {
            SetText(text);
        }

        /// <summary>
        /// C'tor
        /// </summary>
        /// <param name="width">the width of the button</param>
        /// <param name="height">the hight of the button</param>
        /// <param name="text">the text to display on the button</param>
        public GenericButton(float width, float height, StringHolder text)
        {
            SetWidth(width);
            SetHeight(height);
            SetText(text);
        }

        /// <summary>
        /// Get the buttons text
        /// </summary>
        /// <returns></returns>
        public StringHolder GetText()
        {
            return Text;
        }

        /// <summary>
        /// Set the buttons text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The button itself</returns>
        public TElementType SetText(StringHolder text)
        {
            Text = text;
            return AsElementType();
        }

        /// <summary>
        /// Draws the element.
        /// 
        /// If no style is set the style with name "button" in current SkinAdapter is used.
        /// </summary>
        public override void Draw(IRenderer renderer)
        {
            var drawingGeometry = GetLayoutProcessingData().DrawingGeometry;

            renderer.RenderButton(
                UniqueId,
                drawingGeometry,
                Text,
                GetStyle()
            );

        }
    }
}
