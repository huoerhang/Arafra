using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Delof.Modularity
{
    public class ServiceConfigurationContext
    {
        public ServiceConfigurationContext(IServiceCollection services)
        {
            Services = services;
            Items = new Dictionary<string, object>();
        }

        public IServiceCollection Services { get; }

        public IDictionary<string, object> Items { get; }

        public object this[string key]
        {
            get => Items.GetOrDefault(key);
            set => Items[key] = value;
        }
    }
}
