using System.Reflection;
using Autofac;
using Autofac.Features.Variance;
using AutoMapper;
using Coravel;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StopAndGo.Api.Hubs.Shared.Services;
using StopAndGo.Api.Hubs.Shared.Services.Interfaces;
using StopAndGo.Api.Hubs;

namespace StopAndGo.Api.AppStartup
{
    public class Startup
    {
        [UsedImplicitly]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddSignalR();
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddJsonOptions(JsonOptionsConfigurator.Configure);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddQueue();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IGameState, GameState>();
            services.TryAddScoped<GameLogic>();
        }

        [UsedImplicitly]
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterSource(new ContravariantRegistrationSource());
        }

        [UsedImplicitly]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseCors(CorsPolicyConfigurator.Configure);
            app.UseSignalR(routes => { routes.MapHub<GameHub>("/api/game-hub"); });
            app.UseMvc(RouteConfigurator.Configure);
        }
    }
}
