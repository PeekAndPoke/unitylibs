using De.Kjg.Diversity.Interfaces.UXs.Guis.Behaviours;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;
using UnityEngine;

namespace De.Kjg.Diversity.Unity.DragAndDrop
{
    public class DropTarget3D : MonoBehaviour, IDropTarget
    {
        protected string DropTargetType;

        public void SetDropTargetType(string type)
        {
            DropTargetType = type;
        }

        public string GetDropTargetType()
        {
            return DropTargetType;
        }

        public bool WillAcceptDraggable(IGuiElement element)
        {
            return true;
        }

        public bool AcceptDraggable(IGuiElement element)
        {
            return true;
        }
    }
}
