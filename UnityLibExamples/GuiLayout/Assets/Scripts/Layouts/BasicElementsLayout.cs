using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using De.Kjg.UnityLib.Gui.Elements.Basic;
using De.Kjg.UnityLib.Gui.Elements.Container;
using De.Kjg.UnityLib.Unity.GuiBridge;
using GuiLayout.Assets.Scripts.Attached;
using UnityEngine;

namespace GuiLayout.Assets.Scripts.Layouts
{
    class BasicElementsLayout : GenericScrollView<BasicElementsLayout>
    {
        public BasicElementsLayout() : base(600, 400)
        {
            SetPadding(15, 15, 15, 15);

            AddChild(
                new VBox().SetMouseEnabled(false).SetPadding(5, 5, 5, 5).SetPercentualWidth(1).SetSpacing(5)
                    // button
                    .AddChild(
                        new HBox().SetDrawBackground(false)
                                .AddChild(new Label(200, 22, "new Button(...);"))
                                .AddChild(new Button(300, 22, "a button"))
                    )
                    // image
                    .AddChild(
                        new HBox().SetDrawBackground(false)
                                .AddChild(new Label(200, 22, "new Image(...);"))
                                .AddChild(new Image(100, 80, ApplicationLogic.Instance.Image1.ToImage()))
                    )
                    // image button
                    .AddChild(
                        new HBox().SetDrawBackground(false)
                                .AddChild(new Label(200, 22, "new ImageButton(...);"))
                                .AddChild(new ImageButton(ApplicationLogic.Instance.ImageButton1))
                    )
                    // image button
                    .AddChild(
                        new HBox().SetDrawBackground(false)
                                .AddChild(new Label(200, 22, "new ImageToggleButton(...);"))
                                .AddChild(new ImageToggleButton(ApplicationLogic.Instance.ImageButton1.normal.background))
                    )
                    // label
                    .AddChild(
                        new HBox().SetDrawBackground(false)
                                .AddChild(new Label(200, 22, "new Label(...);"))
                                .AddChild(new Label(200, 22, "a label"))
                    )
                    // spacer
                    .AddChild(
                        new HBox().SetDrawBackground(false)
                                .AddChild(new Label(200, 22, "new Spacer(100, 50);"))
                                .AddChild(new Spacer(100, 50))
                    )
                    // toggle button
                    .AddChild(
                        new HBox().SetDrawBackground(false)
                                .AddChild(new Label(200, 22, "new ToggleButton(...);"))
                                .AddChild(new ToggleButton(200, 22, "a toggle button"))
                    )
                );


        }
    }
}
