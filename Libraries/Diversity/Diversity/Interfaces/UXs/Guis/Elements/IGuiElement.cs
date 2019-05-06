using System;
using De.Kjg.Diversity.Impl.UXs.Guis;
using De.Kjg.Diversity.Impl.UXs.Guis.Layout.Data;
using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.Abstraction.Visuals;
using De.Kjg.Diversity.Interfaces.I18n;
using De.Kjg.Diversity.Interfaces.UXs.Events;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Behaviours;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Layout;

namespace De.Kjg.Diversity.Interfaces.UXs.Guis.Elements
{
    /// <summary>
    /// All Gui elements implement at least this interface.
    /// </summary>
    public interface IGuiElement : ITranslatable
    {
        #region Main Methods
        /// <summary>
        /// Destroy the gui element.
        /// Removes all behaviours and event listeners.
        /// After it is destroy it can not be used again, meaning it must not be added to the stage again.
        /// </summary>
        void Destroy();
        /// <summary>
        /// Draws the gui element
        /// </summary>
        void Draw(IRenderer renderer);

        #endregion

        #region Behaviours

        /// <summary>
        /// Add a behaviour
        /// </summary>
        /// <param name="behaviour"></param>
        void AddBehaviour(IBehaviour behaviour);
        /// <summary>
        /// Remove a behaviour
        /// </summary>
        /// <param name="behaviour"></param>
        void RemoveBehaviour(IBehaviour behaviour);
        /// <summary>
        /// Remove all behaviours
        /// </summary>
        void RemoveAllBehaviours();

        #endregion

        #region Property setting methods

        /// <summary>
        /// tweenable x coordinate
        /// </summary>
        float X { get; set; }
        /// <summary>
        /// Set x coordinate
        /// </summary>
        /// <param name="x"></param>
        void SetX(float x);
        /// <summary>
        /// tweenable y coordinate
        /// </summary>
        float Y { get; set; }
        /// <summary>
        /// Set y coordinate
        /// </summary>
        /// <param name="y"></param>
        void SetY(float y);
        /// <summary>
        /// tweenable width
        /// </summary>
        float Width { get; set; }
        /// <summary>
        /// Set the width
        /// </summary>
        /// <param name="width"></param>
        void SetWidth(float width);
        /// <summary>
        /// tweenable percentual width
        /// </summary>
        float PercentualWidth { get; set; }
        /// <summary>
        /// Set the height
        /// </summary>
        /// <param name="percent"></param>
        void SetPercentualWidth(float percent);
        /// <summary>
        /// tweenable min width
        /// </summary>
        float MinWidth { get; set; }
        /// <summary>
        /// Set the minimum height
        /// </summary>
        /// <param name="minWidth"></param>
        void SetMinWidth(float minWidth);
        /// <summary>
        /// tweenable max width
        /// </summary>
        float MaxWidth { get; set; }
        /// <summary>
        /// Set the maximum height
        /// </summary>
        /// <param name="maxWidth"></param>
        void SetMaxWidth(float maxWidth);
        /// <summary>
        /// tweenable height
        /// </summary>
        float Height { get; set; }
        /// <summary>
        /// Set the height
        /// </summary>
        /// <param name="height"></param>
        void SetHeight(float height);
        /// <summary>
        /// tweenable percentual height
        /// </summary>
        float PercentualHeight { get; set; }
        /// <summary>
        /// Set the percentual height
        /// </summary>
        /// <param name="percent"></param>
        void SetPercentualHeight(float percent);
        /// <summary>
        /// tweenable min height
        /// </summary>
        float MinHeight { get; set; }
        /// <summary>
        /// Set the minimum height
        /// </summary>
        /// <param name="minHeight"></param>
        void SetMinHeight(float minHeight);
        /// <summary>
        /// tweenable max height
        /// </summary>
        float MaxHeight { get; set; }
        /// <summary>
        /// Set the maximum height
        /// </summary>
        /// <param name="maxHeight"></param>
        void SetMaxHeight(float maxHeight);

        /// <summary>
        /// Get horizonal align
        /// </summary>
        /// <returns></returns>
        HorizontalAlign GetHAlign();
        /// <summary>
        /// Set horizontal align
        /// </summary>
        /// <param name="hAlign">Use HorizontalAlign enum</param>
        void SetHAlign(HorizontalAlign hAlign);
        /// <summary>
        /// Get vertical align
        /// </summary>
        /// <returns></returns>
        VerticalAlign GetVAlign();
        /// <summary>
        /// Set vertical align
        /// </summary>
        /// <param name="vAlign">Use VerticalAlign enum</param>
        void SetVAlign(VerticalAlign vAlign);
        /// <summary>
        /// Get visibility
        /// </summary>
        /// <returns></returns>
        bool GetVisible();
        /// <summary>
        /// Set visibility
        /// </summary>
        /// <param name="visible"></param>
        void SetVisible(bool visible);

