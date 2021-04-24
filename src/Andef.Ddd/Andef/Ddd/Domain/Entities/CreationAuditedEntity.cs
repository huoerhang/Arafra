using System;

namespace Andef.Ddd.Domain.Entities
{
    [Serializable]
    public abstract class CreationAuditedEntity<TKey, TUserKey> : Entity<TKey>, ICreationAuditedObject<TUserKey>
    {
        
        public virtual TUserKey CreatorId { get; protected set; }

        public virtual DateTime CreationTime { get; protected set; }

#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        protected CreationAuditedEntity()
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        {

        }

#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        protected CreationAuditedEntity(TKey id) : base(id)
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        {

        }
    }

    [Serializable]
    public abstract class CreationAuditedEntity<TKey> : Entity<TKey>, ICreationAuditedObject
    {
        public virtual Guid CreatorId { get; protected set; }

        public virtual DateTime CreationTime { get; protected set; }

        protected CreationAuditedEntity()
        {

        }

        protected CreationAuditedEntity(TKey id) : base(id)
        {

        }
    }

    [Serializable]
    public abstract class CreationAuditedEntity : Entity, ICreationAuditedObject
    {
        public virtual Guid CreatorId { get; protected set; }

        public virtual DateTime CreationTime { get; protected set; }
    }
}
