using System;

namespace JoberMQ.Library.Database.Helper
{
    public class DateHelper
    {
        public static DateTime GetUniversalNow() 
            => DateTime.Now.ToUniversalTime();
    }
}
