using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Andef.Ddd.Domain.Entities
{
    [Serializable]
    public abstract class Entity : IEntity
    {
        public abstract object[] GetKeys();

        public bool EntityEquals(IEntity other)
        {
            return other.EntityEquals(this);
        }

        public override string ToString()
        {
            return $"[Entity:{GetType().Name}] Keys={GetKeys().JoinAsString(", ")}";
        }
    }

    [Serializable]
    public abstract class Entity<TKey> : Entity, IEntity<TKey>
    {
        [AllowNull]
        public virtual TKey Id { get; protected set; }

        protected Entity()
        {

        }

        protected Entity(TKey id)
        {
            Id = id;
        }

        public override object[] GetKeys()
        {
            if (Id == null)
            {
                return new object[0];
            }

            return new object[] { Id };
        }

        public override string ToString()
        {
            return $"[Entity:{GetType().Name}] Id={Id}";
        }
    }
}
