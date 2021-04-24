namespace Andef.Modularity
{
    public interface IApplicationStoppingModuleContributor
    {
        void OnApplicationShutdown(ApplicationStoppingContext context);
    }
}
