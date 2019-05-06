using De.Kjg.Diversity.Impl.UXs.Guis.Elements.Basic;
using De.Kjg.Diversity.Impl.UXs.Guis.Layout.Container;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Elements.Container
{
    /// <summary>
    /// A box where all children are layout horizontally.
    /// 
    /// You can influence the spacing between the children by using SetSpacing()
    /// </summary>
    public sealed class HBox : GenericHBox<HBox>
    {
    }

    /// <summary>
    /// Generic HBox
    /// </summary>
    /// <typeparam name="TContainerType"></typeparam>
    public class GenericHBox<TContainerType> : GenericBox<TContainerType> where TContainerType : IGuiElementContainer
    {
        protected GenericHBox()
        {
            SetLayout(new HorizontalLayout(this));
        }

        /// <summary>
        /// Tweenable spacing. Sets the spacing between the children
        /// </summary>
        protected HorizontalLayout Layout
        {
            get { return (HorizontalLayout) GetLayout(); }
        }

        /// <summary>
        /// Tweenable Spacing
        /// </summary>
        public float Spacing
        {
            get { return Layout.GetSpacing(); }
            set { Layout.SetSpacing(value); }
        }

        /// <summary>
        /// Set the spacing. The given value is set to top, right, bottom, left spaacing.
        /// </summary>
        /// <param name="spacing"></param>
        /// <returns></returns>
        public TContainerType SetSpacing(float spacing)
        {
            Layout.SetSpacing(spacing); 
            return AsElementType();
        }

        /// <summary>
        /// Add a horizontal spacer of the given width.
        /// 
        /// Adds a child of type Spacer and set the given width.
        /// </summary>
        /// <param name="width">the width.</param>
        /// <returns></returns>
        public TContainerType AddHSpacer(float width)
        {
            AddChild(new Spacer(width, 0));
            return AsElementType();
        }
    }
}
