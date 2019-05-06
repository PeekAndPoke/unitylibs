namespace De.Kjg.Diversity.Interfaces.UXs.Guis.Behaviours
{
    /// <summary>
    /// Gui elements that can be dragged need to implement this interface
    /// </summary>
    public interface IDraggable
    {
        /// <summary>
        /// Get the type of what is dragged. It can be dropped in all targets, that accept this type.
        /// </summary>
        /// <returns>The name of the drop type.</returns>
        string GetDragAndDropType();
    }
}
