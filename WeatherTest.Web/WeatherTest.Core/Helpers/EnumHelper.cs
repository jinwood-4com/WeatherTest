using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WeatherTest.Core.Helpers
{
    public static class EnumHelper<T>
    {
        public static IDictionary<string, T> GetValues(bool ignoreCase)
        {
            var enumValues = new Dictionary<string, T>();

            foreach (var fi in typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                var key = fi.Name;

                var display = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

                if (display != null)
                    key = (display.Length > 0) ? display[0].Description : fi.Name;

                if (ignoreCase)
                    key = key.ToLower();

                if (!enumValues.ContainsKey(key))
                    enumValues[key] = (T)fi.GetRawConstantValue();
            }

            return enumValues;
        }

        public static T Parse(string value)
        {
            T result;

            try
            {
                result = (T)Enum.Parse(typeof(T), value, true);
            }
            catch (Exception)
            {
                try
                {
                    result = ParseDisplayValues(value, true);
                }
                catch (Exception)
                {
                    return default(T);
                }
            }


            return result;
        }

        private static T ParseDisplayValues(string value, bool ignoreCase)
        {
            var values = GetValues(ignoreCase);

            var key = ignoreCase ? value.ToLower() : value;

            if (values.ContainsKey(key))
                return values[key];

            throw new ArgumentException(value);
        }
    }
}
