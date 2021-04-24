using System;

namespace Andef
{
    public sealed class NullableDisposable : IDisposable
    {
        public static NullableDisposable Instance { get; } = new NullableDisposable();

        private NullableDisposable()
        {

        }

        public void Dispose()
        {

        }
    }
}
