using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingLab.BLL.Exceptions
{
    [Serializable]
    public class NameIsRequiredException : Exception
    {
        public NameIsRequiredException() { }
        public NameIsRequiredException(string message) : base(message) { }
        public NameIsRequiredException(string message, Exception inner) : base(message, inner) { }
        protected NameIsRequiredException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
