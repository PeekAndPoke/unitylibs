using System.Collections.Generic;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Behaviours;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Processors
{
    /// <summary>
    /// A central registry for all GuiElement behaviours? 
    /// 
    /// We use it so we dont need to go through all Components to execute the Behaviours.
    /// More over we avoid problem when a behaviour (f.e. DragAndDrop) changes GuiElement, adds or removes them.
    /// This had resulted in an "ArrayList changed Exception", when processing the behaviours while traversing the GuiElement tree.
    /// </summary>
    public class BehaviourProcessor
    {
        private List<IBehaviour> _behaviours = new List<IBehaviour>(); 

        public void Add(IBehaviour behaviour)
        {
            _behaviours.Add(behaviour);
        }

        public void Remove(IBehaviour behaviour)
        {
            _behaviours.Remove(behaviour);
        }

        public void Process()
        {                                                   
            if (_behaviours.Count == 0)
            {
                return;
            }

            var scheduledForRemoval = new List<IBehaviour>();

            var copy = _behaviours.ToArray();

            foreach (var behaviour in copy)
            {
                if (!behaviour.Process())
                {
                    scheduledForRemoval.Add(behaviour);
                }
            }

            foreach (var behaviour in scheduledForRemoval)
            {
                Remove(behaviour);
            }
        }
    }
}
