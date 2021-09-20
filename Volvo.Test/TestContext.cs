using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;

namespace Volvo.Test
{
    public class TestContext<T> : IDisposable where T : class
    {
        public HttpClient Client { get; private set; }

        public TestContext()
        {
            Client = CreateClient();
        }

        protected internal virtual HttpClient CreateClient()
        {
            TestServer testServer = CreateTestServer();

            return testServer.CreateClient();
        }

        private static TestServer CreateTestServer()
        {
            var builder = new WebHostBuilder()
                        .UseStartup<T>();    

            return new TestServer(builder);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
