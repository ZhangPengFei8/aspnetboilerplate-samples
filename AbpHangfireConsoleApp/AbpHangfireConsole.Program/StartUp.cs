using Hangfire;
using Hangfire.Console;
using Hangfire.Dashboard;
using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartup(typeof(AbpHangfireConsoleApp.Startup))]

namespace AbpHangfireConsoleApp
{
    /// <summary>
    ///     Class to manage access to the hangfire dashboard.
    /// </summary>
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        /// <summary>
        ///     Determines whether a user may access the hangfire dashboard.
        /// </summary>
        /// <param name="aContext">Context we are accessing the dashboard in.</param>
        /// <returns>Returns TRUE should the user be allowed to access the dashboard.</returns>
        public bool Authorize(DashboardContext aContext)
        {
            // In case you need an OWIN context, use the next line, `OwinContext` class
            // is the part of the `Microsoft.Owin` package.
            OwinContext owinContext = new OwinContext(aContext.GetOwinEnvironment());

            return true;
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("default")
                .UseConsole(new ConsoleOptions
                {
                    BackgroundColor = "#0d3163",
                    TextColor = "#ffffff",
                    TimestampColor = "#00aad7"
                });

            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                AppPath = "/",
                Authorization = new[]
                {
                    new HangfireAuthorizationFilter()
                }
            });

            BackgroundJobServerOptions serverOptions = new BackgroundJobServerOptions
            {
                //"queue4", "queue5", "queue6", "queue7", "queue8", "queue9",
                //WorkerCount = Environment.ProcessorCount * 5,
                ServerName = String.Format("{0}.{1}", Environment.MachineName + "xxxx1", Guid.NewGuid().ToString()),

                // Queues = new[] { "queue1", "queue2","queue3", "queue4", "queue5", "queue6", "queue7", "queue8", "queue9", "default" }
                Queues = new[] { "queue1", "queue2", "queue3", "queue4", "queue5", "queue6", "queue7" }
            };
            BackgroundJobServerOptions serverOptions1 = new BackgroundJobServerOptions
            {
                ServerName = String.Format("{0}.{1}", Environment.MachineName + "xxxx2", Guid.NewGuid().ToString()),
                Queues = new[] { "queue8" }
            };
            BackgroundJobServerOptions serverOptions2 = new BackgroundJobServerOptions
            {
                ServerName = String.Format("{0}.{1}", Environment.MachineName + "xxxx3", Guid.NewGuid().ToString()),
                Queues = new[] {  "queue9"}
            };
            BackgroundJobServerOptions serverOptions3 = new BackgroundJobServerOptions
            {
                ServerName = String.Format("{0}.{1}", Environment.MachineName + "xxxx4", Guid.NewGuid().ToString()),
                Queues = new[] { "default" }
            };
            app.UseHangfireServer(serverOptions1);
            app.UseHangfireServer(serverOptions2);
            app.UseHangfireServer(serverOptions3);
            app.UseHangfireServer(serverOptions);
        }
    }
}