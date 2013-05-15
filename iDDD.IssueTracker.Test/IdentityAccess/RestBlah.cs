using System;
using System.Net.Http;
using System.Web.Http.SelfHost;
using Xunit.Extensions;
using iDDD.IssueTracker.Web;

namespace iDDD.IssueTracker.Test.IdentityAccess
{
    public class RestBlah
    {
        [Theory, AutoMoqData]
        public async void TEST_NAME()
        {
            var httpLocalhost = new Uri("http://localhost:12345");
            var httpSelfHostConfiguration = new HttpSelfHostConfiguration(httpLocalhost);
            WebApiConfig.Register(httpSelfHostConfiguration);
            using (var httpSelfHostServer = new HttpSelfHostServer(httpSelfHostConfiguration))
            {
                using (var httpClient = new HttpClient(httpSelfHostServer){ BaseAddress = httpLocalhost})
                {
                    var @async = await httpClient.GetStringAsync(string.Format("api/tenants/{0}/user/{1}/inrole/{2}", "ARG0", "ARG1", "ARG2"));
                    Console.WriteLine(@async);
                }
            }
        }
    }
}