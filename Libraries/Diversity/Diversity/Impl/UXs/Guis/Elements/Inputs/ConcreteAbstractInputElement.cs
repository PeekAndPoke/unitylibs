using System;
using De.Kjg.Diversity.Impl.UXs.Events;
using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.UXs.Events;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Elements.Inputs
{
    /// <summary>
    /// Concrete base implementation of gui input elements
    /// </summary>
    /// <typeparam name="TElementType"></typeparam>
    public abstract class ConcreteAbstractInputElement<TElementType> : GenericAbstractGuiElement<TElementType>, IGuiInputElement where TElementType : IGuiInputElement
    {
        /// <summary>
        /// content as string
        /// </summary>
        protected string Content = "";
        /// <summary>
        /// True if the element is enabled
        /// </summary>
        protected bool Enabled = true;

        /// <summary>
        /// Get the content of the input as a string
        /// </summary>
        /// <returns></returns>
        public virtual string GetContent()
        {
            return Content;
        }

        /// <summary>
        /// Set the input of the element
        /// </summary>
        /// <param name="content"></param>
        public void SetContent(string content)
        {
            Content = content;
        }

        /// <summary>
        /// Get enabled state of the input element
        /// </summary>
        /// <returns>
        /// True if the input element is enabled
        /// </returns>
        public bool GetEnabled()
        {
            return Enabled;
        }

        /// <summary>
        /// Set enabled state of the gui element
        /// </summary>
        /// <param name="enabled">True to enable</param>
        public void SetEnabled(bool enabled)
        {
            Enabled = enabled;
        }

        /// <summary>
        /// Draws the input element.
        /// 
        /// This method is sealed in order to handle enabling and disabling of gui elements. 
        /// Derived classes must implement DoDraw().
        /// </summary>
        public override void Draw(IRenderer renderer)
        {
        }

        /// <summary>
        /// Add OnChange listener.
        /// Listener is called when the content of the input element changes
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="IGuiElement.AddListener" />
        public void OnChange(Action<InputEvent> handler, bool once = false, int priority = 0)
        {
            GetEventDispatcher().Add(GuiEventNames.Change, handler, once, priority);
        }

        /// <summary>
        /// Remove OnChange listener
        /// </summary>
        /// <param name="handler"></param>
        public void RemoveOnChange(Action<InputEvent> handler)
        {
            GetEventDispatcher().Remove(GuiEventNames.Change, handler);
        }

        /// <summary>
        /// Dispatch the change event.
        /// </summary>
        /// <param name="e"></param>
        /// <see cref="IGuiElement.Dispatch" />
        public void DispatchChange(InputEvent e = null)
        {
            Dispatch(
                GuiEventNames.Change,
                e ?? new InputEvent { Target = this, Content = GetContent() }
            );
        }
    }
}
