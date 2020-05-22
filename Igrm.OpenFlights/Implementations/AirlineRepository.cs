﻿using Igrm.OpenFlights.Interfaces;
using Igrm.OpenFlights.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Igrm.OpenFlights.Implementations
{
    public class AirlineRepository: RepositoryBase<AirlineList, Airline>, IAirlineRepository
    {
        public AirlineRepository(IDataFileLoader loader, IMemoryCache memoryCache) : base(loader, memoryCache)
        {
                
        }
    }
}
