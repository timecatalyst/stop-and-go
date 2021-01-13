using System;
using System.IO;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using StopAndGo.Api.AppStartup;
using Serilog;

namespace StopAndGo.Api
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                Log.Information("Starting web host");

                CreateWebHostBuilder(args).Build().Run();

                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] commandLineArgs) =>
            new WebHostBuilder()
                .UseKestrel(options => options.ListenAnyIP(5000))
                .ConfigureServices(services => services.AddAutofac())
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration(
                    (hostingContext, configurationBuilder) =>
                        AppConfigurationConfigurator.Configure(hostingContext, configurationBuilder, commandLineArgs))
                .UseIISIntegration()
                .UseDefaultServiceProvider((context, options) => options.ValidateScopes = context.HostingEnvironment.IsDevelopment())
                .UseStartup<Startup>()
                .UseSerilog();
    }
}
