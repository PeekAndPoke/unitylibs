using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using De.Kjg.UnityLib.Gui.Elements.Basic;
using De.Kjg.UnityLib.Gui.Elements.Container;

namespace GuiLayout.Assets.Scripts.Layouts
{
    class BoxLayout : GenericBox<BoxLayout>
    {
        public BoxLayout()
        {
            AddChild(
                new Label(400, 22, "Box with background and free positioning of elements")
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
