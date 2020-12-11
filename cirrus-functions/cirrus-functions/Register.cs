using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using cirrus_functions.Models;
using Microsoft.Azure.Cosmos;

namespace cirrus_functions
{
    public class Register
    {
        private readonly CosmosDbService CosmosService = new CosmosDbService();
        private readonly PasswordHasher Hasher = new PasswordHasher();

        [FunctionName("Register")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Register function called");

            string body = await new StreamReader(req.Body).ReadToEndAsync();
            Models.User newUser = JsonConvert.DeserializeObject<Models.User>(body);
            newUser.id = newUser.Email;
            newUser.PasswordSalt = Hasher.RandomSalt;
            newUser.Password = Hasher.GenerateSaltedHash(newUser.Password);
            newUser.UserRegistered = DateTime.UtcNow;

            ItemResponse<Models.User> response = await CosmosService.CosmosContainer.CreateItemAsync(newUser);

            return new OkObjectResult(response.Resource);
        }
    }
}
