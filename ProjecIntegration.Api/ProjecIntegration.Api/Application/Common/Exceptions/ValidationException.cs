using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecIntegration.Api.Application.Common.Exception
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(string message) : base(message)
        { }
        public ValidationException(string message, ApplicationException innerException) : base(message, innerException)
        {
        }
    }
}
