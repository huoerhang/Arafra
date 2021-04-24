using System;
using System.Diagnostics.CodeAnalysis;

namespace Andef.Ddd.Domain.Entities
{
    [Serializable]
    public abstract class AuditedAggregateRoot<TKey, TUserKey> : CreationAuditedAggregateRoot<TKey, TUserKey>, IAuditedObject<TUserKey>
    {
        [AllowNull]
        public virtual TUserKey LastModifierId { get; set; }
        public virtual DateTime? LastModifyTime { get; set; }

        protected AuditedAggregateRoot()
        {

        }

        protected AuditedAggregateRoot(TKey id) : base(id)
        {

        }
    }

    [Serializable]
    public abstract class AuditedAggregateRoot<TKey> : CreationAuditedAggregateRoot<TKey>, IAuditedObject
    {
        public virtual Guid? LastModifierId { get; set; }
        public virtual DateTime? LastModifyTime { get; set; }

        protected AuditedAggregateRoot()
        {

        }

        protected AuditedAggregateRoot(TKey id) : base(id)
        {

        }
    }

    [Serializable]
    public abstract class AuditedAggregateRoot: CreationAuditedAggregateRoot, IAuditedObject
    {
        public virtual Guid? LastModifierId { get; set; }
        public virtual DateTime? LastModifyTime { get; set; }
    }
}
