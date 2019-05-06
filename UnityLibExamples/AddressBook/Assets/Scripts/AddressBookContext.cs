using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AddressBookExample.Assets.Scripts.Controller;
using AddressBookExample.Assets.Scripts.GuiPkg;
using De.Kjg.UnityLib.DI;
using De.Kjg.UnityLib.Gui;
using De.Kjg.UnityLib.MVC;
using De.Kjg.UnityLib.Signals;
using UnityEngine;

namespace AddressBookExample.Assets.Scripts
{
	class AddressBookContext : UndoableContext
	{
	    public AddressBookContext(AddressBookModule module) : base(module.Gui, module.Scene, new StandardKernel(module))
	    {
            // map app frame to its mediator
	        MapView<ApplicationFrame, ApplicationFrameMediator>();
            // map contact list to its mediator
            MapView<ContactList, ContactListMediator>();
            MapView<ContactDetails, ContactDetailsMediator>();

            // map signals to command
            var inputSignals = module.InputSignals;

            MapSignal(inputSignals.Undo, e => Undo());
            MapSignal(inputSignals.Redo, e => Redo());

            MapSignal(inputSignals.CreateContact, typeof(CreateContactCommand));
            MapSignal(inputSignals.SelectContact, typeof(SelectContactCommand));
            MapSignal(inputSignals.EditContact, typeof(EditContactCommand));

            // run the StartUpCommanfd
	        var startUpSignal = new Signal();
            MapSignal(startUpSignal, typeof(StartUpCommand));
            startUpSignal.Dispatch();
	    }
    }
}
