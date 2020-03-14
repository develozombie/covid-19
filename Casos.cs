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
    public static class Casos
    {
        [FunctionName("RegistroCaso")]
        public static IActionResult CrearCaso(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [CosmosDB("CoronaTime", "Caso", ConnectionStringSetting ="CosmosDB")]out dynamic caso,
            ILogger log)
        {
            var pkg = new COVID.Utility.PartitionKeyGenerator();
            string Nombre = req.Query["Nombre"];
            string PrecioReferencial = req.Query["PrecioReferencial"];
            string id = pkg.Create("Caso", "1", 100000);

            producto = new { Nombre = Nombre, PrecioReferencial = PrecioReferencial, id = id};
            return (ActionResult)new OkObjectResult("created");
        } 
    }
}
