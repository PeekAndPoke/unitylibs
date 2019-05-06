using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using De.Kjg.TweenSharkPkg;
using De.Kjg.TweenSharkPkg.Options;
using De.Kjg.UnityLib.Gui;
using De.Kjg.UnityLib.Gui.Elements.Basic;
using De.Kjg.UnityLib.Gui.Elements.Container;

namespace GuiLayout.Assets.Scripts.Layouts
{
    class HBoxLayout : GenericHBox<HBoxLayout>
    {
        public HBoxLayout()
        {
            SetPadding(5, 5, 5, 5);

            AddChild(
                new Label(200, 122, "VBox with background and automatic vertical positioning of elements and padding of 5,5,5,5")
                );

            AddChild(
                new Label(100, 22, "Top Align").SetVAlign(VerticalAlign.Top)
                .SetX(170).SetY(40)     // setting of x and y does not do anything in a vbox
                );

            AddChild(
                new Label(100, 22, "Middle Align").SetVAlign(VerticalAlign.Middle)
                .SetX(170).SetY(40)     // setting of x and y does not do anything in a vbox
                );

            AddChild(
                new Label(100, 22, "Bottom Align").SetVAlign(VerticalAlign.Bottom)
                .SetX(170).SetY(40)     // setting of x and y does not do anything in a vbox
                );

            AddChild(
                new Button(100, 22, "Pad 0")
                    .OnClick(
                        e => TweenShark.To(this, 1, new TweenOps(Ease.OutQuad).PropTo("Padding", 0))
                    )
                );

            AddChild(
                new Button(100, 22, "Pad 20")
                    .OnClick(
                        e => TweenShark.To(this, 1, new TweenOps(Ease.OutQuad).PropTo("Padding", 20))
                    )
                );

            AddChild(
                new Button(100, 22, "Pad 100")
                    .OnClick(
                        e => TweenShark.To(this, 1, new TweenOps(Ease.OutQuad).PropTo("Padding", 100))
                    )
                );

            AddHSpacer(10);

            AddChild(
                new Button(100, 22, "Space 0")
                    .OnClick(
                        e => TweenShark.To(this, 1, new TweenOps(Ease.OutQuad).PropTo("Spacing", 0))
                    )
                );

            AddChild(
                new Button(100, 22, "Space 10")
                    .OnClick(
                        e => TweenShark.To(this, 1, new TweenOps(Ease.OutQuad).PropTo("Spacing", 10))
                    )
                );

            AddChild(
                new Button(100, 22, "Space 20")
                    .OnClick(
                        e => TweenShark.To(this, 1, new TweenOps(Ease.OutQuad).PropTo("Spacing", 20))
                    )
                );

        }
    }
}
