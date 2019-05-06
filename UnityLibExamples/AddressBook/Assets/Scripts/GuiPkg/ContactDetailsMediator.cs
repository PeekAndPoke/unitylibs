using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AddressBookExample.Assets.Scripts.ModelPkg;
using AddressBookExample.Assets.Scripts.Signals;
using De.Kjg.UnityLib.DI;
using De.Kjg.UnityLib.MVC.DataBinding;
using De.Kjg.UnityLib.MVC.DataBinding.Interfaces;
using De.Kjg.UnityLib.MVC.Mediators;

namespace AddressBookExample.Assets.Scripts.GuiPkg
{
    class ContactDetailsMediator : GenericMediator<ContactDetails>
    {
        #pragma warning disable 0649    // unterdrückt die Warnung, dass die Felder nie zugeweisen werden
        [Inject] public Model Model;
        [Inject] public InputSignals InputSignals;
        #pragma warning restore 0649

        public override void Initialize()
        {
            BindData(Model.CurrentContact, OnContactChanged);

            ForwardSignal(GuiElement.SigContactEdited, InputSignals.EditContact);
        }

        private void OnContactChanged(IBindable dispatcher, IBindable originaldispatcher)
        {
            GuiElement.Update(Model.CurrentContact.Value);
        }
    }
}
