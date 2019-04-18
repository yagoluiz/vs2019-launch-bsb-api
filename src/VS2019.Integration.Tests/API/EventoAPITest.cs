using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using VS2019.API;
using Xunit;

namespace VS2019.Integration.Tests.API
{
    public class EventoAPITest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;

        public EventoAPITest(WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task Get_HttpStatusCodeOK()
        {
            int limit = 10;

            var response = await _httpClient.GetAsync($"/api/v1/eventos/limit/{limit}");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_HttpStatusCodeInternalServerError()
        {
            int limit = -10;

            var response = await _httpClient.GetAsync($"/api/v1/eventos/limit/{limit}");

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }
    }
}
