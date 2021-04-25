namespace Delof.Modularity
{
    public interface IApplicationStoppingModuleContributor
    {
        void OnApplicationShutdown(ApplicationStoppingContext context);
    }
}