        #endregion

        #region Layout and SkinAdapter
        /// <summary>
        /// Get the layout
        /// </summary>
        /// <returns></returns>
        ILayout GetLayout();
        /// <summary>
        /// Set the layout
        /// </summary>
        /// <param name="layout"></param>
        void SetLayout(ILayout layout);
        /// <summary>
        /// Get the processing data that is calculated when all gui elements are calculated
        /// </summary>
        /// <returns></returns>
        ProcessingData GetLayoutProcessingData();
        /// <summary>
        /// Get the gui elements general Style
        /// </summary>
        /// <returns></returns>
        IStyle GetStyle();
        /// <summary>
        /// Set the gui elements general Style
        /// </summary>
        /// <param name="style"></param>
        void SetStyle(IStyle style);

        #endregion

        #region Gui Element Hierarchi

        /// <summary>
        /// Get the stage
        /// </summary>
        /// <returns></returns>
        GuiStage GetStage();
        /// <summary>
        /// Set the elements stage
        /// </summary>
        /// <param name="stage"></param>
        void SetStage(GuiStage stage);

        /// <summary>
        /// Get the parent gui element
        /// </summary>
        IGuiElementContainer GetParent();
        /// <summary>
        /// Set the parent gui element
        /// </summary>
        /// <param name="parent">the parent</param>
        void SetParent(IGuiElementContainer parent);

        #endregion

        #region Mouse Controll

        /// <summary>
        /// Return true if the mouse is enabled.
        /// 
        /// When the mouse is disabled you will not get any mouse events on the gui element (f.e. mouse over or clicked)
        /// </summary>
        /// <returns></returns>
        bool GetMouseEnabled();
        /// <summary>
        /// enable or disable mouse on the gui element.
        /// 
        /// When the mouse is disabled you will not get any mouse events on the gui element (f.e. mouse over or clicked)
        /// </summary>
        /// <param name="enabled"></param>
        void SetMouseEnabled(bool enabled);

        #endregion

        #region Event Registration

        /// <summary>
        /// Add an event listener
        /// </summary>
        /// <param name="eventName">The event name</param>
        /// <param name="handler">the handler to be called</param>
        /// <param name="once">if true the handler is only called once and then removed</param>
        /// <param name="priority">The higher the priority the earlier the handler is called when there are multiple listeners for the event</param>
        void AddListener(string eventName, Action<IEvent> handler, bool once = false, int priority = 0);
        /// <summary>
        /// Add GuiElementEvent.AddedToStage event handler
        /// </summary>
        /// <see cref="AddListener"/>
        /// <see cref="GuiElementEvent"/>
        void OnAddedToStage(Action<IEvent> handler, bool once = false, int priority = 0);
        /// <summary>
        /// Add GuiElementEvent.RemovedFromStage event handler
        /// </summary>
        /// <see cref="AddListener"/>
        /// <see cref="GuiElementEvent"/>
        void OnRemovedFromStage(Action<IEvent> handler, bool once = false, int priority = 0);
        /// <summary>
        /// Add GuiElementEvent.MouseOver event handler
        /// </summary>
        /// <see cref="AddListener"/>
        /// <see cref="GuiElementEvent"/>
        void OnMouseOver(Action<IEvent> handler, bool once = false, int priority = 0);
        /// <summary>
        /// Add GuiElementEvent.MouseOut event handler
        /// </summary>
        /// <see cref="AddListener"/>
        /// <see cref="GuiElementEvent"/>
        void OnMouseOut(Action<IEvent> handler, bool once = false, int priority = 0);
        /// <summary>
        /// Add GuiElementEvent.Click event handler
        /// </summary>
        /// <see cref="AddListener"/>
        /// <see cref="GuiElementEvent"/>
        void OnClick(Action<IEvent> handler, bool once = false, int priority = 0);
        /// <summary>
        /// Add GuiElementEvent.DoubleClick event handler
        /// </summary>
        /// <see cref="AddListener"/>
        /// <see cref="GuiElementEvent"/>
        void OnDoubleClick(Action<IEvent> handler, bool once = false, int priority = 0);
        /// <summary>
        /// Add GuiElementEvent.MouseDown event handler
        /// </summary>
        /// <see cref="AddListener"/>
        /// <see cref="GuiElementEvent"/>
        void OnMouseDown(Action<IEvent> handler, bool once = false, int priority = 0);
        /// <summary>
        /// Add GuiElementEvent.MouseUp event handler
        /// </summary>
        /// <see cref="AddListener"/>
        /// <see cref="GuiElementEvent"/>
        void OnMouseUp(Action<IEvent> handler, bool once = false, int priority = 0);
        /// <summary>
        /// Add GuiElementEvent.RightMouseDown event handler
        /// </summary>
        /// <see cref="AddListener"/>
        /// <see cref="GuiElementEvent"/>
        void OnRightMouseDown(Action<IEvent> handler, bool once = false, int priority = 0);
        /// <summary>
        /// Add GuiElementEvent.RightMouseUp event handler
        /// </summary>
        /// <see cref="AddListener"/>
        /// <see cref="GuiElementEvent"/>
        void OnRightMouseUp(Action<IEvent> handler, bool once = false, int priority = 0);
        /// <summary>
        /// Add GuiElementEvent.MiddleMouseDown event handler
        /// </summary>
        /// <see cref="AddListener"/>
        /// <see cref="GuiElementEvent"/>
        void OnMiddleMouseDown(Action<IEvent> handler, bool once = false, int priority = 0);
        /// <summary>
        /// Add GuiElementEvent.MiddleMouseUp event handler
        /// </summary>
        /// <see cref="AddListener"/>
        /// <see cref="GuiElementEvent"/>
        void OnMiddleMouseUp(Action<IEvent> handler, bool once = false, int priority = 0);

