using System;

namespace Delof
{
    public class ApplicationStoppingContext : ApplicationLifecycleContenxt
    {
        public ApplicationStoppingContext(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
