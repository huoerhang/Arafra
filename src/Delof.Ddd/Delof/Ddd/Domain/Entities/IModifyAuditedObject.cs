using System;

namespace Delof.Ddd.Domain.Entities
{
    public interface IModifyAuditedObject<TUserKey> : IHasModifyTime
    {
        TUserKey LastModifierId { get; set; }
    }

    public interface IModifyAuditedObject : IModifyAuditedObject<Guid?>
    {

    }
}
