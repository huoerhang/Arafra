namespace Delof.Modularity
{
    public interface IApplicationLifecycleModuleContributor :
        IApplicationStartedModuleContributor,
        IApplicationPreInitializationModuleContributor,
        IApplicationInitializationModuleContributor,
        IApplicationPostInitializationModuleContributor,
        IApplicationStoppingModuleContributor
    {


    }
}
