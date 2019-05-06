using De.Kjg.Diversity.Impl.Abstraction.Data;
using De.Kjg.Diversity.Impl.UXs.Guis.Layout.Container;
using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Elements.Container
{
    /// <summary>
    /// Scrollview that has a fixed size and can scroll its content if the content exceeds the scroll views own size.
    /// </summary>
    public sealed class ScrollView : GenericScrollView<ScrollView>
    {
        /// <summary>
        /// C'tor
        /// </summary>
        /// <param name="viewWidth">scroll view width</param>
        /// <param name="viewHeight">scroll view height</param>
        public ScrollView(float viewWidth, float viewHeight) : base(viewWidth, viewHeight)
        {
        }
    }

    /// <summary>
    /// Generic scroll view
    /// </summary>
    /// <typeparam name="TContainerType"></typeparam>
    public class GenericScrollView<TContainerType> : GenericAbstractGuiContainer<TContainerType> where TContainerType : IGuiElementContainer
    {
        private Rectangle _contentRect = new Rectangle();

        public ScrollViewLayout Layout
        {
            get { return (ScrollViewLayout) GetLayout(); }
        }

        /// <summary>
        /// C'tor
        /// </summary>
        /// <param name="viewWidth"></param>
        /// <param name="viewHeight"></param>
        public GenericScrollView(float viewWidth, float viewHeight)
        {
            SetLayout(new ScrollViewLayout(this));

            SetWidth(viewWidth);
            SetHeight(viewHeight);
        }

        /// <summary>
        /// Draw the scroll view and its children
        /// </summary>
        public override void Draw(IRenderer renderer)
        {
            var absoluteGeometry = GetLayoutProcessingData().AbsoluteGeometry;
            var drawingGeometry = GetLayoutProcessingData().DrawingGeometry;

            var layout = Layout;

            _contentRect.Set(
                0,
                0,
                layout.GetCalculatedContentWidth() + layout.PaddingLeft + layout.PaddingRight,
                layout.GetCalculatedContentHeight() + layout.PaddingTop + layout.PaddingBottom
           );

            layout.ScrollPosition = renderer.BeginScrollView(
                UniqueId,
                drawingGeometry,
                layout.ScrollPosition,
                _contentRect
            );

            DrawChildren(renderer);

            renderer.EndScrollView();
        }
    }
}
