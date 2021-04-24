using Andef.DependencyInjection;
using Andef.Ddd.Domain.Entities;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AndefDddDomainServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityEqualizer(this IServiceCollection services, IEntityEqualizer entityEqualizer)
        {
            GetOrCreateEntityEqualizerContainer(services).Add(entityEqualizer);

            return services;
        }

        private static EntityEqualizerContainer GetOrCreateEntityEqualizerContainer(IServiceCollection services)
        {
            var container = services.GetFirstInstanceOrNull<ObjectAccessor<EntityEqualizerContainer>>()?.Value;

            if (container == null)
            {
                services.AddObjectAccessor(new ObjectAccessor<EntityEqualizerContainer>(EntityEqualizerContainer.Instance));
            }

            return container;
        }
    }
}
