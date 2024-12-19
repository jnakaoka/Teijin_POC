using System.Text.Json.Serialization.Metadata;
using System.Text.Json;

namespace POC_Teijin.Startup
{
    public class AppJsonSerializerContext : IJsonTypeInfoResolver
    {
        private readonly JsonSerializerOptions _options;

        public AppJsonSerializerContext(JsonSerializerOptions options)
        {
            _options = options;
        }

        public JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
        {
            // Your implementation logic here
            // This method should return a JsonTypeInfo object based on the given type and options
            // You can use reflection or any other approach to determine the type information
            return options.GetTypeInfo(type);
        }
    }
}
