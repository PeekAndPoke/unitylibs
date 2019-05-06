using System.Collections.Generic;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Unity.DragAndDrop.DragAndDropPkg.Interfaces
{
    /// <summary>
    /// interface for highlighting strategy.
    /// 
    /// The highlighting strategy decides which and how drop targets are highlighted.
    /// </summary>
    public interface IHighlightingStrategy
    {
        /// <summary>
        /// Highlights the given gui elements
        /// </summary>
        /// <param name="dropTargets">Gui elements to highlight</param>
        void Highlight(IEnumerable<IGuiElement> dropTargets);
        /// <summary>
        /// Removes the highlighting from all highlighted gui elements.
        /// </summary>
        void Restore();
    }
}