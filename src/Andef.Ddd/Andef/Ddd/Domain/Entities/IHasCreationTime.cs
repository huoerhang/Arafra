using System;

namespace Andef.Ddd.Domain.Entities
{
    public interface IHasCreationTime
    {
        DateTime CreationTime { get; }
    }
}
