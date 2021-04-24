namespace Andef.Ddd.Domain.Entities
{
    public interface IAggregateRoot : IEntity
    {
    }

    public interface IAggregateRoot<TKey> : IAggregateRoot, IEntity<TKey>
    {

    }
}
