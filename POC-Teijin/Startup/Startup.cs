using System.Text.Json.Serialization;

namespace POC_Teijin.Startup
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.TypeInfoResolver = new AppJsonSerializerContext(options.JsonSerializerOptions);
                });
        }
    }
}
