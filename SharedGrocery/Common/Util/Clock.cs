using System;
using SharedGrocery.Common.Api.Util;

namespace SharedGrocery.Common.Util
{
    public class Clock : IClock
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}