using AspectCore.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.Hosting
{
    public static class AspectHostBuilderExtensions
    {
        public static IHostBuilder UseAspectCore(this IHostBuilder hostBuilder)
        {
            var serviceProviderFactory = new ServiceContextProviderFactory();

            return hostBuilder.UseServiceProviderFactory(serviceProviderFactory);
        }
    }
}
