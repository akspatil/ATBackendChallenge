using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AT.RateLimiter.Helpers
{
    public interface IRateLimiter
    {
        bool ShouldLimitRate(string key);
    }
}