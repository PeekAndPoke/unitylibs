namespace De.Kjg.Diversity.Impl.Utils
{
    class UniqueIdGenerator
    {
        private static int _uniqueIdCounter = 0;

        public static int GetInt()
        {
            return _uniqueIdCounter++;
        }

        public static string GetString()
        {
            return (++_uniqueIdCounter).ToString();
        }
    }
}
