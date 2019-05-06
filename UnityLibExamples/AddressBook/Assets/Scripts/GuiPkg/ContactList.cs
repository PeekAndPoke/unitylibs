using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AddressBookExample.Assets.Scripts.ModelPkg;
using De.Kjg.UnityLib.Gui.Elements.Basic;
using De.Kjg.UnityLib.Gui.Elements.Container;
using De.Kjg.UnityLib.Gui.Events;
using De.Kjg.UnityLib.Signals;
using UnityEngine;

namespace AddressBookExample.Assets.Scripts.GuiPkg
{
    class ContactList : GenericVBox<ContactList>
    {
        public Signal SigNewContactClicked = new Signal();
        public Signal SigContactSelected = new Signal();

        protected ScrollView ScrollView;
        protected VBox ContactsContainer;

        public ContactList()
        {
            OnAddedToStage(Build, true);
        }

        protected void Build(GuiElementEvent guiElementEvent) 
        {
            if (guiElementEvent.Target != this) return;

            SetWidth(290).SetHeight(290).SetPadding(5, 5, 5, 5);

            AddChild(new Label(200, 20, __("list.headline")));

            AddChild(
                new Button(100, 20, "Neu")
                    .OnMouseDown(e =>
                        {
                            Debug.Log("neu clicked");
                            SigNewContactClicked.Dispatch();
                        })
                );

            AddChild(
                ScrollView = new ScrollView(290, 250)
                .AddChild(ContactsContainer = new VBox().SetWidth(290))
                );
        }

        public void UpdateContacts(List<Contact> contacts, Contact currentContact)
        {
            ContactsContainer.RemoveAllChildren();

            foreach (var contact in contacts)
            {
                var contactToUse = contact;

                ContactsContainer.AddChild(
                    new Label(270, 20, (contact == currentContact ? "X " : "   ") + contact.FirstName + " " + contact.LastName)
                    .OnClick(e => SigContactSelected.Dispatch(contactToUse))
                );
            }
        }
    }
}
