using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andef.Modularity
{
    public interface IAndefModule
    {
        void PreConfigureServices(ServiceConfigurationContext context);

        void ConfigureServices(ServiceConfigurationContext context);

        void PostConfigureServices(ServiceConfigurationContext context);
    }
}
