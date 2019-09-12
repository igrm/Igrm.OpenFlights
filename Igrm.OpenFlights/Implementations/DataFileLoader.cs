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
using Igrm.OpenFlights.Helpers;

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

            return Task.WhenAll(LoadFileAsync<AircraftsList>(overwrite), 
                                LoadFileAsync<AirlineList>(overwrite), 
                                LoadFileAsync<AirportsList>(overwrite), 
                                LoadFileAsync<RoutesList>(overwrite) );
        }

        public async Task LoadFileAsync<T>(bool overwrite = false)
        {
            var attributes = GeneralHelper.GetAttributeData<T>();

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

        public List<string[]> ReadFile(string name)
        {
            List<string[]> lines = new List<string[]>();

            if (FileExists(name))
            {
                lines = File.ReadAllLines($@"{_tempPath}\{OpenFligthsConstants.TEMP_DIRECTORY_NAME}\{name}").Select(x => x.Split(',')).ToList();
            }
            else
            {
                throw new FileNotFoundException(name);
            }
            return lines;
        }
    }
}
