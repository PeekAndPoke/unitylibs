using System.Collections.Generic;
using De.Kjg.Diversity.Impl.Abstraction.Data;
using De.Kjg.Diversity.Impl.UXs.Guis;
using De.Kjg.Diversity.Impl.UXs.Guis.Elements.Basic;
using De.Kjg.Diversity.Impl.UXs.Guis.Elements.Container;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Behaviours;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;
using De.Kjg.Diversity.Unity.DragAndDrop.DragAndDropPkg.Interfaces;
using UnityEngine;

namespace De.Kjg.Diversity.Unity.DragAndDrop.DragAndDropPkg
{
    public class DefaultDragAndDropStrategy : IDragAndDropStrategy
    {
        private IGuiElement _guiElement;
                                                        
        protected Point MousePosInComponent;

        protected Vector2 OriginalPosition;
        protected Canvas DragAndDropStage;
        protected Spacer Replacer;

        public void Initialize(IGuiElement element)  
        {
            _guiElement = element;
        }

        public List<IGuiElement> FindPossibleDropTargets(IGuiElement element)
        {
            var result = new List<IGuiElement>();
            FindPossibleDropTargetsRecursive(result, element);
            return result;
        }

        protected void FindPossibleDropTargetsRecursive(List<IGuiElement> result, IGuiElement element ) 
        {
            if (element is IDropTarget)
            {
                result.Add(element);
            }

            if (element is IGuiElementContainer)
            {
                foreach (IGuiElement child in ((IGuiElementContainer)element).GetChildren())
                {
                    FindPossibleDropTargetsRecursive(result, child);
                }
            }
        }

        public void Grab()
        {
            var layout = _guiElement.GetLayout();

            // create the container where we will move the draggable inside and where we create highlight for drop targets
            DragAndDropStage = new Canvas();
            _guiElement.GetStage().AddChild(DragAndDropStage);

            // replace the guiElement with a spacer while it is draggeed
            Replacer = new Spacer(layout.GetCalculatedWidth(), layout.GetCalculatedHeight());
            _guiElement.GetParent().ReplaceChild(_guiElement, Replacer);

            OriginalPosition = new Vector2(layout.X, layout.Y);

            var absoluteGeometry = _guiElement.GetLayoutProcessingData().AbsoluteGeometry;
            layout.X = absoluteGeometry.X;
            layout.Y = absoluteGeometry.Y;
            // add the draggable on to the DragAndDropStage
            DragAndDropStage.AddChild(_guiElement);

            MousePosInComponent = new Point(
                GuiStage.MousePosition.X - layout.X,
                GuiStage.MousePosition.Y - layout.Y
            );
        }

        public void Move()
        {
            var newX = GuiStage.MousePosition.X - MousePosInComponent.X;
            var newY = GuiStage.MousePosition.Y - MousePosInComponent.Y;

            _guiElement.X = newX;
            _guiElement.Y = newY;
        }

        public void HandleMouseUp(List<IGuiElement> possibleDropTargets)
        {
            var guiElementsUnderMouse = _guiElement.GetStage().MouseInputProcessor.Result.GuiElementsUnderMouse;

            // search for the first drop target under the mouse
            IGuiElement target = null;
            foreach (var element in guiElementsUnderMouse)
            {
                if (element is IDropTarget && possibleDropTargets.Contains(element))
                {
                    target = element;
                    break;
                }
            }
            UnityEngine.Debug.Log("finish drag and drop on target " + target);

            // are we dropping on a drop target
            if (target != null)
            {
                Drop(target);
            }
            else
            {
                Abort();
            }
        }

        protected void Drop(IGuiElement target)
        {
            UnityEngine.Debug.Log("Found target: " + target);

            if (target is IGuiElementContainer)
            {
                var container = (IGuiElementContainer)target;
                container.AddChild(_guiElement);
                Replacer.GetParent().RemoveChild(Replacer);
            }

            Finish();
        }

        protected void Abort()
        {
            // move the element back into its original position and set its old parent
            _guiElement.X = OriginalPosition.x;
            _guiElement.Y = OriginalPosition.y;
            Replacer.GetParent().ReplaceChild(Replacer, _guiElement);

            Finish();
        }

        protected void Finish()
        {
            DragAndDropStage.GetParent().RemoveChild(DragAndDropStage);
        }
    }
}
