using AggregateRoot.Core.Data;
using AggregateRoot.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AggregateRoot.Domain.Repositories
{
    public interface IFarmAreaRepository : IRepository<FarmArea>
    {
        Task<IEnumerable<FarmArea>> GetAll();

        Task<FarmArea> GetById(long id);

        Task<FarmArea> GetByName(string name);

        void Add(FarmArea farmArea);

        void Update(FarmArea farmArea);
    }
}
