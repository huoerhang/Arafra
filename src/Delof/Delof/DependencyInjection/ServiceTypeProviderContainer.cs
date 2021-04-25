using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delof.DependencyInjection
{
    public class ServiceTypeProviderContainer : List<IServiceTypeProvider>
    {
        internal ServiceTypeProviderContainer()
        {

        }
    }
}
