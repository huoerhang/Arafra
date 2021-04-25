using System;

namespace Delof.Ddd.Domain.Entities
{
    public interface IHasModifyTime
    {
        DateTime? LastModifyTime { get; set; }
    }
}
