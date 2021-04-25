using Delof.Data.Filter;
using Delof.Ddd;
using Delof.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Delof.Data
{
    [Depends(typeof(DelofDddModule))]
    public class DelofDataModule : DelofModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            context.Services.AddSingleton(typeof(IDataFilter<>), typeof(DataFilter<>));
        }
    }
}