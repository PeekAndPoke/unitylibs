using De.Kjg.Diversity.Impl.UXs.Guis.Processors;
using De.Kjg.Diversity.Interfaces.Abstraction.Hardware;
using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.I18n;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Interfaces.UXs.Guis
{
    public interface IGuiStage : IGuiElementContainer
    {
        MouseInputProcessor MouseInputProcessor { get; }

        /// <summary>
        /// Set i18n data
        /// </summary>
        /// <param name="i18N">the i18n data</param>
        void SetI18N(II18N i18N);

        /// <summary>
        /// Calaculate the Layout of all children of the stage
        /// </summary>
        /// <param name="hardware"></param>
        void CalculateLayout(IHardware hardware);

        /// <summary>
        /// Process user interaction and all behaviours
        /// </summary>
        /// <param name="hardware"></param>
        void ProcessInteraction(IHardware hardware);

        /// <summary>
        /// Calls this on each OnGUI-cycle to draw all gui elements and handle inputs and clicks.
        /// </summary>
        void Render(IRenderer renderer);

    }
}
