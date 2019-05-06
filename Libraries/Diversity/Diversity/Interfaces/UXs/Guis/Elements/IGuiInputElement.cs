using System;
using De.Kjg.Diversity.Impl.UXs.Events;

namespace De.Kjg.Diversity.Interfaces.UXs.Guis.Elements
{
    /// <summary>
    /// Input gui elements implement this interface.
    /// </summary>
    public interface IGuiInputElement : IGuiElement
    {
        /// <summary>
        /// Get the content of the input as a string
        /// </summary>
        /// <returns></returns>
        string GetContent();
        /// <summary>
        /// Set the input of the element 
        /// </summary>
        /// <param name="content"></param>
        void SetContent(string content);
        /// <summary>
        /// Get enabled state of the input element
        /// </summary>
        /// <returns>True if the input element is enabled</returns>
        bool GetEnabled();
        /// <summary>
        /// Set enabled state of the gui element
        /// </summary>
        /// <param name="enabled">True to enable</param>
        void SetEnabled(bool enabled);
        /// <summary>
        /// Add OnChange listener. 
        /// 
        /// Listener is called when the content of the input element changes
        /// </summary>
        /// <see cref="IGuiElement.AddListener"/>
        void OnChange(Action<InputEvent> handler, bool once = false, int priority = 0);
        /// <summary>
        /// Remove OnChange listener
        /// </summary>
        /// <param name="handler"></param>
        void RemoveOnChange(Action<InputEvent> handler);
        /// <summary>
        /// Dispatch the change event.
        /// </summary>
        /// <see cref="IGuiElement.Dispatch"/>
        void DispatchChange(InputEvent e = null);

    }
}
