using System;

namespace Andef
{
    public class ApplicationInitializationContext: ApplicationLifecycleContenxt
    {
        public ApplicationInitializationContext(IServiceProvider serviceProvider)
            :base(serviceProvider)
        {
        }
    }
}
