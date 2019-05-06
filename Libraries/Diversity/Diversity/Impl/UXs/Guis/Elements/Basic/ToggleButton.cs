using De.Kjg.Diversity.Impl.I18n.Strings;
using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Elements.Basic
{
    /// <summary>
    /// Concrete toggle button
    /// </summary>
    public sealed class ToggleButton : GenericToggleButton<ToggleButton>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToggleButton" /> class.
        /// </summary>
        /// <param name="title">The title.</param>
        public ToggleButton(StringHolder title) : base(title)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToggleButton" /> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="title">The title.</param>
        public ToggleButton(float width, float height, StringHolder title)
            : base(width, height, title)
        {
        }
    }

    /// <summary>
    /// Generic toggle button
    /// </summary>
    /// <typeparam name="TElementType"></typeparam>
    public class GenericToggleButton<TElementType> : GenericAbstractGuiElement<TElementType> where TElementType : IGuiElement
    {
        protected StringHolder Text;

        protected bool IsDown = false;

        /// <summary>
        /// C'tor
        /// </summary>
        /// <param name="text">The text to display</param>
        public GenericToggleButton(StringHolder text)
        {
            SetText(text);
        }

        /// <summary>
        /// C'tor
        /// </summary>
        /// <param name="width">the buttons width</param>
        /// <param name="height">the buttons height</param>
        /// <param name="text">text to display</param>
        public GenericToggleButton(float width, float height, StringHolder text)
        {
            SetWidth(width);
            SetHeight(height);
            SetText(text);
        }

        /// <summary>
        /// Get the buttons state
        /// </summary>
        /// <returns>True for down</returns>
        public bool GetState()
        {
            return IsDown;
        }

        /// <summary>
        /// Set the buttons state
        /// </summary>
        /// <param name="isDown">True for down</param>
        /// <returns></returns>
        public TElementType SetState(bool isDown)
        {
            IsDown = isDown;
            return AsElementType();
        }

        /// <summary>
        /// Get the text
        /// </summary>
        /// <returns></returns>
        public StringHolder GetText()
        {
            return Text;
        }

        /// <summary>
        /// Set the text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public TElementType SetText(StringHolder text)
        {
            Text = text;
            return AsElementType();
        }

        /// <summary>
        /// Draws the element
        /// </summary>
        public override void Draw(IRenderer renderer)
        {
            var drawingGeometry = GetLayoutProcessingData().DrawingGeometry;

            IsDown = renderer.RenderToggleButton(
                UniqueId,
                drawingGeometry,
                IsDown,
                Text,
                GetStyle()
            );
        }
    }
}
