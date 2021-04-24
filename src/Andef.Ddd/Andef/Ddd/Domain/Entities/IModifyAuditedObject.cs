using System;

namespace Andef.Ddd.Domain.Entities
{
    public interface IModifyAuditedObject<TUserKey> : IHasModifyTime
    {
        TUserKey LastModifierId { get; set; }
    }

    public interface IModifyAuditedObject : IModifyAuditedObject<Guid?>
    {

    }
}
