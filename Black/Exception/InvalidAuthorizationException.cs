namespace Black.Exception
{
    public class InvalidAuthorizationException : System.Exception
    {
        public InvalidAuthorizationException() { }
        public InvalidAuthorizationException(string message) : base(message) { }
        public InvalidAuthorizationException(string message, System.Exception inner) : base(message, inner) { }
    }
}
