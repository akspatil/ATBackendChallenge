using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using AT.RateLimiter.Helpers;

namespace AT.RateLimiter.Handlers
{
    public class ThrottlingHandler : DelegatingHandler  
    {
        //Checks all incoming requests for throttling
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response;
            try
            {
                var rateLimiter = (IRateLimiter)request.GetDependencyScope().GetService(typeof(IRateLimiter));
                var key = HttpUtility.ParseQueryString(request.RequestUri.Query).Get("key");                 

                if (!string.IsNullOrEmpty(key))
                {
                    if (rateLimiter.ShouldLimitRate(key))
                    {
                        response = request.CreateErrorResponse
                            ((System.Net.HttpStatusCode)429, $"Too many requests. Try after {Constants.RETRY_TIME} seconds"); 
                    }
                    else
                    {
                        return await base.SendAsync(request, cancellationToken);
                    }
                }
                else
                {
                    response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
                }
            }
            catch(Exception ex)
            {
                response = request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
    }
}