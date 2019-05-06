using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using De.Kjg.UnityLib.Gui.Elements.Basic;
using De.Kjg.UnityLib.Gui.Elements.Container;
using De.Kjg.UnityLib.Signals;
using UnityEngine;

namespace AddressBookExample.Assets.Scripts.GuiPkg
{
    class ApplicationFrame : GenericCanvas<ApplicationFrame>
    {
        public Signal SigUndoClicked = new Signal();
        public Signal SigRedoClicked = new Signal();

        public ApplicationFrame()
        {
            AddChild(new ContactList());

            AddChild(new ContactDetails().SetX(300));
            AddChild(new ContactDetails().SetX(300).SetY(150));

            AddChild(new ContactList().SetX(600));

            AddChild(
                new Button(100, 20, "<= Undo").SetY(370)
                .OnClick(e => SigUndoClicked.Dispatch())
                );
            AddChild(
                new Button(100, 20, "Redo =>").SetX(100).SetY(370)
                .OnClick(e => SigRedoClicked.Dispatch())
                );
        }
    }
}
