using System;
using System.Diagnostics.CodeAnalysis;

namespace Delof.Ddd.Domain.Entities
{
    [Serializable]
    public abstract class FullAuditedAggregateRoot<TKey,TUserKey>:AuditedAggregateRoot<TKey,TUserKey>,IFullAuditedObject<TUserKey>
    {
        [AllowNull]
        public virtual TUserKey DeleterId { get; set; }
        public virtual DateTime? DeletionTime { get; set; }
        public virtual bool IsDeleted { get; set; }

        protected FullAuditedAggregateRoot()
        {

        }

        protected FullAuditedAggregateRoot(TKey id) : base(id)
        {

        }
    }

    [Serializable]
    public abstract class FullAuditedAggregateRoot<TKey> : AuditedAggregateRoot<TKey>, IFullAuditedObject
    {
        public virtual Guid? DeleterId { get; set; }
        public virtual DateTime? DeletionTime { get; set; }
        public virtual bool IsDeleted { get; set; }

        protected FullAuditedAggregateRoot()
        {

        }

        protected FullAuditedAggregateRoot(TKey id) : base(id)
        {

        }
    }

    [Serializable]
    public abstract class FullAuditedAggregateRoot: AuditedAggregateRoot, IFullAuditedObject
    {
        public virtual Guid? DeleterId { get; set; }
        public virtual DateTime? DeletionTime { get; set; }
        public virtual bool IsDeleted { get; set; }
    }
}
