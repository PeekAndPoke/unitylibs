using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Elements.Container
{
    public abstract class GenericAbstractGuiContainer<TContainerType> : AbstractGuiContainer<TContainerType>
        where TContainerType : IGuiElementContainer
    {
        /// <summary>
        /// Add a child
        /// </summary>
        /// <param name="child">The element to add</param>
        /// <returns></returns>
        public new TContainerType AddChild(IGuiElement child)
        {
            base.AddChild(child);
            return AsElementType();
        }

    }
}