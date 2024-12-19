using System.Text.Json.Serialization;

namespace POC_Teijin.Models
{
    [JsonSerializable(typeof(DadosJson))]
    public class DadosJson
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("nome")]
        public string Nome { get; set; }
        [JsonPropertyName("estado")]
        public int Estado { get; set; }
    }
}
