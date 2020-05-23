using CsvHelper;
using Igrm.OpenFlights.Constants;
using Igrm.OpenFlights.Exceptions;
using Igrm.OpenFlights.Helpers;
using Igrm.OpenFlights.Interfaces;
using Igrm.OpenFlights.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

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
            var (cacheKey, fileName, uri) = GeneralHelper.GetAttributeData<T>();

            if (String.IsNullOrEmpty(cacheKey) || String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(uri) 
                || !Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            {
                throw new FileCacheAttributeNotProvidedException();
            }
            else if (FileExists(fileName) && !overwrite)
            {
                return;
            }
            else
            {
                var result = await _httpClient.GetAsync(uri);
                using (StreamWriter writer = File.CreateText($@"{_tempPath}\{OpenFligthsConstants.TEMP_DIRECTORY_NAME}\{fileName}"))
                {
                    await writer.WriteLineAsync(await result.Content.ReadAsStringAsync());
                }
            }

        }

        public async Task<List<string[]>> ReadFileAsync(string name)
        {
            List<string[]> lines = new List<string[]>();
           
            if (FileExists(name))
            {
                using (TextReader reader = File.OpenText($@"{_tempPath}\{OpenFligthsConstants.TEMP_DIRECTORY_NAME}\{name}"))
                {
                    using (CsvReader csv = new CsvReader(reader))
                    {
                        csv.Configuration.Delimiter = OpenFligthsConstants.DELIMETER;
                        csv.Configuration.HasHeaderRecord = false;
                        while (await csv.ReadAsync())
                        {
                            lines.Add(csv.Context.Record);
                        }
                    }
                }
            }
            else
            {
                throw new FileNotFoundException(name);
            }
            return lines;
        }
    }
}
