using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Interfaces.UXs.Guis.Behaviours
{
    /// <summary>
    /// Drop targets need to implement this interface
    /// </summary>
    public interface IDropTarget
    {
        /// <summary>
        /// Returns TRUE if it accepts the given Drag and Drop type.
        ///  </summary>
        /// <param name="element"></param>
        /// <returns>TRUE if type is accepted</returns>
        bool WillAcceptDraggable(IGuiElement element);

        /// <summary>
        /// Returns TRUE if it accepts the given Drag and Drop type.
        ///  </summary>
        /// <param name="element"></param>
        /// <returns>TRUE if type is accepted</returns>
        bool AcceptDraggable(IGuiElement element);
    }
}
