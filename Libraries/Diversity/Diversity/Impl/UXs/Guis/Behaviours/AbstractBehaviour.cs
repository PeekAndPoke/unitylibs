using De.Kjg.Diversity.Interfaces.UXs.Guis.Behaviours;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Behaviours
{
    /// <summary>
    /// Base implementation for every behaviour
    /// </summary>
    abstract public class AbstractBehaviour : IBehaviour
    {
        /// <summary>
        /// The gui element the behaviour works on
        /// </summary>
        protected IGuiElement GuiElement;

        /// <summary>
        /// Set the gui element
        /// </summary>
        /// <param name="guiElement"></param>
        public void SetGuiElement(IGuiElement guiElement)
        {
            GuiElement = guiElement;
        }

        /// <summary>
        /// Initialize the behaviour
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// This method is called in each OnGUI-cycle and is to be implemented by each behaviour.
        /// </summary>
        /// <returns></returns>
        public abstract bool Process();

        /// <summary>
        /// Destroy the behaviour
        /// </summary>
        public abstract void Destroy();
    }
}
