# Igrm.OpenFlights
OpenFlights data provider.  Serves lists of airports, aircraft, airlines and routes.  CSV files are automatically downloaded to the temporal folder, loaded into .NET models and cached in MemoryCache.  Please refer to https://openflights.org/data.html for more details.

Example: retrieve the list of all airports in the world

```C#
using HttpClient httpClient = new HttpClient();
using IOpenFlightsDataCache cache = new OpenFlightsDataCache(httpClient);
AirportList airports = await cache.GetAirportsAsync();
```

![Nuget](https://img.shields.io/nuget/v/Igrm.OpenFlights)