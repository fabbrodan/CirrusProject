using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Cosmos;
using cirrus_functions.Models;

namespace cirrus_functions
{
    public class SignIn
    {
        private readonly CosmosDbService _dbService;

        public SignIn(CosmosDbService CosmosDbService)
        {
            _dbService = CosmosDbService;
        }

        [FunctionName("SignIn")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Models.User User = JsonConvert.DeserializeObject<Models.User>(requestBody);

            return new OkObjectResult(true);
        }
    }
}
