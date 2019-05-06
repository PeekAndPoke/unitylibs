using De.Kjg.Diversity.Impl.Abstraction.Data;
using De.Kjg.Diversity.Impl.I18n.Strings;
using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Elements.Basic
{
    /// <summary>
    /// Concrete Label
    /// </summary>
    public sealed class Label : GenericLabel<Label>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Label" /> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="text">The text.</param>
        public Label(float width, float height, StringHolder text) : base(width, height, text)
        {
        }
    }

    /// <summary>
    /// Generic label
    /// </summary>
    /// <typeparam name="TElementType"></typeparam>
    public class GenericLabel<TElementType> : GenericAbstractGuiElement<TElementType> where TElementType : IGuiElement
    {
        private StringHolder _text;

        private bool _hasDropShadow = false;
        private RgbaColor _dropShadowRgbaColor = new RgbaColor(0, 0, 0, 1f);
        private int _dropShadowOffsetX = 2;
        private int _dropShadowOffsetY = 2;

        /// <summary>
        /// C'tor
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="text"></param>
        public GenericLabel(float width, float height, StringHolder text)
        {
            SetWidth(width);
            SetHeight(height);
            SetText(text);
        }

        /// <summary>
        /// Get the text
        /// </summary>
        /// <returns></returns>
        public StringHolder GetText()
        {
            return _text;
        }

        /// <summary>
        /// Set the text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public TElementType SetText(StringHolder text)
        {
            _text = text;
            return AsElementType();
        }

        /// <summary>
        /// Sets a drop shadow on the label
        /// </summary>
        /// <param name="hasDropShadow">True to enable</param>
        /// <param name="alpha">Alpha of the shadow</param>
        /// <param name="offsetX">x offset of the shadow</param>
        /// <param name="offsetY">y offset of the shadow</param>
        /// <returns></returns>
        public TElementType SetDropShadow(bool hasDropShadow = true, float alpha = 0.7f, int offsetX = 2, int offsetY = 2)
        {
            _hasDropShadow = hasDropShadow;
            _dropShadowOffsetX = offsetX;
            _dropShadowOffsetY = offsetY;
            _dropShadowRgbaColor = new RgbaColor(0, 0, 0, alpha);
            return AsElementType();
        }

        /// <summary>
        /// Draws the element
        /// </summary>
        public override void Draw(IRenderer renderer)
        {
            var drawingGeometry = GetLayoutProcessingData().DrawingGeometry;

            renderer.RenderLabel(
                UniqueId,
                drawingGeometry,
                _text,
                GetStyle(),
                _hasDropShadow,
                _dropShadowRgbaColor,
                _dropShadowOffsetX,
                _dropShadowOffsetY
            );
        }
    }
}
