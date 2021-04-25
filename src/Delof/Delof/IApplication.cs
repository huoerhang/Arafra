using System;
using Delof.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Delof
{
    public interface IApplication : IModuleContainer, IDisposable
    {
        Type EntryModuleType { get; }

        IServiceCollection Services { get; }

        IServiceProvider ServiceProvider { get; }

        void SetServiceProvider(IServiceProvider serviceProvider);

        void Started();

        void Initialize();

        void Stopping();
    }
}
