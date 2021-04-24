namespace Andef.Modularity
{
    public interface IModuleManager
    {
        void ModulesStarted(ApplicationStartedContext context);

        void InitializeModules(ApplicationInitializationContext context);

        void ModulesStopping(ApplicationStoppingContext context);
    }
}
