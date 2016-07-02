using System;

namespace ChallongeNetCore
{
    public class ChallongeException : Exception
    {
        public ChallongeException()
        {
        }

        public ChallongeException(string message)
            : base(message)
        {
        }

        public ChallongeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
