using AggregateRoot.Core.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AggregateRoot.Data.Context
{
    public class AggregateRootContext : DbContext, IUnitOfWork
    {
        public AggregateRootContext(DbContextOptions<AggregateRootContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AggregateRootContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
