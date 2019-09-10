using Igrm.OpenFlights.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    }
}
