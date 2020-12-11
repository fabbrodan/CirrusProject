using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CirrusApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services
                .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
                .AddSingleton<FileContainer>()
                .AddOidcAuthentication(options =>
                {
                    options.ProviderOptions.Authority = "https://accounts.google.com/";
                    options.ProviderOptions.RedirectUri = "https://localhost:5001/authentication/login-callback";
                    options.ProviderOptions.PostLogoutRedirectUri = "https://localhost:5001/authentication/logout-callback";
                    options.ProviderOptions.ClientId = "467519146557-2tiael1k63lbh1luvgnjf21ccvtncicp.apps.googleusercontent.com";
                    options.ProviderOptions.ResponseType = "id_token";
                });

            await builder.Build().RunAsync();
        }
    }
}
