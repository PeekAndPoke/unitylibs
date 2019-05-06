using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using De.Kjg.UnityLib.Gui;
using De.Kjg.UnityLib.Gui.Elements.Basic;
using De.Kjg.UnityLib.Gui.Elements.Container;
using De.Kjg.UnityLib.Gui.Events;
using De.Kjg.UnityLib.Gui.Interfaces;
using GuiLayout.Assets.Scripts.Layouts;

namespace GuiLayout.Assets.Scripts
{
    class GuiMain : GenericCanvas<GuiMain>
    {
        private Canvas _layoutContainer;
        
        public GuiMain()
        {
            SetPercentualWidth(1);
            SetPercentualHeight(1);

            AddChild(
                new VBox().SetDrawBackground(false).SetPercentualWidth(1)
                    .AddChild(
                        new HBox()
                            .AddChild(new Button(120, 22, "Canvas").OnClick(e => ShowLayout<CanvasLayout>()))
                            .AddChild(new Button(120, 22, "Box").OnClick(e => ShowLayout<BoxLayout>()))
                            .AddChild(new Button(120, 22, "VBox").OnClick(e => ShowLayout<VBoxLayout>()))
                            .AddChild(new Button(120, 22, "VBox 100%").OnClick(e => ShowLayout<VBox100Layout>()))
                            .AddChild(new Button(120, 22, "HBox").OnClick(e => ShowLayout<HBoxLayout>()))
                            .AddChild(new Button(120, 22, "Scroll").OnClick(e => ShowLayout<ScrollViewLayout>()))
                    )
                    .AddChild(
                        new HBox()
                            .AddChild(new Button(120, 22, "Basic Elements").OnClick(e => ShowLayout<BasicElementsLayout>()))
                            .AddChild(new Button(120, 22, "Input Elements").OnClick(e => ShowLayout<InputElementsLayout>()))
                    )
                    .AddVSpacer(10)
                    .AddChild(
                        _layoutContainer = new Canvas().SetPercentualWidth(1) 
                    )
                );

            AddChild(
                new Button(100, 22, "Debug Window").SetVAlign(VerticalAlign.Bottom).SetHAlign(HorizontalAlign.Right)
                                          .OnClick(e => GetStage().SetDebugMode(true))
                );
        }

        private void ShowLayout<T>() where T : IGuiElement
        {
            _layoutContainer.RemoveAllChildren(true);

            var elem = Activator.CreateInstance<T>();
            elem.SetX(0);
            elem.SetY(0);
            _layoutContainer.AddChild(elem);
        }
    }
}
