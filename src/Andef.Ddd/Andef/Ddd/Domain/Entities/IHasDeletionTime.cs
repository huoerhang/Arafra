using System;

namespace Andef.Ddd.Domain.Entities
{
    public interface IHasDeletionTime : ISoftDelete
    {
        DateTime? DeletionTime { get; set; }
    }
}
