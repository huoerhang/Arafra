using System;

namespace Delof
{
    public class ApplicationStartedContext : ApplicationLifecycleContenxt
    {
        public ApplicationStartedContext(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
