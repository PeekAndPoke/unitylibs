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
    /// Undoable Command to select a command
    /// </summary>
    class SelectContactCommand : TypeSafeCommand, IUndoable
    {
        #pragma warning disable 0649    // unterdrückt die Warnung, dass die Felder nie zugeweisen werden
        /// <summary>
        /// Inject the Model
        /// </summary>
        [Inject] public Model Model;
        #pragma warning restore 0649

        /// <summary>
        /// Store the previously selected contact for undo
        /// </summary>
        protected Contact PreviouslySelectedContact;
        /// <summary>
        /// Store the newly selected contact for redo
        /// </summary>
        protected Contact CurrentlySelectedContact;

        /// <summary>
        /// Executes the command.
        /// 
        /// NOTICE that the method is called DoExecute(). See TypeSafeCommand for the reason of that.
        /// <see cref="TypeSafeCommand.Execute"/>
        /// </summary>
        /// <returns>True if everything worked fine</returns>
        public bool DoExecute(Contact contact)
        {
            PreviouslySelectedContact = Model.CurrentContact.Get();
            CurrentlySelectedContact = contact;

            return Redo();
        }

        /// <summary>
        /// Undo
        /// </summary>
        /// <returns>True if everything worked fine</returns>
        public bool Undo()
        {
            Model.CurrentContact.Set(PreviouslySelectedContact);
            return true;
        }

        /// <summary>
        /// Redo
        /// </summary>
        /// <returns>True if everything worked fine</returns>
        public bool Redo()
        {
            Model.CurrentContact.Set(CurrentlySelectedContact);
            return true;
        }
    }
}
