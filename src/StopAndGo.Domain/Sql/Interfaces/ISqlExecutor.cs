using System.Threading.Tasks;

namespace Nymbus.Domain.Sql.Interfaces
{
    public interface ISqlExecutor
    {
        Task Execute(ISqlCommand sqlCommand, SqlExecutionContext context = null);
        Task<TReturn> Execute<TReturn>(ISqlCommand<TReturn> sqlCommand, SqlExecutionContext context = null);
        Task<TReturn> Execute<TReturn>(ISqlQuery<TReturn> sqlQuery, SqlExecutionContext context = null);
    }
}
