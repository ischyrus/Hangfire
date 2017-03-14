using Hangfire;
using Hangfire.Dashboard;
using Hangfire.SqlServer;
using Microsoft.Owin;
using MvcSample;
using Owin;
using System;

[assembly: OwinStartup(typeof(Startup))]

namespace MvcSample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
                .UseSqlServerStorage(@"Server=(local);Database=Hangfire.Sample;Trusted_Connection=True;")
                // .UseMsmqQueues(@".\Private$\hangfire{0}", "default", "critical")
                .UseDashboardMetric(SqlServerStorage.ActiveConnections)
                .UseDashboardMetric(SqlServerStorage.TotalConnections)
                .UseDashboardMetric(DashboardMetrics.FailedCount);
            
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
