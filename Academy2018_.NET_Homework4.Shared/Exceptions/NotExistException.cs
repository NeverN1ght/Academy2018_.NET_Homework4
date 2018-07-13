using System;

namespace Academy2018_.NET_Homework4.Shared.Exceptions
{
    public class NotExistException : Exception
    {
        public NotExistException()
        {
        }

        public NotExistException(string message)
            : base(message)
        {
        }

        public NotExistException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
