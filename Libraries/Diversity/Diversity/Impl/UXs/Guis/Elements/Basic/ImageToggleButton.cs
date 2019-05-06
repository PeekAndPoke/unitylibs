using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.Abstraction.Visuals;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Elements.Basic
{
    // TODO: Unity3D-Independance

    /// <summary>
    /// Concrete ImageToggleButton
    /// </summary>
    public sealed class ImageToggleButton : GenericImageToggleButton<ImageToggleButton>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageToggleButton" /> class.
        /// </summary>
        /// <param name="image">The image.</param>
        public ImageToggleButton(IImage image)
            : base(image)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageToggleButton" /> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="image">The image.</param>
        public ImageToggleButton(float width, float height, IImage image)
            : base(width, height, image)
        {
        }
    }

    /// <summary>
    /// Generic ImageAdapter toggle button
    /// </summary>
    /// <typeparam name="TElementType"></typeparam>
    public class GenericImageToggleButton<TElementType> : GenericAbstractGuiElement<TElementType> where TElementType : IGuiElement
    {
        /// <summary>
        /// ImageAdapter used to draw the button
        /// </summary>
        protected IImage Image;
        /// <summary>
        /// flag if the button is down or up
        /// </summary>
        protected bool IsDown = false;

        /// <summary>
        /// c'tor
        /// </summary>
        /// <param name="image">the texture to use</param>
        public GenericImageToggleButton(IImage image)
        {
            Image = image;
            SetWidth(image.Width);
            SetHeight(image.Height);
        }

        /// <summary>
        /// c'tor
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="image">the texture to use</param>
        public GenericImageToggleButton(float width, float height, IImage image)
        {
            Image = image;
            SetWidth(width);
            SetHeight(height);
        }

        /// <summary>
        /// Get the toggle state
        /// </summary>
        /// <returns></returns>
        public bool GetState()
        {
            return IsDown;
        }

        /// <summary>
        /// Set the toggle state
        /// </summary>
        /// <param name="isDown"></param>
        /// <returns></returns>
        public TElementType SetState(bool isDown)
        {
            IsDown = isDown;
            return AsElementType();
        }

        /// <summary>
        /// Draw the element
        /// </summary>
        public override void Draw(IRenderer renderer)
        {
            var drawingGeometry = GetLayoutProcessingData().DrawingGeometry;

            IsDown = renderer.RenderImageToggleButton(
                UniqueId,
                drawingGeometry,
                IsDown,
                Image,
                GetStyle()
            );
        }
    }
}
