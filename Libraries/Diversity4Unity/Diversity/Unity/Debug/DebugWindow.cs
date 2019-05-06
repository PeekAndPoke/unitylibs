using De.Kjg.Diversity.Impl.Signals;
using De.Kjg.Diversity.Impl.UXs.Guis;
using De.Kjg.Diversity.Impl.UXs.Guis.Elements.Basic;
using De.Kjg.Diversity.Impl.UXs.Guis.Elements.Container;
using De.Kjg.Diversity.Interfaces.Abstraction.Hardware;
using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.UXs.Guis;
using De.Kjg.Diversity.Unity.Debug.Interfaces;
using De.Kjg.Diversity.Unity.Debug.Panels;
using UnityEngine;

namespace De.Kjg.Diversity.Unity.Debug
{
    /// <summary>
    /// The gui debug window
    /// </summary>
    public class DebugWindow : GenericVBox<DebugWindow>, IDebugWindow
    {
        public Signal SigCloseDebugWindow = new Signal();

        private readonly IGuiStage _clientGuiStage;
        private readonly IHardware _clientHardware;
        private readonly IRenderer _clientRenderer;

        private readonly HBox _buttonContainer;
        private readonly Box _panelContainer;
        private readonly Label _title;

        public DebugWindow(IGuiStage clientGuiStage, IRenderer clientRenderer, IHardware clientHardware)
        {
            _clientGuiStage = clientGuiStage;
            _clientRenderer = clientRenderer;
            _clientHardware = clientHardware;

            SetStyle(GetBackgroundStyle().ToStyle());

            SetWidth(600).SetHeight(500);
            SetHAlign(HorizontalAlign.Right).SetVAlign(VerticalAlign.Bottom);

            AddChild(
                new Box()
                    .SetPadding(0, 0, 0, 5)
                    .SetPercentualWidth(1)
                    .SetHeight(20)
                    .SetStyle(GetHeaderBackgroundStyle().ToStyle())
                    .AddChild(_title = new Label(200, 20, "DEBUGGER - local"))
                    .AddChild(
                        new Button(26, 20, "x")
                            .SetHAlign(HorizontalAlign.Right)
                            .OnClick(e => SigCloseDebugWindow.Dispatch())
                    )
                );

            _buttonContainer = new HBox().SetPercentualWidth(1).SetHeight(20);
            AddChild(_buttonContainer);

            _panelContainer = new Box().SetPercentualWidth(1).SetPercentualHeight(1);
            AddChild(_panelContainer);

            AddPanel(new DefaultDebugPanel());
            AddPanel(new DummyPanel());
        }

        public void SetTitle(string title)
        {
            _title.SetText("DEBUGGER - " + title);
        }

        public void AddPanel(IDebugPanel panel)
        {
            panel.SetClientGuiStage(_clientGuiStage);
            panel.SetClientHardware(_clientHardware);

            var button = new ToggleButton(100, 20, panel.GetName());
            button.OnClick(e => ShowPanel(panel, button));
            _buttonContainer.AddChild(button);

            panel.SetPercentualWidth(1);
            panel.SetPercentualHeight(1);
            _panelContainer.AddChild(panel);

            // if this is not the first panel it will be hidden
            if (_panelContainer.GetChildren().Count > 1)
            {
                panel.SetVisible(false);
            }
        }

        protected void ShowPanel(IDebugPanel panelToShow, ToggleButton buttonToHighlight)
        {
            foreach (ToggleButton button in _buttonContainer.GetChildren())
            {
                button.SetState(false);
            }
            buttonToHighlight.SetState(true);

            foreach (var panel in _panelContainer.GetChildren())
            {
                panel.SetVisible(false);
            }
            panelToShow.SetVisible(true);
        }

        public override void Draw(IRenderer renderer)
        {
            base.Draw(renderer);

            var elementsUnderMouse = _clientGuiStage.MouseInputProcessor.Result.GuiElementsUnderMouse;

            if (elementsUnderMouse.Count > 0)
            {
                var tex = new Texture2D(2, 2);
                tex.SetPixel(0, 0, new Color(1, 0, 0, 0.3f));
                tex.SetPixel(1, 0, new Color(1, 0, 0, 0.3f));
                tex.SetPixel(0, 1, new Color(1, 0, 0, 0.3f));
                tex.SetPixel(1, 1, new Color(1, 0, 0, 0.3f));
                tex.Apply();

                GUI.depth = 1;

                GUI.DrawTexture(
                    elementsUnderMouse[0].GetLayoutProcessingData().AbsoluteGeometry.ToRect(), 
                    tex
                    );

                //                GUI.color = new Color(1, 1, 1, 1);
            }
        }

        protected GUIStyle GetBackgroundStyle()
        {
            var t = new Texture2D(1, 1);
            t.SetPixel(0, 0, new Color(0.1f, 0.1f, 0.1f, 0.9f));
            t.Apply();

            var style = new GUIStyle();
            style.normal.background = t;
            return style;
        }

        protected GUIStyle GetHeaderBackgroundStyle()
        {
            var t = new Texture2D(1, 1);
            t.SetPixel(0, 0, new Color(0.0f, 0.0f, 0.0f, 0.9f));
            t.Apply();

            var style = new GUIStyle();
            style.normal.background = t;
            return style;
        }
    }
}
