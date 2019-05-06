using System.Collections.Generic;
using De.Kjg.Diversity.Impl.I18n.Exceptions;
using De.Kjg.Diversity.Interfaces.I18n;

namespace De.Kjg.Diversity.Impl.I18n
{
    public class LocalizedDataHolder : II18NDataHolder
    {
        /** the hash containing data */
        protected Dictionary<string, object> DataHash = new Dictionary<string, object>();
		/** the hash containing nested data holders */
        protected Dictionary<string, LocalizedDataHolder> NestedHash = new Dictionary<string, LocalizedDataHolder>();
		/** the name of this data holder - only needed for dumping data */
		protected string GroupName;
		
		public LocalizedDataHolder(string groupName) {
            GroupName = groupName;
		}

		/**
		 * get data for the given id
		 * 
		 * @param id
		 * 
		 * @return the data stored for the given id
		 */
		public object GetData(string id) 
        {
            if (DataHash.ContainsKey(id))
            {
                return DataHash[id];
			}
			return null;
		}


		/**
		 * set data by id
		 * 
		 * @param id the id of the data, id must not be null or an empty string
		 * @param data the data
		 * 
		 * @throws Error if id is null or an empty string
		 */
		public void SetData(string id, object data) 
        {
			if(id != null) {
                DataHash[id] = data;
			}
			else {
                throw new I18NException("The id must not be empty!");
			}
		}

        /**
         * Resolve a path inside the nested holders.
         * 
         * <p>If the parameter path is null or an empty array the holders return itself (this). The is the exit condition for recursively 
         * resolving the path.</p>
         * 
         * <p>You can specify whether not existing path should be created using the createHolders parameter. This makes sense while filling
         * in data. In this case the method will always return a LocalizedDataHolder instance.</p>
         * 
         * <p>It does not make much sense to set createHolders to true while reading data.</p>
         * 
         * @param path path to resolve inside the nested holders
         * @param createHolders set to true to create nested holders if they do not exists
         * 
         * @return an instance of LocalizedDataHolder or null if nothing was found in the given path
         */
        public II18NDataHolder ResolvePath(List<string> path, bool createHolders) 
        {
			// aborting condition
			if (null == path || path.Count == 0) {
				return this;
			}

			// make a copy of the given path
            var pathCopy = new List<string>(path);
            var nextStep = pathCopy[0];
            pathCopy.RemoveAt(0);

			// get the nested item
			var nested = GetNested(nextStep, createHolders);
			
			// if the nested can not be found (will only happen if createHolders == false) we return null
			if(nested == null) {
				return null;
			}

			return nested.ResolvePath(pathCopy, createHolders);
		}

		/**
		 * get a nested data holder by name
		 * 
		 * @param key the name of the nested holder to get
		 * @param createIfNotExisting if this is set to true a LocalizedDataHolder will be created if not already existing for the given key
		 * 
		 * @return an instance of LocalizedDataHolder or null if nothing was found inside the nestedHash
		 */
		private LocalizedDataHolder GetNested(string key, bool createIfNotExisting) 
        {
            if (!NestedHash.ContainsKey(key))
            {
				// if we have not found it and we dont want to automatically create it we return null
				if (!createIfNotExisting) {
					return null;
				}
				NestedHash[key] = new LocalizedDataHolder(key);
			}
			return NestedHash[key];
		}

    }
}
