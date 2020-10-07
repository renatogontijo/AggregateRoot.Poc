using System.Threading.Tasks;

namespace AggregateRoot.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
