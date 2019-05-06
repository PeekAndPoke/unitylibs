namespace De.Kjg.Diversity.Impl.I18n.Strings
{
    public class StringHolder
    {
        private readonly string _str;

        public StringHolder()
        {
            _str = "";
        }

        public StringHolder(string str)
        {
            _str = str;
        }

        public override string ToString()
        {
            return _str;
        }

        public static implicit operator string(StringHolder str)
        {
            return str.ToString();
        }

        public static implicit operator StringHolder(string str)
        {
            return new StringHolder(str);
        }
    }
}
