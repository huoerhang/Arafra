using Andef.Ddd.Domain.Entities;
using Andef.DependencyInjection;
using Andef.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Andef.Ddd
{
    public class AndefDddModule : AndefModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddObjectAccessor(new ObjectAccessor<EntityEqualizerContainer>());
        }
    }
}
