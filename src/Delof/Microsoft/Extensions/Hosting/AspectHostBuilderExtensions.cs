using AspectCore.Extensions.DependencyInjection;

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
