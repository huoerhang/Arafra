using System;

namespace Andef.Ddd.Domain.Entities
{
    public interface ICreationAuditedObject<TUserKey> : IHasCreationTime
    {
        TUserKey CreatorId { get; }
    }

    public interface ICreationAuditedObject : ICreationAuditedObject<Guid>
    {

    }
}
