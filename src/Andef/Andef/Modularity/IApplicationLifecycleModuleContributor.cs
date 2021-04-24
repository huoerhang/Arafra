namespace Andef.Modularity
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
