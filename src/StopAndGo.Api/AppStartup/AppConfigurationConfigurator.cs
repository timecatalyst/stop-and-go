using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace StopAndGo.Api.AppStartup
{
    public static class AppConfigurationConfigurator
    {
        public static void Configure(WebHostBuilderContext hostingContext, IConfigurationBuilder configBuilder, string[] commandLineArgs)
        {
            configBuilder.AddJsonFile("appsettings.json", true, true);
            configBuilder.AddEnvironmentVariables();

            if (commandLineArgs == null) return;

            configBuilder.AddCommandLine(commandLineArgs);
        }
    }
}
