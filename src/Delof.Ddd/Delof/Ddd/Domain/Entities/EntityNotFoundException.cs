using System;

namespace Delof.Ddd.Domain.Entities
{
    public class EntityNotFoundException : DelofException
    {
        public Type EntityType { get; set; }

        public object Id { get; set; }
        public EntityNotFoundException()
        {

        }

        public EntityNotFoundException(Type entityType)
            : this(entityType, null)
        {

        }

        public EntityNotFoundException(Type entityType, object id)
            : this(entityType, id, null)
        {

        }

        public EntityNotFoundException(Type entityType, object id, Exception innerException)
            : base(id == null ? $"No such an entity {entityType.AssemblyQualifiedName}" : $"Id {id} not found entity")
        {
            EntityType = entityType;
            Id = id;
        }

        public EntityNotFoundException(string message) : base(message)
        {

        }

        public EntityNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
