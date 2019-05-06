using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Interfaces.UXs.Guis.Behaviours
{
    /// <summary>
    /// Interface for gui element behaviours.
    /// 
    /// Behaviour can be attached to gui elements to encapsulate and implement complex interaction or animations, 
    /// f.e. drag and drop.
    /// </summary>
    public interface IBehaviour
    {
        /// <summary>
        /// Set the gui element
        /// </summary>
        /// <param name="guiElement"></param>
        void SetGuiElement(IGuiElement guiElement);
        /// <summary>
        /// Initialize the behaviour
        /// </summary>
        void Initialize();
        /// <summary>
        /// Return TRUE to continue and FALSE to remove the guiElement.
        /// NOTICE: DO NOT use guiElement.RemoveBehaviour(this). It does not work the way you expect!
        /// </summary>
        /// <returns></returns>
        bool Process();
        /// <summary>
        /// called when the behaviour is destroyed
        /// </summary>
        void Destroy();
    }
}
