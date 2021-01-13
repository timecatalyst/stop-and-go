using System.Data.Common;
using System.Threading.Tasks;

namespace Nymbus.Domain.Sql.Interfaces
{
    public interface ISqlCommand
    {
        Task Execute(DbConnection connection, DbTransaction transaction);
    }

    public interface ISqlCommand<TReturn>
    {
        Task<TReturn> Execute(DbConnection connection, DbTransaction transaction);
    }
}
