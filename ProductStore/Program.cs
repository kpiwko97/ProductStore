using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ProductStore;

namespace knna
{
    public class Program
    {
        public static void Main(string[] args)
        {
           CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).ConfigureAppConfiguration(SetupConfiguration).
                UseDefaultServiceProvider(options => options.ValidateScopes = false)
                .UseStartup<Startup>();

        private static void SetupConfiguration(WebHostBuilderContext host, IConfigurationBuilder builder)
        {
            builder.Sources.Clear();
            builder.AddJsonFile("config.json").AddEnvironmentVariables();
        }
    }
}
