using System;
using De.Kjg.Diversity.Interfaces.Abstraction.Visuals;
using De.Kjg.Diversity.Interfaces.UXs.Events;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Behaviours;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Elements
{
    /// <summary>
    /// Generic Implementation of the base gui element. 
    /// </summary>
    /// <typeparam name="TElementType">The type of element used as return type for function chaining.</typeparam>
    abstract public class GenericAbstractGuiElement<TElementType> : AbstractGuiElement where TElementType : IGuiElement
    {
        #region Property setting methods

        /// <summary>
        /// Sets the X.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        public new TElementType SetX(float x)
        {
            base.SetX(x);
            return AsElementType();
        }

        /// <summary>
        /// Sets the Y.
        /// </summary>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public new TElementType SetY(float y)
        {
            base.SetY(y);
            return AsElementType();
        }

        /// <summary>
        /// Sets the width.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <returns></returns>
        public new TElementType SetWidth(float width)
        {
            base.SetWidth(width);
            return AsElementType();
        }

        /// <summary>
        /// Sets the percentual width.
        /// </summary>
        /// <param name="percent">0 .. 1</param>
        /// <returns></returns>
        public new TElementType SetPercentualWidth(float percent)
        {
            base.SetPercentualWidth(percent);
            return AsElementType();
        }

        /// <summary>
        /// Sets the width of the min.
        /// </summary>
        /// <param name="minWidth">Width of the min.</param>
        /// <returns></returns>
        public new TElementType SetMinWidth(float minWidth)
        {
            base.SetMinWidth(minWidth);
            return AsElementType();
        }

        /// <summary>
        /// Sets the width of the max.
        /// </summary>
        /// <param name="maxWidth">Width of the max.</param>
        /// <returns></returns>
        public new TElementType SetMaxWidth(float maxWidth)
        {
            base.SetMaxWidth(maxWidth);
            return AsElementType();
        }

        /// <summary>
        /// Sets the height.
        /// </summary>
        /// <param name="height">The height.</param>
        /// <returns></returns>
        public new TElementType SetHeight(float height)
        {
            base.SetHeight(height);
            return AsElementType();
        }

        /// <summary>
        /// Sets the percentual height.
        /// </summary>
        /// <param name="percent">0 .. 1</param>
        /// <returns></returns>
        public new TElementType SetPercentualHeight(float percent)
        {
            base.SetPercentualHeight(percent);
            return AsElementType();
        }

        /// <summary>
        /// Sets the height of the min.
        /// </summary>
        /// <param name="minHeight">Height of the min.</param>
        /// <returns></returns>
        public new TElementType SetMinHeight(float minHeight)
        {
            base.SetMinHeight(minHeight);
            return AsElementType();
        }

        /// <summary>
        /// Sets the height of the max.
        /// </summary>
        /// <param name="maxHeight">Height of the max.</param>
        /// <returns></returns>
        public new TElementType SetMaxHeight(float maxHeight)
        {
            base.SetMaxHeight(maxHeight);
            return AsElementType();
        }

        /// <summary>
        /// Sets the Horizontal align.
        /// </summary>
        /// <param name="hAlign">The horizontal align.</param>
        /// <returns></returns>
        public new TElementType SetHAlign(HorizontalAlign hAlign)
        {
            base.SetHAlign(hAlign);
            return AsElementType();
        }

        /// <summary>
        /// Sets the Vertical align.
        /// </summary>
        /// <param name="vAlign">The vertical align.</param>
        /// <returns></returns>
        public new TElementType SetVAlign(VerticalAlign vAlign)
        {
            base.SetVAlign(vAlign);
            return AsElementType();
        }

        /// <summary>
        /// Sets the StyleAdapter.
        /// </summary>
        /// <param name="style">The StyleAdapter.</param>
        /// <returns></returns>
        public new TElementType SetStyle(IStyle style)
        {
            base.SetStyle(style);
            return AsElementType();
        }

        #endregion

        #region Mouse Controll

        /// <summary>
        /// enable or disable mouse on the gui element.
        /// When the mouse is disabled you will not get any mouse events on the gui element (f.e. mouse over or clicked)
        /// </summary>
        /// <param name="enabled"></param>
        public new TElementType SetMouseEnabled(bool enabled)
        {
            base.SetMouseEnabled(enabled);
            return AsElementType();
        }

        #endregion

        #region Behaviours

        /// <summary>
        /// Add a behaviour
        /// </summary>
        /// <param name="behaviour"></param>
        public new TElementType AddBehaviour(IBehaviour behaviour)
        {
            base.AddBehaviour(behaviour);
            return AsElementType();
        }

        /// <summary>
        /// Remove a behaviour
        /// </summary>
        /// <param name="behaviour"></param>
        public new TElementType RemoveBehaviour(IBehaviour behaviour)
        {
            base.AddBehaviour(behaviour);
            return AsElementType();
        }

        #endregion

        #region Events

        /// <summary>
        /// Add an event listener
        /// </summary>
        /// <param name="eventName">The event name</param>
        /// <param name="handler">the handler to be called</param>
        /// <param name="once">if true the handler is only called once and then removed</param>
        /// <param name="priority">The higher the priority the earlier the handler is called when there are multiple listeners for the event</param>
        public new TElementType AddListener(string eventName, Action<IEvent> handler, bool once = false, int priority = 0)
        {
            base.AddListener(eventName, handler, once, priority);
            return AsElementType();
        }

        /// <summary>
        /// Add GuiElementEvent.AddedToStage event handler
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="AddListener" />
        ///   <see cref="GuiElementEvent" />
        public new TElementType OnAddedToStage(Action<IEvent> handler, bool once = false, int priority = 0)
        {
            base.OnAddedToStage(handler, once, priority);
            return AsElementType();
        }

        /// <summary>
        /// Add GuiElementEvent.MouseOver event handler
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="AddListener" />
        ///   <see cref="GuiElementEvent" />
        public new TElementType OnMouseOver(Action<IEvent> handler, bool once = false, int priority = 0)
        {
            base.OnMouseOver(handler, once, priority);
            return AsElementType();
        }

        /// <summary>
        /// Add GuiElementEvent.MouseOut event handler
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="AddListener" />
        ///   <see cref="GuiElementEvent" />
        public new TElementType OnMouseOut(Action<IEvent> handler, bool once = false, int priority = 0)
        {
            base.OnMouseOut(handler, once, priority);
            return AsElementType();
        }

        /// <summary>
        /// Add GuiElementEvent.Click event handler
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="AddListener" />
        ///   <see cref="GuiElementEvent" />
        public new TElementType OnClick(Action<IEvent> handler, bool once = false, int priority = 0)
        {
            base.OnClick(handler, once, priority);
            return AsElementType();
        }

        /// <summary>
        /// Add GuiElementEvent.DoubleClick event handler
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="AddListener" />
        ///   <see cref="GuiElementEvent" />
        public new TElementType OnDoubleClick(Action<IEvent> handler, bool once = false, int priority = 0)
        {
            base.OnDoubleClick(handler, once, priority);
            return AsElementType();
        }

        /// <summary>
        /// Add GuiElementEvent.MouseDown event handler
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="AddListener" />
        ///   <see cref="GuiElementEvent" />
        public new TElementType OnMouseDown(Action<IEvent> handler, bool once = false, int priority = 0)
        {
            base.OnMouseDown(handler, once, priority);
            return AsElementType();
        }

        /// <summary>
        /// Add GuiElementEvent.MouseUp event handler
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="AddListener" />
        ///   <see cref="GuiElementEvent" />
        public new TElementType OnMouseUp(Action<IEvent> handler, bool once = false, int priority = 0)
        {
            base.OnMouseUp(handler, once, priority);
            return AsElementType();
        }

        /// <summary>
        /// Add GuiElementEvent.RightMouseDown event handler
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="AddListener" />
        ///   <see cref="GuiElementEvent" />
        public new TElementType OnRightMouseDown(Action<IEvent> handler, bool once = false, int priority = 0)
        {
            base.OnRightMouseDown(handler, once, priority);
            return AsElementType();
        }

        /// <summary>
        /// Add GuiElementEvent.RightMouseUp event handler
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="AddListener" />
        ///   <see cref="GuiElementEvent" />
        public new TElementType OnRightMouseUp(Action<IEvent> handler, bool once = false, int priority = 0)
        {
            base.OnRightMouseUp(handler, once, priority);
            return AsElementType();
        }

        /// <summary>
        /// Add GuiElementEvent.MiddleMouseDown event handler
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="AddListener" />
        ///   <see cref="GuiElementEvent" />
        public new TElementType OnMiddleMouseDown(Action<IEvent> handler, bool once = false, int priority = 0)
        {
            base.OnMiddleMouseDown(handler, once, priority);
            return AsElementType();
        }

        /// <summary>
        /// Add GuiElementEvent.MiddleMouseUp event handler
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="AddListener" />
        ///   <see cref="GuiElementEvent" />
        public new TElementType OnMiddleMouseUp(Action<IEvent> handler, bool once = false, int priority = 0)
        {
            base.OnMiddleMouseUp(handler, once, priority);
            return AsElementType();
        }

        #endregion

        /// <summary>
        /// Use for casting this to TElementType
        /// </summary>
        /// <returns></returns>
        protected TElementType AsElementType()
        {
            return (TElementType)((object)this);
        }
    }
}
