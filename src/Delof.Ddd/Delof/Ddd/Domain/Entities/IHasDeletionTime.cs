using System;

namespace Delof.Ddd.Domain.Entities
{
    public interface IHasDeletionTime : ISoftDelete
    {
        DateTime? DeletionTime { get; set; }
    }
}
