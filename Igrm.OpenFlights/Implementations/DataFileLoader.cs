using Igrm.OpenFlights.Attributes;
using Igrm.OpenFlights.Constants;
using Igrm.OpenFlights.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Igrm.OpenFlights.Exceptions;
using Igrm.OpenFlights.Models;

namespace Igrm.OpenFlights.Implementations
{
    public class DataFileLoader : IDataFileLoader
    {
        private readonly HttpClient _httpClient;
        private readonly string _tempPath;

        public DataFileLoader(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _tempPath = Path.GetTempPath();
        }

        private bool OpenFlightsDirectoryExists()
        {
            return Directory.Exists($@"{_tempPath}\{OpenFligthsConstants.TEMP_DIRECTORY_NAME}");
        }

        public bool FileExists(string name)
        {
            return File.Exists($@"{_tempPath}\{OpenFligthsConstants.TEMP_DIRECTORY_NAME}\{name}");
        }

        public Task LoadAllFilesAsync(bool overwrite = false)
        {
            if(!OpenFlightsDirectoryExists())
            {
                Directory.CreateDirectory($@"{_tempPath}\{OpenFligthsConstants.TEMP_DIRECTORY_NAME}");
            }

            return Task.WhenAll(LoadFileAsync<Aircraft>(overwrite), 
                                LoadFileAsync<Airline>(overwrite), 
                                LoadFileAsync<Airport>(overwrite), 
                                LoadFileAsync<Route>(overwrite) );
        }

        public async Task LoadFileAsync<T>(bool overwrite = false)
        {
            var attributes = GetAttributeData<T>();

            if (String.IsNullOrEmpty(attributes.fileName) && String.IsNullOrEmpty(attributes.uri) 
                && !Uri.IsWellFormedUriString(attributes.uri, UriKind.Absolute))
            {
                throw new FileCacheAttributeNotProvidedException();
            }
            else if (FileExists(attributes.fileName) && !overwrite)
            {
                return;
            }
            else
            {
                var result = await _httpClient.GetAsync(attributes.uri);
                File.WriteAllText($@"{_tempPath}\{OpenFligthsConstants.TEMP_DIRECTORY_NAME}\{attributes.fileName}",await result.Content.ReadAsStringAsync());
            }

        }

        private (string cacheKey, string fileName, string uri) GetAttributeData<T>()
        {
            MemberInfo memberInfo = typeof(T);
            FileCacheAttribute attribute = memberInfo.GetCustomAttributes(true)
                                                      .Where(x=>x.GetType() == typeof(FileCacheAttribute))
                                                      .FirstOrDefault() as FileCacheAttribute;
            if (attribute!=null)
                return (cacheKey: attribute.CacheKey, fileName: attribute.FileName, uri: attribute.Uri);

            return (cacheKey: String.Empty, fileName: String.Empty, uri: String.Empty);
        }
    }
}
