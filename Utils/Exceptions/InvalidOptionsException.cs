using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleMapDistanceMatrix.Exceptions
{
    /// <inheritdoc />
    public class InvalidOptionsException : Exception
    {
        public InvalidOptionsException(string message) : base(message)
        {
        }
    }
}
