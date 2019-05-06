using System.Collections.Generic;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Unity.DragAndDrop.DragAndDropPkg.Interfaces
{
    /// <summary>
    /// Interface of drag and drop strategy
    /// </summary>
    public interface IDragAndDropStrategy
    {
        /// <summary>
        /// initialization
        /// </summary>
        /// <param name="element">The dragged gui element</param>
        void Initialize(IGuiElement element);
        /// <summary>
        /// Returns possible gui drop targets
        /// </summary>
        /// <param name="element">The dragged element</param>
        /// <returns>List of possible drop targets</returns>
        List<IGuiElement> FindPossibleDropTargets(IGuiElement element);
        /// <summary>
        /// Grab is called when the drag an drop starts
        /// </summary>
        void Grab();
        /// <summary>
        /// Move is called in every OnGUI-cycle while the gui element is dragged around.
        /// </summary>
        void Move();
        /// <summary>
        /// HandleMouseUp is called when the left mouse button is no longer held down.
        /// </summary>
        /// <param name="possibleDropTargets">List of possible drop targets.</param>
        void HandleMouseUp(List<IGuiElement> possibleDropTargets);
    }
}