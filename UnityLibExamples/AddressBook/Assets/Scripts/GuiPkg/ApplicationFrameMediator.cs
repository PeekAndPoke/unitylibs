using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AddressBookExample.Assets.Scripts.Signals;
using De.Kjg.UnityLib.DI;
using De.Kjg.UnityLib.L10N.Interfaces;
using De.Kjg.UnityLib.MVC.Mediators;

namespace AddressBookExample.Assets.Scripts.GuiPkg
{
    class ApplicationFrameMediator : GenericMediator<ApplicationFrame>
    {
        #pragma warning disable 0649    // unterdrückt die Warnung, dass die Felder nie zugeweisen werden
        [Inject] public IL10N L10N;
        [Inject] public InputSignals InputSignals;
        #pragma warning restore 0649

        public override void Initialize()
        {
            ForwardSignal(GuiElement.SigUndoClicked, InputSignals.Undo);
            ForwardSignal(GuiElement.SigRedoClicked, InputSignals.Redo);
        }
    }
}
