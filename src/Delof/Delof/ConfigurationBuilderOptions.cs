namespace Delof
{
    public class ConfigurationBuilderOptions
    {
        public string EnvironmentName { get; set; }

        public string BasePath { get; set; }

        public string EnviromentVariablesPrefix { get; set; }

        public string[] CommandLineArgs { get; set; }
    }
}
