using System;
using System.Reflection;

namespace De.Kjg.Diversity.Impl.Utils
{
    public class UnitTestUtil
    {
        public static EventInfo GetEvent(object obj, string eventName)
        {
            var type = obj.GetType();
            return type.GetEvent(eventName);
        }

        public static object GetProtected(object obj, string fieldOrPropertyName)
        {
            var type = obj.GetType();
            // try getting the field with the name
            var field = type.GetField(fieldOrPropertyName, BindingFlags.Instance | BindingFlags.NonPublic);
            if (field != null)
            {
                return field.GetValue(obj);
            }
            // try getting the field with the name
            var property = type.GetProperty(fieldOrPropertyName, BindingFlags.Instance | BindingFlags.NonPublic);
            if (property != null)
            {
                return property.GetValue(obj, null);
            }

            throw new Exception("Could not find field or property with name '" + fieldOrPropertyName + "' in type '" + type.Name + "'");
        }
    }
}
