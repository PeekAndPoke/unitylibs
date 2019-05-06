using System;
using System.Collections.Generic;
using De.Kjg.Diversity.Impl.Abstraction.Data;
using De.Kjg.Diversity.Interfaces.Abstraction.Data;
using De.Kjg.Diversity.Interfaces.Abstraction.Hardware;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Processors
{
    public class ProcessInputResult
    {
        public readonly List<IGuiElement> GuiElementsUnderMouse = new List<IGuiElement>();

        public readonly List<IGuiElement> MouseOverEvent = new List<IGuiElement>();
        public readonly List<IGuiElement> MouseOutEvent = new List<IGuiElement>();

        public readonly List<IGuiElement> ClickedEvent = new List<IGuiElement>();
        public readonly List<IGuiElement> DoubleClickedEvent = new List<IGuiElement>();

        public readonly List<IGuiElement> LeftMouseDownEvent = new List<IGuiElement>();
        public readonly List<IGuiElement> LeftMouseUpEvent = new List<IGuiElement>();

        public readonly List<IGuiElement> MiddleMouseDownEvent = new List<IGuiElement>();
        public readonly List<IGuiElement> MiddleMouseUpEvent = new List<IGuiElement>();

        public readonly List<IGuiElement> RightMouseDownEvent = new List<IGuiElement>();
        public readonly List<IGuiElement> RightMouseUpEvent = new List<IGuiElement>();

        public void Reset()
        {
            GuiElementsUnderMouse.Clear();

            MouseOverEvent.Clear();
            MouseOutEvent.Clear();

            ClickedEvent.Clear();
            DoubleClickedEvent.Clear();

            LeftMouseDownEvent.Clear();
            LeftMouseUpEvent.Clear();

            MiddleMouseDownEvent.Clear();
            MiddleMouseUpEvent.Clear();

            RightMouseDownEvent.Clear();
            RightMouseUpEvent.Clear();
        }
    }

    public class MouseInputProcessor
    {
        private static Rectangle _noClipRect = new Rectangle();
        protected static Rectangle GetNoClipRect()
        {
            _noClipRect.Set(0, 0, Single.MaxValue, Single.MaxValue);
            return _noClipRect;
        }

        private ProcessInputResult _result = new ProcessInputResult();
        public ProcessInputResult Result { get { return _result;  } }

        private bool _previousMouseButtonLeft;
        private bool _currentMouseButtonLeft;
        private bool _previousMouseButtonMiddle;
        private bool _currentMouseButtonMiddle;
        private bool _previousMouseButtonRight;
        private bool _currentMouseButtonRight;

        public void ProcessInputs(IGuiElement root, IHardware hardware)
        {
            PrepareNextStep(hardware);

            // process inputs
            ProcessInputsRecursive(root, GetNoClipRect());

            // finish the current step
            FinishStep();

            // process the input results
            foreach (IGuiElement component in _result.MouseOutEvent)
            {
                component.DispatchMouseOut();
            }

            foreach (IGuiElement component in _result.MouseOverEvent)
            {
                component.DispatchMouseOver();
            }

            // DispatchClicked only to the first one
            if (_result.ClickedEvent.Count > 0)
            {
                _result.ClickedEvent[0].DispatchClicked();
            }
            // DispatchDoubleClicked only to the first one
            if (_result.DoubleClickedEvent.Count > 0)
            {
                _result.DoubleClickedEvent[0].DispatchDoubleClicked();
            }
            // DispatchLeftMouseDown only to the first one
            if (_result.LeftMouseDownEvent.Count > 0)
            {
                _result.LeftMouseDownEvent[0].DispatchLeftMouseDown();
            }
            // DispatchLeftMouseUp only to the first one
            if (_result.LeftMouseUpEvent.Count > 0)
            {
                _result.LeftMouseUpEvent[0].DispatchLeftMouseUp();
            }
            // DispatchRightMouseDown only to the first one
            if (_result.RightMouseDownEvent.Count > 0)
            {
                _result.RightMouseDownEvent[0].DispatchRightMouseDown();
            }
            // DispatchRightMouseUp only to the first one
            if (_result.RightMouseUpEvent.Count > 0)
            {
                _result.RightMouseUpEvent[0].DispatchRightMouseUp();
            }
            // DispatchMiddleMouseDown only to the first one
            if (_result.MiddleMouseDownEvent.Count > 0)
            {
                _result.MiddleMouseDownEvent[0].DispatchMiddleMouseDown();
            }
            // DispatchMiddleMouseUp only to the first one
            if (_result.MiddleMouseUpEvent.Count > 0)
            {
                _result.MiddleMouseUpEvent[0].DispatchMiddleMouseUp();
            }
        }

        private void ProcessInputsRecursive(IGuiElement component, IRectangle clipRect)
        {
            if (!component.GetVisible())
            {
                return;
            }

            if (component is IGuiElementContainer)
            {
                var container = (IGuiElementContainer)component;
                var children = container.GetChildren();

                var componenetClipRect = component.GetLayoutProcessingData().ClipRect;
                // merge the two rectangle to get the cut-set
                var resultingClipRect = clipRect.Intersect(componenetClipRect);

                // just go further in the recursion if there is space left in the clip rect
                if (resultingClipRect.Width > 0 && resultingClipRect.Height > 0)
                {
                    // first go down the recursion
                    // But we have to go from the last to the first child. We have to do it, so the top most child (with same parent as its sibblings)
                    // will receive events like Clicked, that are only sent to one gui element.
                    var count = children.Count;
                    for (var i = count-1; i >= 0; --i)
                    {
                        var child = children[i];
                        ProcessInputsRecursive(child, resultingClipRect);
                    }
                }
                // on the back path check for events
                ProcessComponentInputs(component, clipRect);
            }
            else
            {
                ProcessComponentInputs(component, clipRect);
            }
        }

        private void PrepareNextStep(IHardware hardware)
        {
            // clear all results
            _result.Reset();

            _currentMouseButtonLeft = hardware.GetLeftMouseButton();
            _currentMouseButtonMiddle = hardware.GetMiddleMouseButton();
            _currentMouseButtonRight = hardware.GetRightMouseButton();
        }

        private void FinishStep()
        {
            _previousMouseButtonLeft = _currentMouseButtonLeft;
            _previousMouseButtonMiddle = _currentMouseButtonMiddle;
            _previousMouseButtonRight = _currentMouseButtonRight;
        }

        private void ProcessComponentInputs(IGuiElement component, IRectangle clipRect)
        {
            // does the element have mouse processing enabled?
            if (!component.GetMouseEnabled())
            {
                return;
            }

            var processingData = component.GetLayoutProcessingData();
            // is the mouse actually hovering over the element
            var containsCurrent = 
                processingData.AbsoluteGeometry.Contains(GuiStage.MousePosition) && clipRect.Contains(GuiStage.MousePosition)
                &&
                component.GetLayout().Visible
            ;
            // was it hovering over the element in the last frame
            var containsPrevious = processingData.MouseWasOver;
            // remember the current situation for the next frame
            processingData.MouseWasOver = containsCurrent;

            if (containsCurrent)
            {
                _result.GuiElementsUnderMouse.Add(component);
            }

            // check for mouse over
            if (containsCurrent && !containsPrevious)
            {
                _result.MouseOverEvent.Add(component);
            }

            // check for mouse out
            if (!containsCurrent && containsPrevious)
            {
                _result.MouseOutEvent.Add(component);
            }

            // check for clicks
            if (containsCurrent)
            {
                // check for left mouse down
                if (!_previousMouseButtonLeft && _currentMouseButtonLeft)
                {
                    _result.LeftMouseDownEvent.Add(component);
                }

                // check for left mouse up / clicked
                if (_previousMouseButtonLeft && !_currentMouseButtonLeft)
                {
                    _result.LeftMouseUpEvent.Add(component);
                    _result.ClickedEvent.Add(component);
                    // detect double click
                    var now = DateTime.Now;
                    if ((now - processingData.LastClickTimestamp).TotalMilliseconds < 500)
                    {
                        _result.DoubleClickedEvent.Add(component);
                    }
                    // remember the last click time
                    processingData.LastClickTimestamp = DateTime.Now;
                }

                // check for right mouse down
                if (!_previousMouseButtonRight && _currentMouseButtonRight)
                {
                    _result.RightMouseDownEvent.Add(component);
                }

                // check for right mouse up
                if (_previousMouseButtonRight && !_currentMouseButtonRight)
                {
                    _result.RightMouseUpEvent.Add(component);
                }

                // check for middle mouse down
                if (!_previousMouseButtonMiddle && _currentMouseButtonMiddle)
                {
                    _result.MiddleMouseDownEvent.Add(component);
                }

                // check for right mouse up
                if (_previousMouseButtonMiddle && !_currentMouseButtonMiddle)
                {
                    _result.MiddleMouseUpEvent.Add(component);
                }
            }
        }
    }
}
