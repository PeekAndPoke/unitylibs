using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AddressBookExample.Assets.Scripts.ModelPkg;
using De.Kjg.UnityLib.DI;
using De.Kjg.UnityLib.MVC.Commands;
using De.Kjg.UnityLib.MVC.DataBinding;
using De.Kjg.UnityLib.MVC.Interfaces;
using UnityEngine;

namespace AddressBookExample.Assets.Scripts.Controller
{
    /// <summary>
    /// Undoable command to create a contact
    /// </summary>
    class CreateContactCommand : TypeSafeCommand, IUndoable
    {
        #pragma warning disable 0649    // unterdrückt die Warnung, dass die Felder nie zugeweisen werden
        /// <summary>
        /// Inject the model
        /// <see cref="AddressBookModule.Load()"/>
        /// </summary>
        [Inject] public Model Model;
        #pragma warning restore 0649

        /// <summary>
        /// Stores the created contact for undo / redo.
        /// </summary>
        protected Contact CreatedContact;

        /// <summary>
        /// Executes the command.
        /// 
        /// NOTICE that the method is called DoExecute(). See TypeSafeCommand for the reason of that.
        /// <see cref="TypeSafeCommand.Execute"/>
        /// </summary>
        /// <returns>True if everything worked fine</returns>
        public bool DoExecute()
        {
            // create and store the contact
            CreatedContact = BindableFactory.CreateObjectRecursive<Contact>();
            CreatedContact.FirstName.Set("<new>");
            // call redo which really manipulates the model
            return Redo();
        }

        /// <summary>
        /// Undo
        /// </summary>
        /// <returns>True if everything worked fine</returns>
        public bool Undo()
        {
            // remove the contact
            Model.Contacts.Remove(CreatedContact);
            return true;
        }

        /// <summary>
        /// Redo
        /// </summary>
        /// <returns>True if everything worked fine</returns>
        public bool Redo()
        {
            // add the contact
            Model.Contacts.Add(CreatedContact);
            return true;
        }
    }
}
