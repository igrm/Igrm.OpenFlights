using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenFlights.Exceptions
{
    public class FileCacheAttributeNotProvidedException: Exception
    {
        public FileCacheAttributeNotProvidedException():base()
        {
        }

        public FileCacheAttributeNotProvidedException(string message) : base(message)
        {
        }

        public FileCacheAttributeNotProvidedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
