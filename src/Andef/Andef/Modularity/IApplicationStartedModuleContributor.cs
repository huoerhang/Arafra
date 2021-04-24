namespace Andef.Modularity
{
    public interface IApplicationStartedModuleContributor
    {
        void OnApplicationStarted(ApplicationStartedContext context);
    }
}
