using Delof.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delof.Ddd.Domain.Entities
{
    public static class ServiceConfigurationContextExtensions
    {
        public static ServiceConfigurationContext RegisterEntityEqualizer(this ServiceConfigurationContext context , IEntityEqualizer entityEqualizer)
        {
            if (entityEqualizer != null)
            {
                EntityEqualizerContainer.Instance.Add(entityEqualizer);
            }

            return context;
        }
    }
}
