using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AT.RateLimiter.Helpers
{
    public class RateLimiter : IRateLimiter
    {
        private ConcurrentDictionary<string, RateLimitInfo> m_Cache;

        public RateLimiter()
        {
            m_Cache = new ConcurrentDictionary<string, RateLimitInfo>();
        }

        public bool ShouldLimitRate(string key)
        {
            RateLimitInfo rateLimitInfo = null;
            var retVal = false;

            m_Cache.TryGetValue(key, out rateLimitInfo);

            //ExpirationTime check only to enable resetting of the requestCount after a specific wait period
            if (rateLimitInfo == null || rateLimitInfo.ExpirationTime <= DateTime.Now)
            {
                rateLimitInfo = new RateLimitInfo()
                {
                    RequestCount = 0,
                    ExpirationTime = DateTime.Now.AddSeconds(Constants.TIME_LIMIT)
                };
            }

            rateLimitInfo.RequestCount++;
            m_Cache[key] = rateLimitInfo;

            retVal = rateLimitInfo.RequestCount > Constants.REQUEST_LIMIT;

            return retVal;
        }
    }
}