using AggregateRoot.Data.Context;
using AggregateRoot.Domain.Entities;
using AggregateRoot.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AggregateRoot.Data.Repositories
{
    public class FarmAreaRepository : Repository<FarmArea>, IFarmAreaRepository
    {
        public FarmAreaRepository(AggregateRootContext context) :
            base(context)
        {
        }

        public void Add(FarmArea farmArea)
        {
            DbSet.Add(farmArea);
        }

        public async Task<IEnumerable<FarmArea>> GetAll()
        {
            return await DbSetReadOnly.ToListAsync();
        }

        public async Task<FarmArea> GetById(long id)
        {
            return await DbSet
                .Include(i => i.FarmAreaCoordinates)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<FarmArea> GetByName(string name)
        {
            var lowerName = name?.ToLower();
            return await DbSet
                .Include(i => i.FarmAreaCoordinates)
                .FirstOrDefaultAsync(i => i.Name.ToLower().Equals(lowerName));
        }

        public void Update(FarmArea farmArea)
        {
            DbSet.Update(farmArea);
        }
    }
}
