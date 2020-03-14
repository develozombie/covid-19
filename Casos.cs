using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using COVID.Entity;

namespace COVID.Function
{
    public static class Casos
    {
        [FunctionName("RegistroCasos")]
        public static IActionResult RegistroCasos(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [CosmosDB("CoronaTime", "Caso", ConnectionStringSetting ="CosmosDB")]out dynamic caso,
            ILogger log)
        {
            var pkg = new COVID.Utility.PartitionKeyGenerator();
            string id = pkg.Create("Caso", "1", 1000000);
            string Estado = req.Query["Estado"];
            string Contagio = req.Query["Contagio"];
            Persona Persona = new Persona
            {
                TipoDocumento = req.Query["TipoDocumento"],
                DocumentoIdentidad = req.Query["DocumentoIdentidad"],
                Nombres = req.Query["Nombres"],
                Apellidos = req.Query["Apellidos"],
                Edad = req.Query["Edad"],
                Sexo = req.Query["Sexo"],
                Antecedentes = req.Query["Antecedentes"],
                Nacionalidad = req.Query["Nacionalidad"],
                Departamento = req.Query["Departamento"],
                Ciudad = req.Query["Ciudad"],
                Distrito = req.Query["Distrito"],
                id = pkg.Create("Persona", "1", 100000000)
            };
            log.LogInformation(req.Query["Departamento"]);
            string Pais = req.Query["Pais"];
            caso = new 
            { 
                id = id, 
                Estado = Estado,
                Contagio = Contagio,
                Persona = Persona,
                Pais = Pais
             };
            return (ActionResult)new OkObjectResult("created");
        } 
    }
}
