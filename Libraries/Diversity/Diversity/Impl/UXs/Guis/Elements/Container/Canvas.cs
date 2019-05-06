using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Elements.Container
{
    /// <summary>
    /// Like a Box but no background is shown by standard.
    /// </summary>
    public sealed class Canvas : GenericCanvas<Canvas>
    {

    }

    /// <summary>
    /// Generic Canvas
    /// </summary>
    /// <typeparam name="TContainerType"></typeparam>
    public class GenericCanvas<TContainerType> : GenericBox<TContainerType> where TContainerType : IGuiElementContainer
    {
        public GenericCanvas()
        {
            SetDrawBackground(false);
        }
     
    }
}
