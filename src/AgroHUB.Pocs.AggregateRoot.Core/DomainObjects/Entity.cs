namespace AggregateRoot.Core.DomainObjects
{
    public abstract class Entity
    {
        public long Id { get; protected set; }

        public abstract void Validate();
    }
}
