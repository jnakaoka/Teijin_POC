using api_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using POC_Teijin.Repository;
using System.Data.SqlClient;
using System.Text.Json;

namespace api_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensoresController : ControllerBase
    {   
        private readonly ILogger<SensoresController> _logger;
        private readonly IConfiguration _configuration;

        public SensoresController(ILogger<SensoresController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet(Name = "get-metricas")]
        public List<Sensores> Get()
        {
            var connectionString = _configuration.GetConnectionString("TeijinDB");
            var repository = new SensoresRepository(connectionString);
            

            var dataFromDBdb = repository.GetDataAsync();
            return dataFromDBdb.Result.ToList() ?? new List<Sensores>();
        }

        [HttpPost]
        [Route("recebe-dados")]
        public IActionResult ReceiveSensorData([FromBody] DadosJson dados)
        {
            // Serialize the DadosJson object to JSON
            var json = JsonSerializer.Serialize(dados);

            // Process the JSON data
            Console.WriteLine(json);

            var sensoresModel = new Sensores {Id = dados.Id, Nome = dados.Nome, Estado = dados.Estado };

            var connectionString = _configuration.GetConnectionString("TeijinDB");
            var repository = new SensoresRepository(connectionString);

            repository.SaveDataAsync(sensoresModel);
            var dataFromDBdb = repository.GetDataAsync();

            return Ok(dataFromDBdb);
        }

    }
}
