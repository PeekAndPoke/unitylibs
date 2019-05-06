using System.Text;

namespace De.Kjg.Diversity.Unity.Net.JSON
{
    public class JSONValueObject : JSONObject
    {
        private readonly object _val;

        public JSONValueObject(object val)
        {
            _val = val;
        }

        public override object AsObject
        {
            get { return _val; }
        }

        public override string AsString
        {
            get
            {
                return _val.ToString();
            }
        }

        public override void DoDump(StringBuilder stringBuilder, string indent, int level, int maxLevel)
        {
            stringBuilder.AppendFormat("'{0}'          ({1})\n", AsString, ToString());
        }
    }
}