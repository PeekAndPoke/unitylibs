using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using De.Kjg.UnityLib.MVC.DataBinding;

namespace AddressBookExample.Assets.Scripts.ModelPkg
{
    /// <summary>
    /// Contains all data for one contact
    /// </summary>
    public class Contact : Bindable<Contact>
    {
        [Bindable] public readonly Bindable<String> FirstName;
        [Bindable] public readonly Bindable<String> LastName;
        [Bindable] public readonly Bindable<String> Phone;
        [Bindable] public readonly Bindable<String> Email;
    }
}
