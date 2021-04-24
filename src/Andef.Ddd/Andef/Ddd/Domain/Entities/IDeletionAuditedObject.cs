using System;

namespace Andef.Ddd.Domain.Entities
{
    public interface IDeletionAuditedObject<TUserKey> : IHasDeletionTime
    {
        TUserKey DeleterId { get; set; }
    }

    public interface IDeletionAuditedObject : IDeletionAuditedObject<Guid?>
    {

    }
}
