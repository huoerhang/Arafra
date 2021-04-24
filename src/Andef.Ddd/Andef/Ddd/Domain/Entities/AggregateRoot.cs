using System;

namespace Andef.Ddd.Domain.Entities
{
    [Serializable]
    public abstract class AggregateRoot : Entity, IAggregateRoot
    {

    }

    [Serializable]
    public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot<TKey>
    {
        public AggregateRoot()
        {

        }

        public AggregateRoot(TKey id) 
            : base(id)
        {

        }
    }
}
