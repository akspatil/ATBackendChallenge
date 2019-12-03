using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AT.RateLimiter.Helpers;
using NUnit.Framework;

namespace AT.RateLimiter.Tests
{
    [TestFixture]
    public class RateLimiterTests
    {
        private IRateLimiter m_RateLimiter;
        private const string KEY = "Test_LimitRate";
        private const int THROTTLE_POINT = 6;

        [SetUp]
        public void Setup()
        {
            m_RateLimiter = new RateLimiter.Helpers.RateLimiter();
        }

        [Test]
        public void TestRateLimiting()
        {
            var i = 1;
            var isLimited = false;

            do
            {
                isLimited = m_RateLimiter.ShouldLimitRate(KEY);
                i++;
            } while (i <= THROTTLE_POINT);

            Assert.IsTrue(isLimited);
        }
    }
}
