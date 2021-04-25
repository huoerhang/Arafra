namespace Delof.Ddd.Domain.Entities
{
    public interface IFullAuditedObject<TUserKey> : IAuditedObject<TUserKey>, IDeletionAuditedObject<TUserKey>
    {
    }

    public interface IFullAuditedObject : IAuditedObject, IDeletionAuditedObject
    {

    }
}
