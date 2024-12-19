﻿using Microsoft.AspNetCore.Mvc;
using POC_Teijin.Models;
using POC_Teijin.Repository;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace POC_Teijin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorComunicationController : Controller
    {

        private readonly MyDbContext _context;

        public SensorComunicationController(MyDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("recebe-dados")]
        public IActionResult ReceiveSensorData()
        {
            // Serialize the DadosJson object to JSON
            //var json = JsonSerializer.Serialize(dados);

            //// Process the JSON data
            //Console.WriteLine(json);

            var sensoresModel = new Sensores { Name = "John Doe" };

            var db = new SensoresRepository("User ID=postgres;Password=admin_123;Server=localhost,5432;Database=Teijin_POC;");
            //Server=localhost;Database=Teijin_POC;UID=postgres;Password=admin_123

            db.SaveDataAsync(sensoresModel);
            db.GetDataAsync();

            return Ok("Dados recebidos com sucesso");
        }

        [HttpGet]
        [Route("recebe-metricas")]
        public IActionResult GetMetrics()
        {
            var metrics = new List<Sensores>
            {
                new Sensores { Id = 1, Name = "John Doe" },
            };
            return Ok(metrics);
        }

        //[HttpPost]
        //[Route("recebe-dados")]
        //public IActionResult ReceiveSensorData([FromBody] DadosJson dados)
        //{
        //    // Serialize the DadosJson object to JSON
        //    //var json = JsonSerializer.Serialize(dados);

        //    //// Process the JSON data
        //    //Console.WriteLine(json);

        //    return Ok("Dados recebidos com sucesso");
        //}
    }
}