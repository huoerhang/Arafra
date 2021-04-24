using Andef;
using Andef.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static void InitializeApplication(this IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices;
            app.ApplicationServices.GetRequiredService<ObjectAccessor<IApplicationBuilder>>().Value = app;
            var application = serviceProvider.GetRequiredService<IApplication>();
            application.SetServiceProvider(serviceProvider);
            var applicationLifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();

            applicationLifetime.ApplicationStarted.Register(() =>
            {
                application.Started();
            });

            applicationLifetime.ApplicationStopping.Register(() =>
            {
                application.Stopping();
            });
            applicationLifetime.ApplicationStopped.Register(() =>
            {
                application.Dispose();
            });

            application.Initialize();
        }
    }
}
