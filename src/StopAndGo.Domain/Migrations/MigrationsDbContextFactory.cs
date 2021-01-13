using System.IO;
using System.Reflection;
using Nymbus.Domain.Entities;
using Nymbus.Domain.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

namespace Nymbus.Domain.Migrations
{
    public class MigrationsDbContextFactory : IDesignTimeDbContextFactory<ApiDbContext>
    {
        public ApiDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "Migrations"))
                                .AddJsonFile("migrationsettings.json")
                                .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
                                .AddEnvironmentVariables()
                                .Build();

            var connectionString = configuration.GetConnectionString("ApiDbContext");
            var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>()
                .UseSqlServer(string.IsNullOrEmpty(connectionString) ? "Data Source=fake-source" : connectionString);
            
            return new ApiDbContext(optionsBuilder.Options);
        }
    }
}
