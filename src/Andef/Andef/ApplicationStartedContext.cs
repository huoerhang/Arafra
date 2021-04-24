using System;

namespace Andef
{
    public class ApplicationStartedContext : ApplicationLifecycleContenxt
    {
        public ApplicationStartedContext(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
