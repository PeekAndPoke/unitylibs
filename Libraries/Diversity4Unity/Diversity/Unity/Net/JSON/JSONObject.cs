using System;
using System.Collections;
using System.Text;

namespace De.Kjg.Diversity.Unity.Net.JSON
{
    abstract public class JSONObject
    {
        protected JSONObject()
        {
        }

        #region Construction

        public static JSONObject FromHashtable(Hashtable hashtable)
        {
            return new JSONHashTable(hashtable);
        }

        public static JSONObject FromArrayList(ArrayList arrayList)
        {
            return new JSONArrayList(arrayList);
        }

        public static JSONObject FromValueObject(object val)
        {
            return new JSONValueObject(val);
        }

        public static JSONObject FromUnknown(object val)
        {
            if (val is Hashtable)
            {
                return FromHashtable((Hashtable) val);
            }
            if (val is ArrayList)
            {
                return FromArrayList((ArrayList) val);
            }
            return FromValueObject(val);
        }

        #endregion

        #region Indexer

        public virtual JSONObject this[string idx] { get { return null; } }
        public virtual JSONObject this[int idx] { get { return null; } }

        #endregion

        #region ValueGetters

        public virtual object AsObject
        {
            get { return null; }
        }

        public virtual string AsString
        {
            get { return null; }
        }

        #endregion

        #region Enumeration

        public virtual void ForEachIdx(Action<int, JSONObject> func)
        {
            
        }

        public virtual void ForEachKey(Action<string, JSONObject> func)
        {

        }

        #endregion 

        #region Dump

        public string Dump(int maxLevel = -1)
        {
            var stringBuilder = new StringBuilder();
            DoDump(stringBuilder, "", 0, maxLevel);
            return stringBuilder.ToString();
        }

        abstract public void DoDump(StringBuilder stringBuilder, string indent, int level, int maxLevel);

        protected bool CanDumpNextLevel(int level, int maxLevel)
        {
            return maxLevel == -1 || level < maxLevel;
        }

        #endregion
    }
}
