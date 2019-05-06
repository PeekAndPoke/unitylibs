using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AddressBookExample.Assets.Scripts.ModelPkg;
using De.Kjg.UnityLib.Signals;

namespace AddressBookExample.Assets.Scripts.Signals
{
    public delegate void SelectContactSlot(Contact contact);

    public delegate void EditContactSlot(string firstName, string lastName, string phone, string email);

    /// <summary>
    /// This class defines the interface of the application logic.
    /// 
    /// All actions that are possible on the data model are defined here. To trigger one of the actions one just needs
    /// to dispatch one of these signals with according parameters.
    /// 
    /// GenericSignals can be used to give a hint on what parameters have to be used when dispatching the signals.
    /// </summary>
    class InputSignals
    {
        /// <summary>
        /// Signal to initiate the undo action
        /// </summary>
        public Signal Undo = new Signal();
        /// <summary>
        /// Signal to initiate the redo action
        /// </summary>
        public Signal Redo = new Signal();

        /// <summary>
        /// Signal to create a new contact
        /// </summary>
        public Signal CreateContact = new Signal();
        /// <summary>
        /// Signal to select a contact
        /// </summary>
        public GenericSignal<SelectContactSlot> SelectContact = new GenericSignal<SelectContactSlot>();
        /// <summary>
        /// Signal to edit a contacts data
        /// </summary>
        public GenericSignal<EditContactSlot> EditContact = new GenericSignal<EditContactSlot>();
    }
}
