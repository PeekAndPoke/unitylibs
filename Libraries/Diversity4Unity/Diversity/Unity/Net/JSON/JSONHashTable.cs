using System;
using System.Collections;
using System.Text;

namespace De.Kjg.Diversity.Unity.Net.JSON
{
    public class JSONHashTable : JSONObject
    {
        private Hashtable _data;

        public JSONHashTable(Hashtable hashtable)
            : base()
        {
            _data = hashtable;
        }

        public override JSONObject this[string idx]
        {
            get { 
                var val = _data[idx];
                return JSONObject.FromUnknown(val);
            }
        }

        public override void ForEachKey(Action<string, JSONObject> func)
        {
            foreach (string key in _data.Keys)
            {
                func(key, JSONObject.FromUnknown(_data[key]));
            }
        }

        public override void DoDump(StringBuilder stringBuilder, string indent, int level, int maxLevel)
        {
            var newIndent = indent + "  ";
            
            stringBuilder.Append("{");
            stringBuilder.AppendFormat("          ({0})\n", ToString());
            
            if (CanDumpNextLevel(level, maxLevel))
            {
                ForEachKey(
                    (idx, obj) =>
                        {
                            stringBuilder.AppendFormat("{0}{1}: ", newIndent, idx);
                            obj.DoDump(stringBuilder, newIndent, level + 1, maxLevel);
                        }
                    );
            }

            stringBuilder.AppendFormat("{0}", indent);
            stringBuilder.Append("}\n");
        }

    }
}
