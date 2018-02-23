using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using ZCStudio.FigureBed.Configuration;

namespace ZCStudio.FigureBed
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostConfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Path.Combine("Config", "hosting.json"), optional: false, reloadOnChange: true)
                .AddJsonFile(Path.Combine("Config", $"hosting.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json"), optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            var host = new WebHostBuilder()
                //.UseEnvironment("Development")
                //.UseEnvironment("IsProduction")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseKestrel()
                .UseConfiguration(hostConfig)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    config
                        .AddJsonFile(Path.Combine("Config", "appsettings.json"), optional: false, reloadOnChange: true)
                        .AddJsonFile(Path.Combine("Config", $"appsettings.{env.EnvironmentName}.json"), optional: true, reloadOnChange: true)
                        .AddJsonFile(Path.Combine("Config", "server.json"), optional: false, reloadOnChange: true)
                        .AddJsonFile(Path.Combine("Config", $"server.{env.EnvironmentName}.json"), optional: true, reloadOnChange: true);
                })
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}