using System;
using System.Diagnostics.CodeAnalysis;

namespace Delof.Ddd.Domain.Entities
{
    [Serializable]
    public abstract class AuditedEntity<TKey, TUserKey> : CreationAuditedEntity<TKey, TUserKey>, IAuditedObject<TUserKey>
    {
        [AllowNull]
        public virtual TUserKey LastModifierId { get; set; }

        public virtual DateTime? LastModifyTime { get; set; }

        public AuditedEntity()
        {

        }
        public AuditedEntity(TKey id) : base(id)
        {

        }
    }

    [Serializable]
    public abstract class AuditedEntity<TKey> : CreationAuditedEntity<TKey>, IAuditedObject
    {
        public virtual Guid? LastModifierId { get; set; }
        public virtual DateTime? LastModifyTime { get; set; }

        public AuditedEntity()
        {

        }
        public AuditedEntity(TKey id) : base(id)
        {

        }
    }

    [Serializable]
    public abstract class AuditedEntity : CreationAuditedEntity, IAuditedObject
    {
        public virtual Guid? LastModifierId { get; set; }
        public virtual DateTime? LastModifyTime { get; set; }
    }
}
