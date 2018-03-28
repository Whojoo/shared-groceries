using System;
using JWT;
using SharedGrocery.Common.Api.Util;

namespace SharedGrocery.Common.Util
{
    public class Clock : IClock
    {
        private readonly IDateTimeProvider _dateTimeProvider = new UtcDateTimeProvider();
        
        public DateTime Now()
        {
            return _dateTimeProvider.GetNow().UtcDateTime;
        }

        public long NowSeconds()
        {
            return (long) UnixEpoch.GetSecondsSince(Now());
        }
    }
}