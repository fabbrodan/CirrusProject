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
        private readonly CosmosDbService CosmosService = new CosmosDbService();

        [FunctionName("SignIn")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            PartitionKey key = new PartitionKey("/user/email");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Models.User User = JsonConvert.DeserializeObject<Models.User>(requestBody);
            Models.User dbUser = CosmosService.CosmosContainer.ReadItemAsync<Models.User>(User.Email, key, null).Result;
            if (dbUser != null)
            {
                return new OkObjectResult(dbUser);
            }

            return new NoContentResult();
        }
    }
}
