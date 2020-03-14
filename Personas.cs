using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace COVID.Function
{
    public static class Personas
    {
        [FunctionName("RegistroPersonas")]
        public static IActionResult CrearCaso(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [CosmosDB("CoronaTime", "Persona", ConnectionStringSetting ="CosmosDB")]out dynamic persona,
            ILogger log)
        {
            var pkg = new COVID.Utility.PartitionKeyGenerator();
            string TipoDocumento = req.Query["TipoDocumento"];
            string DocumentoIdentidad = req.Query["DocumentoIdentidad"];
            string Nombres = req.Query["Nombres"];
            string Apellidos = req.Query["Apellidos"];
            int Edad = int.Parse(req.Query["Edad"]);
            string Sexo = req.Query["Sexo"];
            string Antecedentes = req.Query["Antecedentes"];
            string Nacionalidad = req.Query["Nacionalidad"];
            string Departamento = req.Query["Departamento"];
            string Ciudad = req.Query["Ciudad"];
            string Distrito = req.Query["Distrito"];
            string id = pkg.Create("Persona", "1", 100000000);

            persona = new { 
                TipoDocumento = TipoDocumento, 
                DocumentoIdentidad = DocumentoIdentidad,
                Nombres = Nombres,
                Apellidos = Apellidos,
                Edad = Edad,
                Sexo = Sexo,
                Antecedentes = Antecedentes,
                Nacionalidad = Nacionalidad,
                Departamento = Departamento,
                Ciudad = Ciudad,
                Distrito = Distrito,
                id = id};
            return (ActionResult)new OkObjectResult("created");
        } 
    }
}
