using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(cirrus_functions.Startup))]

namespace cirrus_functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<CosmosDbService>((s) => { return new CosmosDbService(); });
            builder.Services.AddSingleton<PasswordHasher>((s) => { return new PasswordHasher(); });
        }
    }
}
