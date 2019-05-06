using System;
using System.Collections.Generic;
using De.Kjg.Diversity.Impl.I18n;
using De.Kjg.Diversity.Impl.I18n.Strings;
using De.Kjg.Diversity.Impl.UXs.Events;
using De.Kjg.Diversity.Impl.UXs.Guis.Layout;
using De.Kjg.Diversity.Impl.UXs.Guis.Layout.Data;
using De.Kjg.Diversity.Impl.Utils;
using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.Abstraction.Visuals;
using De.Kjg.Diversity.Interfaces.I18n;
using De.Kjg.Diversity.Interfaces.UXs.Events;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Behaviours;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Layout;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Elements
{
    abstract public class AbstractGuiElement : IGuiElement
    {
        /// <summary>
        /// Event dispatcher instance
        /// </summary>
        private readonly EventDispatcher _eventDispatcher;
        /// <summary>
        /// Behaviours of the gui element
        /// </summary>
        protected List<IBehaviour> Behaviours = new List<IBehaviour>();
        /// <summary>
        /// Application wide unique id
        /// </summary>
        protected string UniqueId;

        /// <summary>
        /// C'tor
        /// </summary>
        protected AbstractGuiElement()
        {
            UniqueId = UniqueIdGenerator.GetString();
            SetMouseEnabled(true);
            SetLayout(new BaseLayout(this));
            SetStyle(null);
            _eventDispatcher = new EventDispatcher(this);
        }

        #region Main Methods

        /// <summary>
        /// Destroy the gui element.
        /// Removes all behaviours and event listeners.
        /// After it is destroy it can not be used again, meaning it must not be added to the stage again.
        /// </summary>
        public virtual void Destroy()
        {
            RemoveAllEventHandlers();
            RemoveAllBehaviours();
            // TODO: invalidate parent (when layout caching is implmented some day)
        }

        /// <summary>
        /// Draws the gui element
        /// </summary>
        public virtual void Draw(IRenderer renderer)
        {
        }

        #endregion

        /// <summary>
        /// Get the event dispatcher
        /// </summary>
        protected EventDispatcher GetEventDispatcher()
        {
            return _eventDispatcher;
        }

        #region Property setting methods

        /// <summary>
        /// tweenable x coordinate
        /// </summary>
        public float X
        {
            get { return GetLayout().X; }
            set { GetLayout().X = value; }
        }
        /// <summary>
        /// Set x coordinate
        /// </summary>
        /// <param name="x"></param>
        public void SetX(float x)
        {
            X = x;
        }

        /// <summary>
        /// tweenable y coordinate
        /// </summary>
        public float Y
        {
            get { return GetLayout().Y; }
            set { GetLayout().Y = value; }
        }
        /// <summary>
        /// Set Y coordinate
        /// </summary>
        /// <param name="y"></param>
        public void SetY(float y)
        {
            Y = y;
        }

        /// <summary>
        /// Tweenable width
        /// </summary>
        public float Width
        {
            get { return GetLayout().GetWidth(); }
            set { GetLayout().SetWidth(value); }
        }
        /// <summary>
        /// Set the width
        /// </summary>
        /// <param name="width"></param>
        public void SetWidth(float width)
        {
            GetLayout().SetWidth(width);
        }

        /// <summary>
        /// Tweenable percentual width
        /// </summary>
        public float PercentualWidth
        {
            get { return GetLayout().GetPercentualWidth(); }
            set { GetLayout().SetPercentualWidth(value); }
        }
        /// <summary>
        /// Set the width
        /// </summary>
        /// <param name="percent"></param>
        public void SetPercentualWidth(float percent)
        {
            PercentualWidth = percent;
        }

        /// <summary>
        /// Tweenable minimum width
        /// </summary>
        public float MinWidth
        {
            get { return GetLayout().GetMinWidth(); }
            set { GetLayout().SetMinWidth(value); }
        }
        /// <summary>
        /// Set the minimum width
        /// </summary>
        /// <param name="minWidth"></param>
        public void SetMinWidth(float minWidth)
        {
            MinWidth = minWidth;
        }

        /// <summary>
        /// Tweenable maximum width
        /// </summary>
        public float MaxWidth
        {
            get { return GetLayout().GetMaxWidth(); }
            set { GetLayout().SetMaxWidth(value); }
        }
        /// <summary>
        /// Set the maximum width
        /// </summary>
        /// <param name="maxWidth"></param>
        public void SetMaxWidth(float maxWidth)
        {
            MaxWidth = maxWidth;
        }

        /// <summary>
        /// Tweenable height
        /// </summary>
        public float Height
        {
            get { return GetLayout().GetHeight(); }
            set { GetLayout().SetHeight(value); }
        }
        /// <summary>
        /// Set the height
        /// </summary>
        /// <param name="height"></param>
        public void SetHeight(float height)
        {
            Height = height;
        }

        /// <summary>
        /// Tweenable percentual height
        /// </summary>
        public float PercentualHeight
        {
            get { return GetLayout().GetPercentualHeight(); }
            set { GetLayout().SetPercentualHeight(value); }
        }
        /// <summary>
        /// Set the percentual height
        /// </summary>
        /// <param name="percent"></param>
        public void SetPercentualHeight(float percent)
        {
            PercentualHeight = percent;
        }

        /// <summary>
        /// tweenable min height
        /// </summary>
        public float MinHeight
        {
            get { return GetLayout().GetMinHeight(); }
            set { GetLayout().SetMinHeight(value); }
        }
        /// <summary>
        /// Set the minimum height
        /// </summary>
        /// <param name="minHeight"></param>
        public void SetMinHeight(float minHeight)
        {
            MinHeight = minHeight;
        }

        /// <summary>
        /// tweenable max height
        /// </summary>
        public float MaxHeight
        {
            get { return GetLayout().GetMaxHeight(); }
            set { GetLayout().SetMaxHeight(value); }
        }
        /// <summary>
        /// Set the maximum height
        /// </summary>
        /// <param name="maxHeight"></param>
        public void SetMaxHeight(float maxHeight)
        {
            MaxHeight = maxHeight;
        }

        /// <summary>
        /// Get horizonal align
        /// </summary>
        /// <returns></returns>
        public HorizontalAlign GetHAlign()
        {
            return GetLayout().HorizontalAlign;
        }
        /// <summary>
        /// Set horizontal align
        /// </summary>
        /// <param name="hAlign">Use HorizontalAlign enum</param>
        public void SetHAlign(HorizontalAlign hAlign)
        {
            GetLayout().HorizontalAlign = hAlign;
        }
        /// <summary>
        /// Get vertical align
        /// </summary>
        /// <returns></returns>
        public VerticalAlign GetVAlign()
        {
            return GetLayout().VerticalAlign;
        }
        /// <summary>
        /// Set vertical align
        /// </summary>
        /// <param name="vAlign">Use VerticalAlign enum</param>
        public void SetVAlign(VerticalAlign vAlign)
        {
            GetLayout().VerticalAlign = vAlign;
        }
        /// <summary>
        /// Get visibility
        /// </summary>
        /// <returns></returns>
        public bool GetVisible()
        {
            return GetLayout().Visible;
        }
        /// <summary>
        /// Set visibility
        /// </summary>
        /// <param name="visible"></param>
        public void SetVisible(bool visible)
        {
            GetLayout().Visible = visible;
        }

        #endregion

        #region SkinAdapter and Layout
        /// <summary>
        /// The elements layout
        /// </summary>
        private ILayout _layout;
        /// <summary>
        /// Get the layout
        /// </summary>
        /// <returns></returns>
        public ILayout GetLayout()
        {
            return _layout;
        }
        /// <summary>
        /// Set the layout
        /// </summary>
        /// <param name="layout"></param>
        public void SetLayout(ILayout layout)
        {
            _layout = layout;
        }
        /// <summary>
        /// Get the processing data that is calculated when all gui elements are calculated
        /// </summary>
        /// <returns></returns>
        public ProcessingData GetLayoutProcessingData()
        {
            return GetLayout().GetProcessingData();
        }

        /// <summary>
        /// The elements main Style
        /// </summary>
        private IStyle _style;
        /// <summary>
        /// Get the gui elements general Style
        /// </summary>
        /// <returns></returns>
        public IStyle GetStyle()
        {
            return _style;
        }
        /// <summary>
        /// Set the gui elements general Style
        /// </summary>
        /// <param name="style"></param>
        public void SetStyle(IStyle style)
        {
            _style = style;
        }
        /// <summary>
        /// Get StyleAdapter by name
        /// </summary>
        protected virtual IStyle GetStyleByName(string name)
        {
            var stage = GetStage();
            var style = stage != null ? stage.GetStyleByName(name) : null;
            return style;
        }

        #endregion

        #region Gui Element Hierarchy

        /// <summary>
        /// The gui elements stage
        /// </summary>
        private GuiStage _stage;
        /// <summary>
        /// Get the stage
        /// </summary>
        /// <returns></returns>
        public virtual GuiStage GetStage()
        {
            return _stage;
        }
        /// <summary>
        /// Set the elements stage
        /// </summary>
        /// <param name="stage"></param>
        public virtual void SetStage(GuiStage stage)
        {
            var previousStage = _stage;
            if (stage != previousStage)
            {
                _stage = stage;
                if (stage != null)
                {
                    DispatchAddedToStage();
                }
                else
                {
                    DispatchRemovedFromStage();
                }
            }
        }

        /// <summary>
        /// The gui elements parent
        /// </summary>
        private IGuiElementContainer _parent;
        /// <summary>
        /// Get the parent gui element
        /// </summary>
        /// <returns></returns>
        public IGuiElementContainer GetParent()
        {
            return _parent;
        }
        /// <summary>
        /// Set the parent gui element
        /// </summary>
        /// <param name="parent">the parent</param>
        public void SetParent(IGuiElementContainer parent)
        {
            _parent = parent;
        }

        #endregion

        #region Mouse Controll

        /// <summary>
        /// The gui elements mouse enabled flag
        /// </summary>
        private bool _mouseEnabled;
        /// <summary>
        /// Return true if the mouse is enabled.
        /// When the mouse is disabled you will not get any mouse events on the gui element (f.e. mouse over or clicked)
        /// </summary>
        /// <returns></returns>
        public bool GetMouseEnabled()
        {
            return _mouseEnabled;
        }
        /// <summary>
        /// enable or disable mouse on the gui element.
        /// When the mouse is disabled you will not get any mouse events on the gui element (f.e. mouse over or clicked)
        /// </summary>
        /// <param name="enabled"></param>
        public void SetMouseEnabled(bool enabled)
        {
            _mouseEnabled = enabled;
        }

        #endregion

        #region I18N

        /// <summary>
        /// Gets the L10 N.
        /// </summary>
        /// <returns></returns>
        public virtual II18N GetI18N()
        {
            if (GetStage() != null)
            {
                return GetStage().GetI18N();
            }
            return null;
        }

        /// <summary>
        /// Helper to get i18n string from text container using the currently configured language
        /// </summary>
        /// <see cref="II18N.SetLanguage"/>
        protected LocalizedString __(string fullPath)
        {
            return new LocalizedString(this, fullPath);
        }
        /// <summary>
        /// Helper to get i18n string from text container using the given language
        /// </summary>
        protected LocalizedString __(string fullPath, LanguageCode language)
        {
            return new LocalizedString(this, fullPath).SetLanguage(language);
        }

        #endregion

        #region Behaviours

        /// <summary>
        /// Add a behaviour
        /// </summary>
        /// <param name="behaviour"></param>
        public void AddBehaviour(IBehaviour behaviour)
        {
            Behaviours.Add(behaviour);
            behaviour.SetGuiElement(this);
            behaviour.Initialize();
            GuiStage.Instance.BehaviourProcessor.Add(behaviour);
        }
        /// <summary>
        /// Remove a behaviour
        /// </summary>
        /// <param name="behaviour"></param>
        public void RemoveBehaviour(IBehaviour behaviour)
        {
            Behaviours.Remove(behaviour);
            GuiStage.Instance.BehaviourProcessor.Remove(behaviour);
            behaviour.Destroy();
        }
        /// <summary>
        /// Remove all behaviours
        /// </summary>
        public void RemoveAllBehaviours()
        {
            // make a copy for iteration
            var copy = new List<IBehaviour>(Behaviours);
            foreach (var behaviour in copy)
            {
                RemoveBehaviour(behaviour);
            }
        }

        #endregion

        #region Events Registration

        /// <summary>
        /// Add an event listener
        /// </summary>
        /// <param name="eventName">The event name</param>
        /// <param name="handler">the handler to be called</param>
        /// <param name="once">if true the handler is only called once and then removed</param>
        /// <param name="priority">The higher the priority the earlier the handler is called when there are multiple listeners for the event</param>
        public void AddListener(string eventName, Action<IEvent> handler, bool once = false, int priority = 0)
        {
            GetEventDispatcher().Add(eventName, handler, once, priority);
        }

        /// <summary>
        /// Add GuiElementEvent.AddedToStage event handler
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="AddListener" />
        ///   <see cref="GuiElementEvent" />
        public void OnAddedToStage(Action<IEvent> handler, bool once = false, int priority = 0)
        {
            GetEventDispatcher().Add(GuiEventNames.AddedToStage, handler, once, priority);
        }

        /// <summary>
        /// Add GuiElementEvent.RemovedFromStage event handler
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="AddListener" />
        ///   <see cref="GuiElementEvent" />
        public void OnRemovedFromStage(Action<IEvent> handler, bool once = false, int priority = 0)
        {
            GetEventDispatcher().Add(GuiEventNames.RemovedFromStage, handler, once, priority);
        }

        /// <summary>
        /// Add GuiElementEvent.MouseOver event handler
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="AddListener" />
        ///   <see cref="GuiElementEvent" />
        public void OnMouseOver(Action<IEvent> handler, bool once = false, int priority = 0)
        {
            GetEventDispatcher().Add(GuiEventNames.MouseOver, handler, once, priority);
        }

        /// <summary>
        /// Add GuiElementEvent.MouseOut event handler
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="AddListener" />
        ///   <see cref="GuiElementEvent" />
        public void OnMouseOut(Action<IEvent> handler, bool once = false, int priority = 0)
        {
            GetEventDispatcher().Add(GuiEventNames.MouseOut, handler, once, priority);
        }

        /// <summary>
        /// Add GuiElementEvent.Click event handler
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="AddListener" />
        ///   <see cref="GuiElementEvent" />
        public void OnClick(Action<IEvent> handler, bool once = false, int priority = 0)
        {
            GetEventDispatcher().Add(GuiEventNames.Clicked, handler, once, priority);
        }

        /// <summary>
        /// Add GuiElementEvent.DoubleClick event handler
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="AddListener" />
        ///   <see cref="GuiElementEvent" />
        public void OnDoubleClick(Action<IEvent> handler, bool once = false, int priority = 0)
        {
            GetEventDispatcher().Add(GuiEventNames.DoubleClicked, handler, once, priority);
        }

        /// <summary>
        /// Add GuiElementEvent.MouseDown event handler
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="AddListener" />
        ///   <see cref="GuiElementEvent" />
        public void OnMouseDown(Action<IEvent> handler, bool once = false, int priority = 0)
        {
            GetEventDispatcher().Add(GuiEventNames.LeftMouseDown, handler, once, priority);
        }

        /// <summary>
        /// Add GuiElementEvent.MouseUp event handler
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="AddListener" />
        ///   <see cref="GuiElementEvent" />
        public void OnMouseUp(Action<IEvent> handler, bool once = false, int priority = 0)
        {
            GetEventDispatcher().Add(GuiEventNames.LeftMouseUp, handler, once, priority);
        }

        /// <summary>
        /// Add GuiElementEvent.RightMouseDown event handler
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="AddListener" />
        ///   <see cref="GuiElementEvent" />
        public void OnRightMouseDown(Action<IEvent> handler, bool once = false, int priority = 0)
        {
            GetEventDispatcher().Add(GuiEventNames.RightMouseDown, handler, once, priority);
        }

        /// <summary>
        /// Add GuiElementEvent.RightMouseUp event handler
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="AddListener" />
        ///   <see cref="GuiElementEvent" />
        public void OnRightMouseUp(Action<IEvent> handler, bool once = false, int priority = 0)
        {
            GetEventDispatcher().Add(GuiEventNames.RightMouseUp, handler, once, priority);
        }

        /// <summary>
        /// Add GuiElementEvent.MiddleMouseDown event handler
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="AddListener" />
        ///   <see cref="GuiElementEvent" />
        public void OnMiddleMouseDown(Action<IEvent> handler, bool once = false, int priority = 0)
        {
            GetEventDispatcher().Add(GuiEventNames.MiddleMouseDown, handler, once, priority);
        }

        /// <summary>
        /// Add GuiElementEvent.MiddleMouseUp event handler
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="once"></param>
        /// <param name="priority"></param>
        /// <see cref="AddListener" />
        ///   <see cref="GuiElementEvent" />
        public void OnMiddleMouseUp(Action<IEvent> handler, bool once = false, int priority = 0)
        {
            GetEventDispatcher().Add(GuiEventNames.MiddleMouseUp, handler, once, priority);
        }

        #endregion

        #region Event Removing

        /// <summary>
        /// Remove the given handler from the given event
        /// </summary>
        /// <param name="eventName">name of the event</param>
        /// <param name="handler">the handler to be removed</param>
        public void RemoveListener(string eventName, Action<IEvent> handler)
        {
            GetEventDispatcher().Remove(eventName, handler);
        }

        /// <summary>
        /// Remove all event listeners
        /// </summary>
        public void RemoveAllEventHandlers()
        {
            GetEventDispatcher().RemoveAllHandlersFromAllEvents();
        }

        #endregion

        #region Event Dispatching

        /// <summary>
        /// Dispatch an event
        /// </summary>
        /// <param name="eventName">The event name</param>
        /// <param name="e">If set this event is forwarded</param>
        public void Dispatch(string eventName, IEvent e = null)
        {
            GetEventDispatcher().Dispatch(eventName, e);
        }

        /// <summary>
        /// Dispatch GuiElementEvent.AddedToStage
        /// </summary>
        /// <param name="e"></param>
        /// <see cref="Dispatch" />
        public void DispatchAddedToStage(IEvent e = null)
        {
            Dispatch(GuiEventNames.AddedToStage, e);
        }

        /// <summary>
        /// Dispatch GuiElementEvent.RemovedFromStage
        /// </summary>
        /// <param name="e"></param>
        /// <see cref="Dispatch" />
        public void DispatchRemovedFromStage(IEvent e = null)
        {
            Dispatch(GuiEventNames.RemovedFromStage, e);
        }

        /// <summary>
        /// Dispatch GuiElementEvent.MouseOver
        /// </summary>
        /// <param name="e"></param>
        /// <see cref="Dispatch" />
        public void DispatchMouseOver(IEvent e = null)
        {
            Dispatch(GuiEventNames.MouseOver, e);
        }

        /// <summary>
        /// Dispatch GuiElementEvent.MouseOut
        /// </summary>
        /// <param name="e"></param>
        /// <see cref="Dispatch" />
        public void DispatchMouseOut(IEvent e = null)
        {
            Dispatch(GuiEventNames.MouseOut, e);
        }

        /// <summary>
        /// Dispatch GuiElementEvent.Clicked
        /// </summary>
        /// <param name="e"></param>
        /// <see cref="Dispatch" />
        public void DispatchClicked(IEvent e = null)
        {
            Dispatch(GuiEventNames.Clicked, e);
        }

        /// <summary>
        /// Dispatch GuiElementEvent.DoubleClicked
        /// </summary>
        /// <param name="e"></param>
        /// <see cref="Dispatch" />
        public void DispatchDoubleClicked(IEvent e = null)
        {
            Dispatch(GuiEventNames.DoubleClicked, e);
        }

        /// <summary>
        /// Dispatch GuiElementEvent.LeftMouseDown
        /// </summary>
        /// <param name="e"></param>
        /// <see cref="Dispatch" />
        public void DispatchLeftMouseDown(IEvent e = null)
        {
            Dispatch(GuiEventNames.LeftMouseDown, e);
        }

        /// <summary>
        /// Dispatch GuiElementEvent.LeftMouseUp
        /// </summary>
        /// <param name="e"></param>
        /// <see cref="Dispatch" />
        public void DispatchLeftMouseUp(IEvent e = null)
        {
            Dispatch(GuiEventNames.LeftMouseUp, e);
        }

        /// <summary>
        /// Dispatch GuiElementEvent.RightMouseDown
        /// </summary>
        /// <param name="e"></param>
        /// <see cref="Dispatch" />
        public void DispatchRightMouseDown(IEvent e = null)
        {
            Dispatch(GuiEventNames.RightMouseDown, e);
        }

        /// <summary>
        /// Dispatch GuiElementEvent.RightMouseUp
        /// </summary>
        /// <param name="e"></param>
        /// <see cref="Dispatch" />
        public void DispatchRightMouseUp(IEvent e = null)
        {
            Dispatch(GuiEventNames.RightMouseUp, e);
        }

        /// <summary>
        /// Dispatch GuiElementEvent.MiddleMouseDown
        /// </summary>
        /// <param name="e"></param>
        /// <see cref="Dispatch" />
        public void DispatchMiddleMouseDown(IEvent e = null)
        {
            Dispatch(GuiEventNames.MiddleMouseDown, e);
        }

        /// <summary>
        /// Dispatch GuiElementEvent.MiddleMouseUp
        /// </summary>
        /// <param name="e"></param>
        /// <see cref="Dispatch" />
        public void DispatchMiddleMouseUp(IEvent e = null)
        {
            Dispatch(GuiEventNames.MiddleMouseUp, e);
        }

        #endregion
    }
}
