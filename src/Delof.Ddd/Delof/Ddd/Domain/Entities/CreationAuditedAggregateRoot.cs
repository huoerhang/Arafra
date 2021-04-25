using System;

namespace Delof.Ddd.Domain.Entities
{
    [Serializable]
    public abstract class CreationAuditedAggregateRoot<TKey, TUserKey> : AggregateRoot<TKey>, ICreationAuditedObject<TUserKey>
    {
        public virtual TUserKey CreatorId { get; protected set; }

        public DateTime CreationTime { get; protected set; }

#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        protected CreationAuditedAggregateRoot()
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        {

        }

#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        protected CreationAuditedAggregateRoot(TKey id) : base(id)
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        {

        }
    }

    [Serializable]
    public abstract class CreationAuditedAggregateRoot<TKey> : AggregateRoot<TKey>, ICreationAuditedObject
    {
        public virtual Guid CreatorId { get; protected set; }

        public DateTime CreationTime { get; protected set; }

        protected CreationAuditedAggregateRoot()
        {

        }

        protected CreationAuditedAggregateRoot(TKey id) : base(id)
        {

        }
    }

    [Serializable]
    public abstract class CreationAuditedAggregateRoot : AggregateRoot, ICreationAuditedObject
    {
        public virtual Guid CreatorId { get; protected set; }

        public DateTime CreationTime { get; protected set; }
    }

}
