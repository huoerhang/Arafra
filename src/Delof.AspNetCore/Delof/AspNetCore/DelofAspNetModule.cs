using Delof.Modularity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Delof.AspNetCore
{
    public class DelofAspNetModule : DelofModule
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
