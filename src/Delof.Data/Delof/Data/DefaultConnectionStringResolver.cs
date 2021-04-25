using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Delof.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Delof.Data
{
    [Dependency]
    public class DefaultConnectionStringResolver : IConnectionStringResolver
    {
        protected DbConnectionOptions Options { get; }

        public DefaultConnectionStringResolver(IOptionsSnapshot<DbConnectionOptions> options)
        {
            options.CheckNotNull(nameof(options));

            Options = options.Value;
        }

        public virtual Task<string> ResolveAsync(string connectionStringName = null)
        {
            string name = null;

            if (!connectionStringName.IsNullOrEmpty())
            {
                name = Options.ConnectionStrings.GetOrDefault(connectionStringName);
            }

            if (name.IsNullOrEmpty())
            {
                name = Options.ConnectionStrings.Default;
            }

            return Task.FromResult(name);
        }
    }
}
