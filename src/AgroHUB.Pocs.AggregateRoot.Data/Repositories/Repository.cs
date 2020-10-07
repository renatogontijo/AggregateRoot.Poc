using AggregateRoot.Core.Data;
using AggregateRoot.Core.DomainObjects;
using AggregateRoot.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AggregateRoot.Data
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IAggregateRoot
    {
        protected readonly AggregateRootContext Db;
        protected readonly DbSet<TEntity> DbSet;
        protected readonly IQueryable<TEntity> DbSetReadOnly;

        public Repository(AggregateRootContext context)
        {
            Db = context;
            DbSet = context.Set<TEntity>();
            DbSetReadOnly = context.Set<TEntity>().AsNoTracking();
        }

        public IUnitOfWork UnitOfWork => Db;

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
