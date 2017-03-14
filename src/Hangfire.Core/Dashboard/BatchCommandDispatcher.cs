// This file is part of Hangfire.
// Copyright © 2013-2014 Sergey Odinokov.
// 
// Hangfire is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as 
// published by the Free Software Foundation, either version 3 
// of the License, or any later version.
// 
// Hangfire is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public 
// License along with Hangfire. If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Hangfire.Annotations;

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

    internal class BatchCommandDispatcher : IDashboardDispatcher
    {
        private readonly Action<DashboardContext, string> _command;

        public BatchCommandDispatcher(Action<DashboardContext, string> command)
        {
            _command = command;
        }

#if NETFULL
        [Obsolete("Use the `BatchCommandDispatcher(Action<DashboardContext>, string)` instead. Will be removed in 2.0.0.")]
        public BatchCommandDispatcher(Action<RequestDispatcherContext, string> command)
        {
            _command = (context, jobId) => command(RequestDispatcherContext.FromDashboardContext(context), jobId);
        }
#endif

        public async Task Dispatch(DashboardContext context)
        {
            var jobIds = await context.Request.GetFormValuesAsync("jobs[]");
            if (jobIds.Count == 0)
            {
                context.Response.StatusCode = 422;
                return;
            }

            foreach (var jobId in jobIds)
            {
                _command(context, jobId);
            }

            context.Response.StatusCode = (int)HttpStatusCode.NoContent;
        }
    }
}
