using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AT.RateLimiter.Helpers
{
    public class Constants
    {
        //Could be set as Environment Variables or in Registry for being able to change the settings according to the scalability
        public const int REQUEST_LIMIT = 5;
        public const double TIME_LIMIT = 30; //in seconds
        public const int RETRY_TIME = 10;
    }
}