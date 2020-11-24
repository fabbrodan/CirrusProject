using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.Cosmos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using cirrus_functions.Models;

namespace cirrus_functions
{
    public class Register
    {
        private readonly CosmosDbService CosmosService;
        private readonly PasswordHasher Hasher;
        public Register(CosmosDbService DbService)
        {
            CosmosService = DbService;
            Hasher = new PasswordHasher();
        }

        [FunctionName("Register")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string body = await new StreamReader(req.Body).ReadToEndAsync();
            Models.User newUser = JsonConvert.DeserializeObject<Models.User>(body);

            newUser.PasswordSalt = Hasher.RandomSalt;
            newUser.Password = Hasher.GenerateSaltedHash(newUser.Password);

            ItemResponse<Models.User> response = await CosmosService.CosmosContainer.CreateItemAsync(newUser);

            return new OkObjectResult(response.Resource);
        }
    }
}
