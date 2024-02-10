using System;
namespace ProjecIntegration.Api.Application.Common.Exceptions
{
    public class NotFoundException :ApplicationException
    {
        public NotFoundException(string message):base(message) 
        { }
        public NotFoundException(string message, ApplicationException innerException) : base(message, innerException)
        {
        }
    }
}
