using De.Kjg.Diversity.Impl.UXs.Guis.Elements.Basic;
using De.Kjg.Diversity.Impl.UXs.Guis.Layout.Container;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Elements.Container
{
    /// <summary>
    /// A box where all children are layout vertically.
    /// 
    /// You can influence the spacing between the children by using SetSpacing()
    /// </summary>
    public sealed class VBox : GenericVBox<VBox>
    {
    }

    /// <summary>
    /// Generic VBox
    /// </summary>
    /// <typeparam name="TContainerType"></typeparam>
    public class GenericVBox<TContainerType> : GenericBox<TContainerType> where TContainerType : IGuiElementContainer
    {
        protected GenericVBox()
        {
            SetLayout(new VerticalLayout(this));
        }

        /// <summary>
        /// Casts the layout to VerticalLayout
        /// </summary>
        protected VerticalLayout Layout
        {
            get { return (VerticalLayout) GetLayout(); }
        }

        /// <summary>
        /// Tweenable spacing. Sets the spacing between the children
        /// </summary>
        public float Spacing
        {
            get { return Layout.GetSpacing(); }
            set { Layout.SetSpacing(value); }
        }

        /// <summary>
        /// Set the spacing between the children
        /// </summary>
        /// <param name="spacing"></param>
        /// <returns></returns>
        public TContainerType SetSpacing(float spacing)
        {
            Layout.SetSpacing(spacing); 
            return AsElementType();
        }

        /// <summary>
        /// Add a vertical spacer.
        /// 
        /// Add a child of type Spacer and set the given height on it.
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public TContainerType AddVSpacer(float height)
        {
            AddChild(new Spacer(0, height));
            return AsElementType();
        }
    }
}
