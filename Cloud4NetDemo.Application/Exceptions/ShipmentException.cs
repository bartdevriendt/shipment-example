using System;

namespace Cloud4NetDemo.Application.Exceptions
{
    public class ShipmentException : Exception
    {
        public ShipmentException(string? message) : base(message)
        {
        }
    }
}