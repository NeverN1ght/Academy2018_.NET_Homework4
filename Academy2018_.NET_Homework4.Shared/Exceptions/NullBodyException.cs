using System;
using System.Collections.Generic;
using System.Text;

namespace Academy2018_.NET_Homework4.Shared.Exceptions
{
    public class NullBodyException: Exception
    {
        public NullBodyException()
        {
        }

        public NullBodyException(string message)
            : base(message)
        {
        }

        public NullBodyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
