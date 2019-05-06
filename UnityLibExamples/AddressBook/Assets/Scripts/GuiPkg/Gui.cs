using De.Kjg.UnityLib.Gui;
using De.Kjg.UnityLib.Unity.GuiBridge;
using UnityEngine;

namespace AddressBookExample.Assets.Scripts.GuiPkg
{
    /// <summary>
    /// The application specific implementation of the gui stage
    /// </summary>
    class Gui : GuiStage
    {
        private UnityGuiRenderer _renderer;
        private UnityHardware _hardware;

        public Gui(GUISkin skin) : base()
        {
            _renderer = new UnityGuiRenderer(skin.ToSkin());
            _hardware = new UnityHardware();
        }

        public void Update()
        {
            Render(
                _renderer,
                _hardware,
                Event.current.type == EventType.Layout
            );
        }
    }
}
