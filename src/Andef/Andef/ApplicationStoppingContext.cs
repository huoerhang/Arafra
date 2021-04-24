using System;

namespace Andef
{
    public class ApplicationStoppingContext : ApplicationLifecycleContenxt
    {
        public ApplicationStoppingContext(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
