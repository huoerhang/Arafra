using Andef.Data.Filter;
using Andef.Ddd;
using Andef.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Andef.Data
{
    [Depends(typeof(AndefDddModule))]
    public class AndefDataModule : AndefModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            context.Services.AddSingleton(typeof(IDataFilter<>), typeof(DataFilter<>));
        }
    }
}