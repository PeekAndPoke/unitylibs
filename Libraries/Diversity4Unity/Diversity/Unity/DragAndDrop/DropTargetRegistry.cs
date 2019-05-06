using System.Collections.Generic;

namespace De.Kjg.Diversity.Unity.DragAndDrop
{
    public class DropTargetRegistry
    {
        protected List<DropTarget3D> DropTargets = new List<DropTarget3D>();

        public void Add(DropTarget3D target)
        {
            DropTargets.Add(target);
        }

        public void Remove(DropTarget3D target)
        {
            DropTargets.Remove(target);
        }

        public List<DropTarget3D> GetAll()
        {
            return DropTargets;
        }
    }
}
