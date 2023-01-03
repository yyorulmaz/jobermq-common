using System;
using System.Diagnostics.CodeAnalysis;

namespace JoberMQ.Library.Helpers
{
    internal class ExceptionHelper
    {
        public static void ArgumentNullException(object value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
        }
    }
}
