using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.Abstraction.Visuals;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Elements.Basic
{
    // TODO: Unity3D-Independance

    /// <summary>
    /// Concrete image
    /// </summary>
    public sealed class Image : GenericImage<Image>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Image" /> class.
        /// </summary>
        /// <param name="image">The image.</param>
        public Image(IImage image) : base(image)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Image" /> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="image">The image.</param>
        public Image(float width, float height, IImage image)
            : base(width, height, image)
        {
        }
    }

    /// <summary>
    /// Generic image
    /// </summary>
    /// <typeparam name="TElementType"></typeparam>
    public class GenericImage<TElementType> : GenericAbstractGuiElement<TElementType> where TElementType : IGuiElement
    {
        /// <summary>
        /// The image
        /// </summary>
        private IImage _image;

        /// <summary>
        /// C'tor
        /// 
        /// When no size is defined, then the given images dimensions are used.
        /// </summary>
        /// <param name="image">texture to use as image</param>
        public GenericImage(IImage image)
        {
            Setup(image.Width, image.Height, image);
        } 

        /// <summary>
        /// C'tor
        /// </summary>
        /// <param name="width">the display width</param>
        /// <param name="height">the display height</param>
        /// <param name="image">texture to use as image</param>
        public GenericImage(float width, float height, IImage image)
        {
            Setup(width, height, image);
        }

        /// <summary>
        /// Get the image
        /// </summary>
        /// <returns></returns>
        public IImage GetImage()
        {
            return _image;
        }

        /// <summary>
        /// Set the image
        /// </summary>
        /// <param name="image">texture to use as image</param>
        /// <returns></returns>
        public TElementType SetImage(IImage image)
        {
            _image = image;
            return AsElementType();
        }

        /// <summary>
        /// sets up the gui style used for drawing
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="image"></param>
        protected void Setup(float width, float height, IImage image)
        {
            SetWidth(width);
            SetHeight(height);

            _image = image;
        }

        /// <summary>
        /// Set the width and automatically set the height by keeping the aspect ratio of the image
        /// </summary>
        /// <param name="width">The width</param>
        /// <returns></returns>
        public TElementType SetAspectWidth(float width)
        {
            // maintain aspect ratio
            SetWidth(width);
            if (_image != null)
            {
                SetHeight((_image.Height / _image.Width) * width);
            }

            return AsElementType();
        }

        /// <summary>
        /// Set the height and automatically set the width by keeping the aspect ratio of the image
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public TElementType SetAspectHeight(float height)
        {
            // maintain aspect ration
            SetHeight(height);
            if (_image != null)
            {
                SetWidth((_image.Width / _image.Height) * height);
            }

            return AsElementType();
        }

        /// <summary>
        /// Draws the element
        /// </summary>
        public override void Draw(IRenderer renderer)
        {
            var drawingGeometry = GetLayoutProcessingData().DrawingGeometry;

            if (_image != null)
            {
                renderer.RenderImage(
                    UniqueId,
                    drawingGeometry,
                    "",
                    _image
                );
            }
        }
    }
}
