using System;
using De.Kjg.Diversity.Impl.UXs.Events;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Elements.Inputs
{
    /// <summary>
    /// Generic base implementation of gui input elements.
    /// 
    /// Override some interface methods to enable chaining.
    /// </summary>
    /// <typeparam name="TElementType"></typeparam>
    public abstract class GenericAbstractInputElement<TElementType> : ConcreteAbstractInputElement<TElementType> where TElementType : IGuiInputElement
    {
        /// <summary>
        /// Sets the content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public new virtual TElementType SetContent(string content)
        {
            base.SetContent(content);
            return AsElementType();
        }

        /// <summary>
        /// Enable or disable the input element
        /// </summary>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        /// <returns></returns>
        public new virtual TElementType SetEnabled(bool enabled)
        {
            base.SetEnabled(enabled);
            return AsElementType();
        }

        /// <summary>
        /// Add OnChange listener.
        /// Listener is called when the content of the input element changes
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="IGuiElement.AddListener" />
        public new virtual TElementType OnChange(Action<InputEvent> handler, bool once = false, int priority = 0)
        {
            base.OnChange(handler, once, priority);
            return AsElementType();
        }
    }
}