using System;
using System.Collections;
using System.Text;

namespace De.Kjg.Diversity.Unity.Net.JSON
{
    public class JSONArrayList : JSONObject
    {
        public ArrayList Data { get; private set; }

        public JSONArrayList(ArrayList arrayList)
        {
            Data = arrayList;
        }

        public override JSONObject this[string idx]
        {
            get { return FromUnknown(Data[int.Parse(idx)]); }
        }

        public override JSONObject this[int idx]
        {
            get { return FromUnknown(Data[idx]); }
        }

        public override void ForEachIdx(Action<int, JSONObject> func)
        {
            int idx = 0;
            foreach (var item in Data)
            {
                func(idx, JSONObject.FromUnknown(item));
                idx++;
            }
        }

        public override void DoDump(StringBuilder stringBuilder, string indent, int level, int maxLevel)
        {
            var newIndent = indent + "  ";
            stringBuilder.AppendFormat("[          ({0})\n", ToString());

            if (CanDumpNextLevel(level, maxLevel))
            {
                ForEachIdx(
                    (idx, obj) =>
                        {
                            stringBuilder.AppendFormat("{0}{1}: ", newIndent, idx);
                            obj.DoDump(stringBuilder, newIndent, level + 1, maxLevel);
                        }
                    );
            }

            stringBuilder.AppendFormat("{0}]\n", indent);
        }
    }
}