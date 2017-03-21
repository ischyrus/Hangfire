using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Hangfire.Dashboard
{
    internal class BatchAddCommandDispatcher : IDashboardDispatcher
    {
        private readonly Action<DashboardContext, string, string, string, string> _command;

        public BatchAddCommandDispatcher(Action<DashboardContext, string, string, string, string> command)
        {
            _command = command;
        }

        public async Task Dispatch(DashboardContext context)
        {
            string name = (await context.Request.GetFormValuesAsync("name")).FirstOrDefault();
            string url = (await context.Request.GetFormValuesAsync("url")).FirstOrDefault();
            string frequency = (await context.Request.GetFormValuesAsync("Frequency")).FirstOrDefault();
            string frequencyValue = (await context.Request.GetFormValuesAsync("FrequencyValue")).FirstOrDefault();

            _command(context, name, url, frequency, frequencyValue);

            context.Response.StatusCode = (int)HttpStatusCode.Redirect;
            context.Response.Redirect = "/hangfire/recurring";
        }
    }
}
