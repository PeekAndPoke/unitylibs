using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using De.Kjg.UnityLib.Gui.Elements.Basic;
using De.Kjg.UnityLib.Gui.Elements.Container;
using De.Kjg.UnityLib.Gui.Elements.Inputs;
using GuiLayout.Assets.Scripts.Attached;
using UnityEngine;

namespace GuiLayout.Assets.Scripts.Layouts
{
    class InputElementsLayout : GenericScrollView<InputElementsLayout>
    {
        public InputElementsLayout() : base(700, 400)
        {
            SetPadding(15, 15, 15, 15);

            Label hScrollValue;
            Label hSliderValue;
            Label passwordValue;
            Label textAreaValue;
            Label textFieldValue;
            Label vScrollValue;
            Label vSliderValue;

            AddChild(
                new VBox().SetMouseEnabled(false).SetPadding(5, 5, 5, 5).SetPercentualWidth(1).SetSpacing(5)
                    // HScrollbar
                    .AddChild(
                        new HBox().SetDrawBackground(false).SetSpacing(5)
                                .AddChild(new Label(180, 22, "new HScrollbar(...);"))
                                .AddChild(hScrollValue = new Label(100, 22, ""))
                                .AddChild(new HScrollbar(300, 22, 50, 0, 100).SetSize(50).OnChange(e => hScrollValue.SetText(e.Content)))
                    )
                    // HSlider
                    .AddChild(
                        new HBox().SetDrawBackground(false).SetSpacing(5)
                                .AddChild(new Label(180, 22, "new HSlider(...);"))
                                .AddChild(hSliderValue = new Label(100, 22, ""))
                                .AddChild(new HSlider(300, 22, 50, 0, 100).OnChange(e => hSliderValue.SetText(e.Content)))
                    )
                    // PasswordField
                    .AddChild(
                        new HBox().SetDrawBackground(false).SetSpacing(5)
                                .AddChild(new Label(180, 22, "new PasswordField(...);"))
                                .AddChild(passwordValue = new Label(100, 22, ""))
                                .AddChild(new PasswordField(300, 22).SetCharMask('*').OnChange(e => passwordValue.SetText(e.Content)))
                    )
                    // PasswordField
                    .AddChild(
                        new HBox().SetDrawBackground(false).SetSpacing(5)
                                .AddChild(new Label(180, 22, "new TextArea(...);"))
                                .AddChild(textAreaValue = new Label(100, 100, ""))
                                .AddChild(new TextArea(300, 100).OnChange(e => textAreaValue.SetText(e.Content)))
                    )
                    // TextField
                    .AddChild(
                        new HBox().SetDrawBackground(false).SetSpacing(5)
                                .AddChild(new Label(180, 22, "new TextField(...);"))
                                .AddChild(textFieldValue = new Label(100, 22, ""))
                                .AddChild(new TextField(300, 22).OnChange(e => textFieldValue.SetText(e.Content)))
                    )
                    // VScrollbar
                    .AddChild(
                        new HBox().SetDrawBackground(false).SetSpacing(5)
                                .AddChild(new Label(180, 22, "new VScrollbar(...);"))
                                .AddChild(vScrollValue = new Label(100, 22, ""))
                                .AddChild(new VScrollbar(20, 50, 50, 0, 100).SetSize(50).OnChange(e => vScrollValue.SetText(e.Content)))
                    )
                    // VSlider
                    .AddChild(
                        new HBox().SetDrawBackground(false).SetSpacing(5)
                                .AddChild(new Label(180, 22, "new VSlider(...);"))
                                .AddChild(vSliderValue = new Label(100, 22, ""))
                                .AddChild(new VSlider(20, 50, 50, 0, 100).OnChange(e => vSliderValue.SetText(e.Content)))
                    )

                );


        }
    }
}
