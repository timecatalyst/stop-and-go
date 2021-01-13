using System.Data.Common;
using System.Data.SqlClient;
using Autofac;
using Nymbus.Domain.Entities;
using Nymbus.Domain.Sql;
using Nymbus.Domain.Sql.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Nymbus.Domain.IoC
{
    public class SqlModule : Module
    {
        public const string ConnectionStringKey = "ConnectionString";

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctxt => ctxt.Resolve<IConfiguration>().GetConnectionString("ApiDbContext"))
                   .Keyed<string>(ConnectionStringKey);

            builder.Register(ctxt => new SqlConnection(ctxt.ResolveKeyed<string>(ConnectionStringKey)))
                   .As<DbConnection>()
                   .As<SqlConnection>();

            builder.Register(ctxt => ctxt.Resolve<ApiDbContext>().Database.CreateExecutionStrategy());

            builder.RegisterType<SqlExecutor>().As<ISqlExecutor>();
        }
    }
}
