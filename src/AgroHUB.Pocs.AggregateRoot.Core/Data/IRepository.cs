using AggregateRoot.Core.DomainObjects;
using System;

namespace AggregateRoot.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
