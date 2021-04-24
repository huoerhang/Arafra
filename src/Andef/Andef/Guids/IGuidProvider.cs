using System;

namespace Andef.Guids
{
    public interface IGuidProvider
    {
        IGuidGenerator GuidGenerator { get; }

        Guid Create();
    }
}
