using System;

namespace Delof
{
    public class ApplicationInitializationContext: ApplicationLifecycleContenxt
    {
        public ApplicationInitializationContext(IServiceProvider serviceProvider)
            :base(serviceProvider)
        {
        }
    }
}
