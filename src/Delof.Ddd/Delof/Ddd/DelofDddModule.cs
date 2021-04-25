using Delof.Ddd.Domain.Entities;
using Delof.DependencyInjection;
using Delof.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Delof.Ddd
{
    public class DelofDddModule : DelofModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddObjectAccessor(new ObjectAccessor<EntityEqualizerContainer>());
        }
    }
}
