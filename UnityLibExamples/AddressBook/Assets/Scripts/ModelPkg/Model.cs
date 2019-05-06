using De.Kjg.UnityLib.MVC.DataBinding;

namespace AddressBookExample.Assets.Scripts.ModelPkg
{
    /// <summary>
    /// The holds all our data.
    /// 
    /// An instance of the model must be created by using BindableFactory.CreateObjectRecursive()
    /// <see cref="BindableFactory.CreateObjectRecursive"/>
    /// </summary>
    public class Model : Bindable<Model>
    {
        /// <summary>
        /// List of all contacts
        /// </summary>
        [Bindable] public readonly BindableList<Contact> Contacts;

        /// <summary>
        /// The currently selected contact
        /// </summary>
        [Bindable] public readonly Bindable<Contact> CurrentContact;
    }
}
