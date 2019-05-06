using System.Collections.Generic;

namespace De.Kjg.Diversity.Interfaces.UXs.Guis.Elements
{
    /// <summary>
    /// All Gui Element Containers implement at least this interface.
    /// </summary>
    public interface IGuiElementContainer : IGuiElement
    {
        /// <summary>
        /// Get all child gui elements
        /// </summary>
        /// <returns>The children</returns>
        List<IGuiElement> GetChildren();
        /// <summary>
        /// Add a child
        /// </summary>
        /// <param name="child"></param>
        void AddChild(IGuiElement child);
        /// <summary>
        /// Replace a child with another gui element.
        /// 
        /// If 'which' is no child nothing is done.
        /// </summary>
        /// <param name="which">which child to remove</param>
        /// <param name="with">to replace with</param>
        /// <param name="destroyRemoved">true to destroy the removed child</param>
        /// <see cref="IGuiElement.Destroy"/>
        void ReplaceChild(IGuiElement which, IGuiElement with, bool destroyRemoved = false);
        /// <summary>
        /// Remove a child.
        /// 
        /// If 'child' is no child nothing is done. 
        /// </summary>
        /// <param name="child">The child to be removed</param>
        /// <param name="destroy">True to destroy the child after removal.</param>
        /// <see cref="IGuiElement.Destroy"/>
        void RemoveChild(IGuiElement child, bool destroy = false);
        /// <summary>
        /// Remove a child at the given index.
        /// 
        /// If the index is greater or equal the number of children or less than 0 nothing is done.
        /// </summary>
        /// <param name="idx">The index</param>
        /// <param name="destroy">True to detroy the child after removal.</param>
        /// <see cref="IGuiElement.Destroy"/>
        void RemoveChildAt(int idx, bool destroy = false);
        /// <summary>
        /// Remove all children
        /// </summary>
        /// <param name="destroy">True to destroy each child after removal.</param>
        void RemoveAllChildren(bool destroy = false);
        /// <summary>
        /// Check if a gui element is child of the container
        /// </summary>
        /// <param name="element">The element to check</param>
        /// <returns></returns>
        bool HasChild(IGuiElement element);

        /// <summary>
        /// tweenable padding
        /// </summary>
        float Padding { get; set; }
    }
}