        #endregion

        #region Event Removing

        /// <summary>
        /// Remove the given handler from the given event
        /// </summary>
        /// <param name="eventName">name of the event</param>
        /// <param name="handler">the handler to be removed</param>
        void RemoveListener(string eventName, Action<IEvent> handler);

        /// <summary>
        /// Remove all event listeners
        /// </summary>
        void RemoveAllEventHandlers();

        #endregion

        #region Event Dispatching

        /// <summary>
        /// Dispatch an event
        /// </summary>
        /// <param name="eventName">The event name</param>
        /// <param name="e">If set this event is forwarded</param>
        void Dispatch(string eventName, IEvent e = null);
        /// <summary>
        /// Dispatch GuiElementEvent.AddedToStage
        /// </summary>
        /// <see cref="Dispatch"/>
        void DispatchAddedToStage(IEvent e = null);
        /// <summary>
        /// Dispatch GuiElementEvent.RemovedFromStage
        /// </summary>
        /// <see cref="Dispatch"/>
        void DispatchRemovedFromStage(IEvent e = null);
        /// <summary>
        /// Dispatch GuiElementEvent.MouseOver
        /// </summary>
        /// <see cref="Dispatch"/>
        void DispatchMouseOver(IEvent e = null);
        /// <summary>
        /// Dispatch GuiElementEvent.MouseOut
        /// </summary>
        /// <see cref="Dispatch"/>
        void DispatchMouseOut(IEvent e = null);
        /// <summary>
        /// Dispatch GuiElementEvent.Clicked
        /// </summary>
        /// <see cref="Dispatch"/>
        void DispatchClicked(IEvent e = null);
        /// <summary>
        /// Dispatch GuiElementEvent.DoubleClicked
        /// </summary>
        /// <see cref="Dispatch"/>
        void DispatchDoubleClicked(IEvent e = null);
        /// <summary>
        /// Dispatch GuiElementEvent.LeftMouseDown
        /// </summary>
        /// <see cref="Dispatch"/>
        void DispatchLeftMouseDown(IEvent e = null);
        /// <summary>
        /// Dispatch GuiElementEvent.LeftMouseUp
        /// </summary>
        /// <see cref="Dispatch"/>
        void DispatchLeftMouseUp(IEvent e = null);
        /// <summary>
        /// Dispatch GuiElementEvent.RightMouseDown
        /// </summary>
        /// <see cref="Dispatch"/>
        void DispatchRightMouseDown(IEvent e = null);
        /// <summary>
        /// Dispatch GuiElementEvent.RightMouseUp
        /// </summary>
        /// <see cref="Dispatch"/>
        void DispatchRightMouseUp(IEvent e = null);
        /// <summary>
        /// Dispatch GuiElementEvent.MiddleMouseDown
        /// </summary>
        /// <see cref="Dispatch"/>
        void DispatchMiddleMouseDown(IEvent e = null);
        /// <summary>
        /// Dispatch GuiElementEvent.MiddleMouseUp
        /// </summary>
        /// <see cref="Dispatch"/>
        void DispatchMiddleMouseUp(IEvent e = null);

        #endregion
    }
}