using Andef.Modularity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Andef.AspNetCore
{
    public class AndefAspNetCoreModule : AndefModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            AddAspNetCoreServices(context.Services);
            context.Services.AddObjectAccessor<IApplicationBuilder>();
        }

        private static void AddAspNetCoreServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
        }
    }
}
