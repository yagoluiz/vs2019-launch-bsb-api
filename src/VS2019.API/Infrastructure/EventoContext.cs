using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace VS2019.API.Infrastructure
{
    public class EventoContext
    {
        private readonly IConfiguration _configuration;

        public EventoContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection EventoConnection => new SqlConnection(_configuration.GetConnectionString("EventoConnection"));
    }
}
