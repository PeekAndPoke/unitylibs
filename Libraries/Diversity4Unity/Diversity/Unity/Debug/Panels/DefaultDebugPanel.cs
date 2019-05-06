using De.Kjg.Diversity.Impl.UXs.Guis.Elements.Basic;
using De.Kjg.Diversity.Impl.UXs.Guis.Elements.Container;
using De.Kjg.Diversity.Impl.Utils;
using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Unity.Debug.Interfaces;
using UnityEngine;

namespace De.Kjg.Diversity.Unity.Debug.Panels
{
    class DefaultDebugPanel : AbstractDebugPanel<DefaultDebugPanel>
    {
        private Label _mousePosition;
        private Label _underMouse;
        
        public DefaultDebugPanel()
        {
            AddChild(
                new VBox().SetPadding(5, 5, 5, 5).SetPercentualWidth(1f).SetDrawBackground(false)
                          .AddChild(_mousePosition = new Label(100, 20, "").SetPercentualWidth(1))

                          .AddChild(new Label(100, 20, "Under mouse:").SetPercentualWidth(1))
                          .AddChild(_underMouse = new Label(100, 300, "").SetPercentualWidth(1))
                );
        }

        public override string GetName()
        {
            return "default";
        }

        public override void Draw(IRenderer renderer)
        {
            base.Draw(renderer);

            _mousePosition.SetText("MousePosition: " + ClientHardware.GetMousePosition().X + ", " +
                    (ClientHardware.GetApplicationDisplaySize().Y - ClientHardware.GetMousePosition().Y));

            var elementsUnderMouse = ClientGuiStage.MouseInputProcessor.Result.GuiElementsUnderMouse;

            if (elementsUnderMouse.Count > 0)
            {
                var element = elementsUnderMouse[0];
                var path = GuiUtil.GetGuiElementPath(element);
                _underMouse.SetText(
                    path + "\n" +
                    "\n" +
                    "DrawingGeometry: " + element.GetLayoutProcessingData().DrawingGeometry + "\n" +
                    "AbsoluteGeometry: " + element.GetLayoutProcessingData().AbsoluteGeometry + "\n" +
                    "ClipRect: " + element.GetLayoutProcessingData().ClipRect
                );
            }
            else
            {
                _underMouse.SetText("NONE with MouseEnabled set to true");
            }
        }

    }
}
