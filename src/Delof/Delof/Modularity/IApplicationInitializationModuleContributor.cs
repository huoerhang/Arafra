using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delof.Modularity
{
    public interface IApplicationInitializationModuleContributor
    {
        void OnApplicationInitialization(ApplicationInitializationContext context);

    }
}
