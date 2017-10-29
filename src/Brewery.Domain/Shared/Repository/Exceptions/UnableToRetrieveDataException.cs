using System;

namespace Brewery.Domain.Shared.Repository.Exceptions
{
    public class UnableToRetrieveDataException : Exception
    {
        public UnableToRetrieveDataException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public UnableToRetrieveDataException(Exception innerException)
            : base(string.Empty, innerException)
        { }
    }
}