namespace UnitTestingLab.BLL.Exceptions
{
    [Serializable]
    public class Num2ZeroException : Exception
    {
        public Num2ZeroException() { }
        public Num2ZeroException(string message) : base(message) { }
        public Num2ZeroException(string message, Exception inner) : base(message, inner) { }
        protected Num2ZeroException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
