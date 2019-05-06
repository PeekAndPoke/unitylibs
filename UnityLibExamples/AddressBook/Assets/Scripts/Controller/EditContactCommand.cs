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
    /// Undoable Command for editing a contacts data
    /// </summary>
    class EditContactCommand : TypeSafeCommand, IUndoable
    {
        #pragma warning disable 0649    // unterdrückt die Warnung, dass die Felder nie zugeweisen werden
        /// <summary>
        /// Inject the model
        /// </summary>
        [Inject] public Model Model;
        #pragma warning restore 0649

        // store the previous data for undo
        protected string PreviousFirstName;
        protected string PreviousLastName;
        protected string PreviousPhone;
        protected string PreviousEmail;

        // store the new data for redo
        protected string CurrentFirstName;
        protected string CurrentLastName;
        protected string CurrentPhone;
        protected string CurrentEmail;

        /// <summary>
        /// Executes the command.
        /// 
        /// NOTICE that the method is called DoExecute(). See TypeSafeCommand for the reason of that.
        /// <see cref="TypeSafeCommand.Execute"/>
        /// </summary>
        /// <returns>True if everything worked fine</returns>
        public bool DoExecute(string firstName, string lastName, string phone, string email)
        {
            // get the currently selected contact and store its data
            var currentContact = Model.CurrentContact.Get();
            if (currentContact != null)
            {
                PreviousFirstName = currentContact.FirstName;
                PreviousLastName = currentContact.LastName;
                PreviousPhone = currentContact.Phone;
                PreviousEmail = currentContact.Email;
            }
            // store the new data for redo
            CurrentFirstName = firstName;
            CurrentLastName = lastName;
            CurrentPhone = phone;
            CurrentEmail = email;

            return Redo();
        }

        /// <summary>
        /// Undo
        /// </summary>
        /// <returns>True if everything worked fine</returns>
        public bool Undo()
        {
            var currentContact = Model.CurrentContact.Get();
            if (currentContact != null)
            {
                currentContact.FirstName.Set(PreviousFirstName, false);
                currentContact.LastName.Set(PreviousLastName, false);
                currentContact.Phone.Set(PreviousPhone, false);
                currentContact.Email.Set(PreviousEmail, false);

                currentContact.Dispatch();
            }
            return true;
        }

        /// <summary>
        /// Redo
        /// </summary>
        /// <returns>True if everything worked fine</returns>
        public bool Redo()
        {
            var currentContact = Model.CurrentContact.Get();
            if (currentContact != null)
            {
                currentContact.FirstName.Set(CurrentFirstName, false);
                currentContact.LastName.Set(CurrentLastName, false);
                currentContact.Phone.Set(CurrentPhone, false);
                currentContact.Email.Set(CurrentEmail, false);

                currentContact.Dispatch();
            }
            return true;
        }
    }
}
