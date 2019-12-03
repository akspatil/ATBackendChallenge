using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AT.RateLimiter.Api
{
    public class SampleController : ApiController
    {
        //Returns a simple response
        public HttpResponseMessage GetApiResponse()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Request processed successfully");
        }
    }
}