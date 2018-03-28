using System;

namespace SharedGrocery.Common.Api.Util
{
    public interface IClock
    {
        DateTime Now();
    }
}