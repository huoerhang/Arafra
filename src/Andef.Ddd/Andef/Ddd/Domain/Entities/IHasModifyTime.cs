using System;

namespace Andef.Ddd.Domain.Entities
{
    public interface IHasModifyTime
    {
        DateTime? LastModifyTime { get; set; }
    }
}
