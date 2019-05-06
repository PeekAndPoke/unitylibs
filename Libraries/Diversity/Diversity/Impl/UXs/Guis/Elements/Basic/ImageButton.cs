using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.Abstraction.Visuals;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Elements.Basic
{
    // TODO: Unity3D-Independance

    /// <summary>
    /// Concrete ImageButton
    /// </summary>
    public sealed class ImageButton : GenericImageButton<ImageButton>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageButton" /> class.
        /// </summary>
        /// <param name="style">The style.</param>
        public ImageButton(IStyle style) : base(style)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageButton" /> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="style">The style.</param>
        public ImageButton(float width, float height, IStyle style)
            : base(width, height, style)
        {
        }
    }

    /// <summary>
    /// Generic ImageAdapter
    /// </summary>
    /// <typeparam name="TElementType"></typeparam>
    public class GenericImageButton<TElementType> : GenericAbstractGuiElement<TElementType> where TElementType : IGuiElement
    {
        /// <summary>
        /// SkinAdapter for drawing the ImageAdapter
        /// </summary>
        private IStyle _buttonStyle;

        /// <summary>
        /// C'tor
        /// 
        /// The size is automatically set to the buttonStyle.normal.background
        /// </summary>
        /// <param name="buttonStyle">SkinAdapter with all button states</param>
        public GenericImageButton(IStyle buttonStyle)
        {
            Setup(buttonStyle.GetBackgroundImageSize().X, buttonStyle.GetBackgroundImageSize().Y, buttonStyle);
        }

        /// <summary>
        /// C'tor
        /// </summary>
        /// <param name="width">The buttons width</param>
        /// <param name="height">The buttons height</param>
        /// <param name="buttonStyle">SkinAdapter with all button states</param>
        public GenericImageButton(float width, float height, IStyle buttonStyle)
        {
            Setup(width, height, buttonStyle);
        } 

        /// <summary>
        /// Sets up the button
        /// </summary>
        /// <param name="width">The buttons with</param>
        /// <param name="height">The buttons height</param>
        /// <param name="buttonStyle">The style</param>
        protected void Setup(float width, float height, IStyle buttonStyle)
        {
            SetWidth(width);
            SetHeight(height);

            _buttonStyle = buttonStyle;
        }

        /// <summary>
        /// Draws the elements
        /// </summary>
        public override void Draw(IRenderer renderer)
        {
            var drawingGeometry = GetLayoutProcessingData().DrawingGeometry;

            renderer.RenderButton(
                UniqueId,
                drawingGeometry,
                "",
                _buttonStyle
            );
        }
    }
}
