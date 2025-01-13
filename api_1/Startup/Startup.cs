using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace api_1.Startup
{
    public class Startup
    {

        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = _configuration.GetConnectionString("TeijinDB");
            services.AddTransient<SqlConnection>(provider => new SqlConnection(connectionString));
        }
    }
}
