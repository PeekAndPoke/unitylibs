using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AddressBookExample.Assets.Scripts.ModelPkg;
using De.Kjg.UnityLib.Gui.Elements.Basic;
using De.Kjg.UnityLib.Gui.Elements.Container;
using De.Kjg.UnityLib.Gui.Elements.Inputs;
using De.Kjg.UnityLib.Gui.Events;
using De.Kjg.UnityLib.Signals;
using UnityEngine;

namespace AddressBookExample.Assets.Scripts.GuiPkg
{
    class ContactDetails : GenericVBox<ContactDetails>
    {
        public Signal SigContactEdited = new Signal();

        protected TextField FirstName;
        protected TextField LastName;
        protected TextField Phone;
        protected TextField Email;

        public ContactDetails()
        {
            OnAddedToStage(Build, true);
        }

        protected void Build(GuiElementEvent guiElementEvent) 
        {
            if (guiElementEvent.Target != this) return;

            SetWidth(290).SetHeight(140).SetPadding(5, 5, 5, 5);

            AddChild(
                new HBox()
                    .AddChild(new Label(100, 20, __("details.firstName")))
                    .AddChild(FirstName = new TextField(190, 20).OnChange(CommitChange))
                );
            AddChild(
                new HBox()
                    .AddChild(new Label(100, 20, __("details.lastName")))
                    .AddChild(LastName = new TextField(190, 20).OnChange(CommitChange))
                );
            AddChild(
                new HBox()
                    .AddChild(new Label(100, 20, __("details.phone")))
                    .AddChild(Phone = new TextField(190, 20).OnChange(CommitChange))
                );
            AddChild(
                new HBox()
                    .AddChild(new Label(100, 20, __("details.email")))
                    .AddChild(Email = new TextField(190, 20).OnChange(CommitChange))
                );
        }

        private void CommitChange(InputElementEvent inputElementEvent)
        {
            SigContactEdited.Dispatch(
                FirstName.GetContent(),
                LastName.GetContent(),
                Phone.GetContent(),
                Email.GetContent()
            );
        }

        public void Update(Contact contact)
        {
            if (contact != null)
            {
                FirstName.SetEnabled(true).SetContent(contact.FirstName);
                LastName.SetEnabled(true).SetContent(contact.LastName);
                Phone.SetEnabled(true).SetContent(contact.Phone);
                Email.SetEnabled(true).SetContent(contact.Email);
            }
            else
            {
                FirstName.SetEnabled(false).SetContent("");
                LastName.SetEnabled(false).SetContent("");
                Phone.SetEnabled(false).SetContent("");
                Email.SetEnabled(false).SetContent("");
            }
        }
    }
}
