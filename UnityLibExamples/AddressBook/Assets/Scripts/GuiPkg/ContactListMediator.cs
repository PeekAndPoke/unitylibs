using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AddressBookExample.Assets.Scripts.ModelPkg;
using AddressBookExample.Assets.Scripts.Signals;
using De.Kjg.UnityLib.DI;
using De.Kjg.UnityLib.L10N.Interfaces;
using De.Kjg.UnityLib.MVC.DataBinding;
using De.Kjg.UnityLib.MVC.Mediators;
using UnityEngine;

namespace AddressBookExample.Assets.Scripts.GuiPkg
{
    class ContactListMediator : GenericMediator<ContactList>
    {
        #pragma warning disable 0649    // unterdrückt die Warnung, dass die Felder nie zugeweisen werden
        [Inject] public IL10N L10N;
        [Inject] public Model Model;
        [Inject] public InputSignals InputSignals;
        #pragma warning restore 0649

        public override void Initialize()
        {
            // bind model data to gui
            BindData(Model.Contacts, (c, o) => OnContactsChanged());
            BindData(Model.CurrentContact, (c, o) => OnContactsChanged());
            // bind gui signal to model
            ForwardSignal(GuiElement.SigNewContactClicked, InputSignals.CreateContact);
            ForwardSignal(GuiElement.SigContactSelected, InputSignals.SelectContact);
        }

        private void OnContactsChanged()
        {
            GuiElement.UpdateContacts(Model.Contacts, Model.CurrentContact.Get());
        }
    }
}
