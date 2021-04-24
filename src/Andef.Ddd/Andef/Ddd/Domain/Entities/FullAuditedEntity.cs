using System;
using System.Diagnostics.CodeAnalysis;

namespace Andef.Ddd.Domain.Entities
{
    [Serializable]
    public abstract class FullAuditedEntity<TKey, TUserKey> : AuditedEntity<TKey, TUserKey>, IFullAuditedObject<TUserKey>
    {
        [AllowNull]
        public virtual TUserKey DeleterId { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime? DeletionTime { get; set; }

        protected FullAuditedEntity()
        {

        }

        protected FullAuditedEntity(TKey id) : base(id)
        {

        }
    }

    [Serializable]
    public abstract class FullAuditedEntity<TKey> : AuditedEntity<TKey>, IFullAuditedObject
    {
        public virtual Guid? DeleterId { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime? DeletionTime { get; set; }

        protected FullAuditedEntity()
        {

        }

        protected FullAuditedEntity(TKey id) : base(id)
        {

        }
    }

    public abstract class FullAuditedEntity : AuditedEntity, IFullAuditedObject
    {
        public virtual Guid? DeleterId { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime? DeletionTime { get; set; }

    }
}
