using Hangfire;
using Hangfire.Common;
using Hangfire.Dashboard;
using Hangfire.SqlServer;
using Microsoft.Owin;
using MvcSample;
using Owin;
using System.Linq;

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

            JobFilter defaultRetryFilter = GlobalJobFilters.Filters.Where(j => j.Instance is AutomaticRetryAttribute).First();
            GlobalJobFilters.Filters.Remove(defaultRetryFilter.Instance);
        }
    }
}
