using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTheather.Common.Exceptions
{
    public class InvalidDataArgumentException : ApplicationException
    {
        public InvalidDataArgumentException(string message) : base(message) { }
        public InvalidDataArgumentException(string message, ApplicationException innerException) : base(message, innerException)
        {
        }
    }
}
