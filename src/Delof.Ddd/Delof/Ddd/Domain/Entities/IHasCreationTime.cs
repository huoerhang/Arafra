using System;

namespace Delof.Ddd.Domain.Entities
{
    public interface IHasCreationTime
    {
        DateTime CreationTime { get; }
    }
}
