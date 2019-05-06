using De.Kjg.Diversity.Interfaces.Abstraction.Hardware;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Layout.Container
{
    public class GuiStageLayout : ContainerLayout
    {
        private IHardware _hardware;

        public GuiStageLayout(IGuiElement guiElement) : base(guiElement)
        {
        }

        public void SetHardware(IHardware hardware)
        {
            _hardware = hardware;
        }

        public void Calculate()
        {
            CalculateChildLayouts(0, 0, GetCalculatedContentWidth(), GetCalculatedContentHeight(), 0, 0);
        }

        public override float GetCalculatedContentWidth()
        {
            return _hardware.GetApplicationDisplaySize().X;
        }

        public override float GetCalculatedContentHeight()
        {
            return _hardware.GetApplicationDisplaySize().Y;
        }

    }
}