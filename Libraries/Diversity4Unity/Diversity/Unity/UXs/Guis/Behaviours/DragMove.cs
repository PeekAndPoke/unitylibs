using De.Kjg.Diversity.Impl.Abstraction.Data;
using De.Kjg.Diversity.Impl.UXs.Guis;
using De.Kjg.Diversity.Impl.UXs.Guis.Behaviours;
using UnityEngine;

namespace De.Kjg.Diversity.Unity.Gui.Behaviours
{
    /// <summary>
    /// Behaviour for moving a gui element around while the left mouse button is held down. 
    /// </summary>
    public class DragMove : AbstractBehaviour
    {
        protected Point MousePosInComponent;

        protected bool SnapToParent = true;

        public override void Initialize()
        {
            MousePosInComponent = new Point(
                GuiStage.MousePosition.X - GuiElement.X,
                GuiStage.MousePosition.X - GuiElement.Y
            );
        }

        public DragMove SetSnapToParent(bool snap)
        {
            SnapToParent = snap;
            return this;
        }

        public override bool Process()
        {
            if (!Input.GetMouseButton(0))
            {
                return false;
            }

            var newX = GuiStage.MousePosition.X - MousePosInComponent.X;
            var newY = GuiStage.MousePosition.Y - MousePosInComponent.Y;

            if (SnapToParent)
            {
                newX = Mathf.Max(0, Mathf.Min(newX, GuiElement.GetParent().GetLayout().GetCalculatedWidth() - GuiElement.GetLayout().GetCalculatedWidth()));
                newY = Mathf.Max(0, Mathf.Min(newY, GuiElement.GetParent().GetLayout().GetCalculatedHeight() - GuiElement.GetLayout().GetCalculatedHeight()));
            }

            GuiElement.X = newX;
            GuiElement.Y = newY;

            return true;
        }

        public override void Destroy()
        {
        }
    }
}
