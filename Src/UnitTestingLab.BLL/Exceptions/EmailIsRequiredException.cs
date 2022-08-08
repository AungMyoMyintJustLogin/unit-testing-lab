namespace UnitTestingLab.BLL.Exceptions
{
    [Serializable]
    public class EmailIsRequiredException : Exception
    {
        public EmailIsRequiredException() { }
        public EmailIsRequiredException(string message) : base(message) { }
        public EmailIsRequiredException(string message, Exception inner) : base(message, inner) { }
        protected EmailIsRequiredException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}
