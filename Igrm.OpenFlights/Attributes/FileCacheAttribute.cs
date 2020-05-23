using System;

namespace Igrm.OpenFlights.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class FileCacheAttribute : Attribute
    {
        private string _fileName;
        private string _uri;
        private string _cacheKey;

        public string FileName { get => _fileName; set => _fileName = value; }
        public string Uri { get => _uri; set => _uri = value; }

        public string CacheKey { get => _cacheKey; set => _cacheKey = value; }

        public FileCacheAttribute()
        {
            _fileName = String.Empty;
            _uri = String.Empty;
            _cacheKey = String.Empty;
        }
    }
}
