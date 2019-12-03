using System;

namespace AT.RateLimiter.Helpers
{
    public class RateLimitInfo
    {
        public int RequestCount { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}