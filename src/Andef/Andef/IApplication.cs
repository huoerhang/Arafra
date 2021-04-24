using System;
using Andef.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Andef
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
