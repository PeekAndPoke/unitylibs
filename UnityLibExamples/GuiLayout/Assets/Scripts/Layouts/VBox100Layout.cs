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
    class VBox100Layout : GenericVBox<VBox100Layout>
    {
        public VBox100Layout()
        {
            // 100% width
            SetPercentualWidth(1f);

            SetPadding(5, 5, 5, 5);

            AddChild(
                new Label(400, 22, "VBox with 100% width and padding of 5,5,5,5")
                );

            AddChild(
                new Button(150, 22, "Button at x=50")
                .SetX(50).SetY(30)      // setting of y does not do anything in a vbox
                );

            AddChild(
                new Button(150, 22, "Button at x=100")
                .SetX(100).SetY(30)      // setting of y does not do anything in a vbox
                );

            AddChild(
                new Button(150, 22, "Button at x=150")
                .SetX(150).SetY(30)     // setting of y does not do anything in a vbox
                );

            AddChild(
                new Label(100, 22, "Left Align").SetHAlign(HorizontalAlign.Left)
                .SetX(170).SetY(40)     // setting of y does not do anything in a vbox
                );

            AddChild(
                new Label(100, 22, "Center Align").SetHAlign(HorizontalAlign.Center)
                .SetX(170).SetY(40)     // setting of y does not do anything in a vbox
                );

            AddChild(
                new Label(100, 22, "Right Align").SetHAlign(HorizontalAlign.Right)
                .SetX(170).SetY(40)     // setting of y does not do anything in a vbox
                );

            AddChild(
                new Label(100, 22, "100% width").SetPercentualWidth(1)
                );

            AddChild(
                new Button(200, 22, "Set Padding to 0")
                    .OnClick(
                        e => TweenShark.To(this, 1, new TweenOps(Ease.OutQuad).PropTo("Padding", 0))
                    )
                );

            AddChild(
                new Button(200, 22, "Set Padding to 20")
                    .OnClick(
                        e => TweenShark.To(this, 1, new TweenOps(Ease.OutQuad).PropTo("Padding", 20))
                    )
                );

            AddChild(
                new Button(200, 22, "Set Padding to 100")
                    .OnClick(
                        e => TweenShark.To(this, 1, new TweenOps(Ease.OutQuad).PropTo("Padding", 100))
                    )
                );

            AddVSpacer(10);

            AddChild(
                new Button(200, 22, "Set Spacing to 0")
                    .OnClick(
                        e => TweenShark.To(this, 1, new TweenOps(Ease.OutQuad).PropTo("Spacing", 0))
                    )
                );

            AddChild(
                new Button(200, 22, "Set Spacing to 10")
                    .OnClick(
                        e => TweenShark.To(this, 1, new TweenOps(Ease.OutQuad).PropTo("Spacing", 10))
                    )
                );

            AddChild(
                new Button(200, 22, "Set Spacing to 20")
                    .OnClick(
                        e => TweenShark.To(this, 1, new TweenOps(Ease.OutQuad).PropTo("Spacing", 20))
                    )
                );

        }
    }
}
