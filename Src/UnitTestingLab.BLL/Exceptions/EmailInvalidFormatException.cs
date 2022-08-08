using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingLab.BLL.Exceptions
{
    [Serializable]
    public class EmailInvalidFormatException : Exception
    {
        public EmailInvalidFormatException() { }
        public EmailInvalidFormatException(string message) : base(message) { }
        public EmailInvalidFormatException(string message, Exception inner) : base(message, inner) { }
        protected EmailInvalidFormatException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
