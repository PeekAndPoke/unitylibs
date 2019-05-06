using System.Collections.Generic;
using System.Linq;
using De.Kjg.Diversity.Interfaces.MVC.DataBinding;
using De.Kjg.Diversity.Interfaces.MVC.DataBinding.Watchers;

namespace De.Kjg.Diversity.Impl.MVC.DataBinding.Watchers
{
    public delegate void BindableListWatcherCallback<T>(List<T> added, List<T> remaining, List<T> removed);

    public class BindableListWatcher<TElementType> : IBindableListWatcher where TElementType : IBindable
    {
        protected readonly BindableList<TElementType> List;
        
        protected readonly BindableListWatcherCallback<TElementType> Callback = null;
        
        /// <summary>
        /// Stores the items we knew the last time the watched list has changed
        /// </summary>
        protected List<TElementType> KnownItemsList = new List<TElementType>();
        /// <summary>
        /// Temp list used to fill up list items that are new
        /// </summary>
        protected List<TElementType> AddedItems = new List<TElementType>(); 

        protected List<TElementType> RemainingItems = new List<TElementType>();
 
        protected List<TElementType> RemovedItems = new List<TElementType>();

        public BindableListWatcher(BindableList<TElementType> list, BindableListWatcherCallback<TElementType> callback)
        {
            List = list;
            Callback = callback;
            List.OnChange(OnListChanged, true);
        }

        public void Destroy()
        {
            List.RemoveOnChange(OnListChanged);
        }

        private void OnListChanged(IBindable dispatcher, IBindable originaldispatcher)
        {
            AddedItems.Clear();
            RemainingItems.Clear();
            RemovedItems.Clear();

            var watchedListItemsCopy = List.ToList();

            foreach (var listItem in watchedListItemsCopy)
            {
                if (KnownItemsList.Contains(listItem))
                {
                    RemainingItems.Add(listItem);
                    KnownItemsList.Remove(listItem);
                }
                else
                {
                    AddedItems.Add(listItem);
                }
            }

            RemovedItems = KnownItemsList;

            KnownItemsList = List.ToList();

            if (Callback != null)
            {
                Callback.Invoke(AddedItems, RemainingItems, RemovedItems);
            }
        }
    }
}
