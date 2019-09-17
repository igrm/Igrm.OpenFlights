using Igrm.OpenFlights.Attributes;
using Igrm.OpenFlights.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Globalization;
using System.Text;

namespace Igrm.OpenFlights.Helpers
{
    public class GeneralHelper
    {
        public static (string cacheKey, string fileName, string uri) GetAttributeData<T>()
        {
            MemberInfo memberInfo = typeof(T);
            FileCacheAttribute attribute = memberInfo.GetCustomAttributes(true)
                                                      .Where(x => x.GetType() == typeof(FileCacheAttribute))
                                                      .FirstOrDefault() as FileCacheAttribute;
            if (attribute != null)
                return (cacheKey: attribute.CacheKey, fileName: attribute.FileName, uri: attribute.Uri);

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
                        decimal d;
                        if (!Decimal.TryParse(temp, out d))
                        {
                            throw new ArgumentException($"Invalid decimal format: {temp}");
                        }
                        pi.SetValue(result, d);
                    }
                    else if (pi.PropertyType.Name == "Int32")
                    {
                        int i;
                        if(!Int32.TryParse(temp, out i))
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
