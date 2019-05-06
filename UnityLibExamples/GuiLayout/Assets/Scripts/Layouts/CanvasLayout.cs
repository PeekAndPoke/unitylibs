using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using De.Kjg.UnityLib.Gui.Elements.Basic;
using De.Kjg.UnityLib.Gui.Elements.Container;

namespace GuiLayout.Assets.Scripts.Layouts
{
    class CanvasLayout : GenericCanvas<CanvasLayout>
    {
        public CanvasLayout()
        {
            AddChild(
                new Label(400, 22, "Canvas with no background and free positioning of elements")
                );

            AddChild(
                new Button(100, 22, "Button").SetX(50).SetY(30)
                );

            AddChild(
                new Label(100, 22, "Label").SetX(170).SetY(40)
                );
        }
    }
}
