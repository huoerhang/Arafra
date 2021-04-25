namespace Delof.Ddd.Domain.Entities
{
    public interface IAuditedObject<TUserKey> : ICreationAuditedObject<TUserKey>, IModifyAuditedObject<TUserKey>
    {
    }

    public interface IAuditedObject : ICreationAuditedObject, IModifyAuditedObject
    {

    }
}
