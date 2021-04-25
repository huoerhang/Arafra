using System;

namespace Delof.Guids
{
    public interface IGuidProvider
    {
        IGuidGenerator GuidGenerator { get; }

        Guid Create();
    }
}
