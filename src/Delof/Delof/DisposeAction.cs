using System;

namespace Delof
{
    public class DisposeAction : IDisposable
    {
        private readonly Action _action;

        public DisposeAction(Action action)
        {
            action.CheckNotNull(nameof(action));
            _action = action;
        }

        public void Dispose()
        {
            _action();
        }
    }
}
