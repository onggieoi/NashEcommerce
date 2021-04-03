using System;
using System.Globalization;

namespace backend.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}