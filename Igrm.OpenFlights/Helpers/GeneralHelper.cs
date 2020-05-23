using Igrm.OpenFlights.Attributes;
using Igrm.OpenFlights.Constants;
using System;
using System.Linq;
using System.Reflection;

namespace Igrm.OpenFlights.Helpers
{
    public sealed class GeneralHelper
    {
        public static (string cacheKey, string fileName, string uri) GetAttributeData<T>()
        {
            MemberInfo memberInfo = typeof(T);
            if (memberInfo.GetCustomAttributes(true)
                          .Where(x => x.GetType() == typeof(FileCacheAttribute))
                          .FirstOrDefault() is FileCacheAttribute attribute)
            {
                return (cacheKey: attribute.CacheKey, fileName: attribute.FileName, uri: attribute.Uri);
            }

            return (cacheKey: String.Empty, fileName: String.Empty, uri: String.Empty);
        }


        public static T Create<T>(string[] array) where T: new()
        {
            T result = new T();
            int position = 0;

            Type resultType = typeof(T);
            PropertyInfo[] info = resultType.GetProperties();

            foreach (var item in array)
            {
                PropertyInfo pi = info[position];
                if (item != null && item != OpenFligthsConstants.EMPTY)
                {
                    var temp = item.Trim('"').Trim();

                    if (pi.PropertyType.Name == "Decimal")
                    {
                        if (!Decimal.TryParse(temp, out decimal d))
                        {
                            throw new ArgumentException($"Invalid decimal format: {temp}");
                        }
                        pi.SetValue(result, d);
                    }
                    else if (pi.PropertyType.Name == "Int32")
                    {
                        if(!Int32.TryParse(temp, out int i))
                        {
                            throw new ArgumentException($"Invalid integer format: {temp}");
                        }
                        pi.SetValue(result, i);
                    }
                    else
                        pi.SetValue(result, temp);
                }
                position++;
            }

            return result;
        }
    }
}
