﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hangfire.Dashboard.Pages
{
    
    #line 2 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
    using System;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    using System.Linq;
    using System.Text;
    
    #line 4 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
    using Hangfire.Dashboard;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
    using Hangfire.Dashboard.Pages;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
    using Hangfire.Dashboard.Resources;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
    using Hangfire.Storage;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class RecurringJobsPage : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\n");









            
            #line 9 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
  
    Layout = new LayoutPage(Strings.RecurringJobsPage_Title);
    List<RecurringJobDto> recurringJobs;

    int from, perPage;

    int.TryParse(Query("from"), out from);
    int.TryParse(Query("count"), out perPage);

    Pager pager = null;

    using (var connection = Storage.GetConnection())
    {
        var storageConnection = connection as JobStorageConnection;
        if (storageConnection != null)
        {
            pager = new Pager(from, perPage, storageConnection.GetRecurringJobCount());
	        recurringJobs = storageConnection.GetRecurringJobs(pager.FromRecord, pager.FromRecord + pager.RecordsPerPage - 1);
        }
        else
        {
            recurringJobs = connection.GetRecurringJobs();
        }
    }


            
            #line default
            #line hidden
WriteLiteral("\n<div class=\"row\">\n    <div class=\"col-md-12\">\n        <h1 class=\"page-header\">");


            
            #line 37 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                           Write(Strings.RecurringJobsPage_Title);

            
            #line default
            #line hidden
WriteLiteral(@"</h1>

        <div style=""margin-bottom: 12px;"">
            <form method=""post"" class=""form-inline"" action=""/hangfire/recurring/add"">
                <input type=""hidden"" name=""job[]"" value=""12"" />
                <input type=""text"" class=""form-control"" name=""Name"" style=""width: 15%;"" placeholder=""Name"" />
                <input type=""text"" class=""form-control"" name=""Url"" style=""width: 55%;"" placeholder=""Url"" />
                <input type=""text"" class=""form-control"" name=""FrequencyValue"" placeholder=""Value"" style=""width: 5%;"" />
                <select name=""Frequency"" class=""form-control"" style=""width: 15%;"">
                    <option value="""">[Frequency]</option>
                    <option value=""Minutely"">Minutely</option>
                    <option value=""Hourly"">Hourly</option>
                    <option value=""Daily"">Daily</option>
                    <option value=""Weekly"">Weekly</option>
                    <option value=""Monthly"">Monthly</option>
                    <option value=""Yearly"">Yearly</option>
                    <option value=""MinuteInterval"">MinuteInterval</option>
                    <option value=""HourInterval"">HourInterval</option>
                    <option value=""DayInterval"">DayInterval</option>
                    <option value=""MonthInterval"">MonthInterval</option>
                </select>
                <input type=""submit"" class=""form-control"" value=""Add"" style=""width: 8%;"" />
            </form>
        </div>

");


            
            #line 62 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
         if (recurringJobs.Count == 0)
        {

            
            #line default
            #line hidden
WriteLiteral("            <div class=\"alert alert-info\">\n                ");


            
            #line 65 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
           Write(Strings.RecurringJobsPage_NoJobs);

            
            #line default
            #line hidden
WriteLiteral("\n            </div>\n");


            
            #line 67 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("            <div class=\"js-jobs-list\">\n                <div class=\"btn-toolbar bt" +
"n-toolbar-top\">\n                    <button class=\"js-jobs-list-command btn btn-" +
"sm btn-primary\"\n                            data-url=\"");


            
            #line 73 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                 Write(Url.To("/recurring/trigger"));

            
            #line default
            #line hidden
WriteLiteral("\"\n                            data-loading-text=\"");


            
            #line 74 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                          Write(Strings.RecurringJobsPage_Triggering);

            
            #line default
            #line hidden
WriteLiteral("\"\n                            disabled=\"disabled\">\n                        <span " +
"class=\"glyphicon glyphicon-play-circle\"></span>\n                        ");


            
            #line 77 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                   Write(Strings.RecurringJobsPage_TriggerNow);

            
            #line default
            #line hidden
WriteLiteral("\n                    </button>\n\n                    <button class=\"js-jobs-list-c" +
"ommand btn btn-sm btn-default\"\n                            data-url=\"");


            
            #line 81 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                 Write(Url.To("/recurring/remove"));

            
            #line default
            #line hidden
WriteLiteral("\"\n                            data-loading-text=\"");


            
            #line 82 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                          Write(Strings.Common_Deleting);

            
            #line default
            #line hidden
WriteLiteral("\"\n                            data-confirm=\"");


            
            #line 83 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                     Write(Strings.Common_DeleteConfirm);

            
            #line default
            #line hidden
WriteLiteral("\"\n                            disabled=\"disabled\">\n                        <span " +
"class=\"glyphicon glyphicon-remove\"></span>\n                        ");


            
            #line 86 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                   Write(Strings.Common_Delete);

            
            #line default
            #line hidden
WriteLiteral("\n                    </button>\n\n");


            
            #line 89 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                     if (pager != null)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        ");

WriteLiteral(" ");


            
            #line 91 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                      Write(Html.PerPageSelector(pager));

            
            #line default
            #line hidden
WriteLiteral("\n");


            
            #line 92 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral(@"                </div>

                <div class=""table-responsive"">
                    <table class=""table"">
                        <thead>
                            <tr>
                                <th class=""min-width"">
                                    <input type=""checkbox"" class=""js-jobs-list-select-all"" />
                                </th>
                                <th class=""min-width"">");


            
            #line 102 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                                 Write(Strings.Common_Id);

            
            #line default
            #line hidden
WriteLiteral("</th>\n                                <th class=\"min-width\">");


            
            #line 103 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                                 Write(Strings.RecurringJobsPage_Table_Cron);

            
            #line default
            #line hidden
WriteLiteral("</th>\n                                <th class=\"min-width\">");


            
            #line 104 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                                 Write(Strings.RecurringJobsPage_Table_TimeZone);

            
            #line default
            #line hidden
WriteLiteral("</th>\n                                <th>");


            
            #line 105 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                               Write(Strings.Common_Job);

            
            #line default
            #line hidden
WriteLiteral("</th>\n                                <th class=\"align-right min-width\">");


            
            #line 106 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                                             Write(Strings.RecurringJobsPage_Table_NextExecution);

            
            #line default
            #line hidden
WriteLiteral("</th>\n                                <th class=\"align-right min-width\">");


            
            #line 107 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                                             Write(Strings.RecurringJobsPage_Table_LastExecution);

            
            #line default
            #line hidden
WriteLiteral("</th>\n                                <th class=\"align-right min-width\">");


            
            #line 108 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                                             Write(Strings.Common_Created);

            
            #line default
            #line hidden
WriteLiteral("</th>\n                            </tr>\n                        </thead>\n        " +
"                <tbody>\n");


            
            #line 112 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                             foreach (var job in recurringJobs)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <tr class=\"js-jobs-list-row hover\">\n             " +
"                       <td>\n                                        <input type=" +
"\"checkbox\" class=\"js-jobs-list-checkbox\" name=\"jobs[]\" value=\"");


            
            #line 116 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                                                                                             Write(job.Id);

            
            #line default
            #line hidden
WriteLiteral("\" />\n                                    </td>\n                                  " +
"  <td class=\"min-width\">");


            
            #line 118 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                                     Write(job.Id);

            
            #line default
            #line hidden
WriteLiteral("</td>\n                                    <td class=\"min-width\">\n                " +
"                        ");



WriteLiteral("\n");


            
            #line 121 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                          
                                            string cronDescription = null;
#if NETFULL
                                            try
                                            {
                                                cronDescription = string.IsNullOrEmpty(job.Cron) ? null : CronExpressionDescriptor.ExpressionDescriptor.GetDescription(job.Cron);
                                            }
                                            catch (FormatException)
                                            {
                                            }
#endif
                                        

            
            #line default
            #line hidden
WriteLiteral("\n");


            
            #line 134 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                         if (cronDescription != null)
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <code title=\"");


            
            #line 136 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                                    Write(cronDescription);

            
            #line default
            #line hidden
WriteLiteral("\">");


            
            #line 136 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                                                      Write(job.Cron);

            
            #line default
            #line hidden
WriteLiteral("</code>\n");


            
            #line 137 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                        }
                                        else
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <code>");


            
            #line 140 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                             Write(job.Cron);

            
            #line default
            #line hidden
WriteLiteral("</code>\n");


            
            #line 141 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                    </td>\n                                    <td" +
" class=\"min-width\">\n");


            
            #line 144 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                         if (!String.IsNullOrWhiteSpace(job.TimeZoneId))
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <span title=\"");


            
            #line 146 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                                    Write(TimeZoneInfo.FindSystemTimeZoneById(job.TimeZoneId).DisplayName);

            
            #line default
            #line hidden
WriteLiteral("\" data-container=\"body\">");


            
            #line 146 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                                                                                                                            Write(job.TimeZoneId);

            
            #line default
            #line hidden
WriteLiteral("</span>\n");


            
            #line 147 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                        }
                                        else
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            ");

WriteLiteral(" UTC\n");


            
            #line 151 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                    </td>\n                                    <td" +
" class=\"word-break\">\n");


            
            #line 154 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                         if (job.Job != null)
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            ");

WriteLiteral(" ");


            
            #line 156 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                          Write(Html.JobName(job.Job));

            
            #line default
            #line hidden
WriteLiteral("\n");


            
            #line 157 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                        }
                                        else
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <em>");


            
            #line 160 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                           Write(job.LoadException.InnerException.Message);

            
            #line default
            #line hidden
WriteLiteral("</em>\n");


            
            #line 161 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                    </td>\n                                    <td" +
" class=\"align-right min-width\">\n");


            
            #line 164 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                         if (job.NextExecution != null)
                                        {
                                            
            
            #line default
            #line hidden
            
            #line 166 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                       Write(Html.RelativeTime(job.NextExecution.Value));

            
            #line default
            #line hidden
            
            #line 166 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                                                                       
                                        }
                                        else
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <em>");


            
            #line 170 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                           Write(Strings.Common_NotAvailable);

            
            #line default
            #line hidden
WriteLiteral("</em>\n");


            
            #line 171 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                    </td>\n                                    <td" +
" class=\"align-right min-width\">\n");


            
            #line 174 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                         if (job.LastExecution != null)
                                        {
                                            if (!String.IsNullOrEmpty(job.LastJobId))
                                            {

            
            #line default
            #line hidden
WriteLiteral("                                                <a href=\"");


            
            #line 178 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                                    Write(Url.JobDetails(job.LastJobId));

            
            #line default
            #line hidden
WriteLiteral("\">\n                                                    <span class=\"label label-d" +
"efault label-hover\" style=\"background-color: ");


            
            #line 179 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                                                                                                      Write(JobHistoryRenderer.GetForegroundStateColor(job.LastJobState));

            
            #line default
            #line hidden
WriteLiteral(";\">\n                                                        ");


            
            #line 180 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                                   Write(Html.RelativeTime(job.LastExecution.Value));

            
            #line default
            #line hidden
WriteLiteral("\n                                                    </span>\n                    " +
"                            </a>\n");


            
            #line 183 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                            }
                                            else
                                            {

            
            #line default
            #line hidden
WriteLiteral("                                                <em>\n                            " +
"                        ");


            
            #line 187 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                               Write(Strings.RecurringJobsPage_Canceled);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 187 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                                                                   Write(Html.RelativeTime(job.LastExecution.Value));

            
            #line default
            #line hidden
WriteLiteral("\n                                                </em>\n");


            
            #line 189 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                            }
                                        }
                                        else
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <em>");


            
            #line 193 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                           Write(Strings.Common_NotAvailable);

            
            #line default
            #line hidden
WriteLiteral("</em>\n");


            
            #line 194 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                    </td>\n                                    <td" +
" class=\"align-right min-width\">\n");


            
            #line 197 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                         if (job.CreatedAt != null)
                                        {
                                            
            
            #line default
            #line hidden
            
            #line 199 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                       Write(Html.RelativeTime(job.CreatedAt.Value));

            
            #line default
            #line hidden
            
            #line 199 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                                                                   
                                        }
                                        else
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <em>N/A</em>\n");


            
            #line 204 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                    </td>\n                                </tr>\n");


            
            #line 207 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                             }

            
            #line default
            #line hidden
WriteLiteral("                        </tbody>\n                    </table>\n                </d" +
"iv>\n\n");


            
            #line 212 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                 if (pager != null)
                {

            
            #line default
            #line hidden
WriteLiteral("                    ");

WriteLiteral(" ");


            
            #line 214 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                  Write(Html.Paginator(pager));

            
            #line default
            #line hidden
WriteLiteral("\n");


            
            #line 215 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </div>\n");


            
            #line 217 "..\..\Dashboard\Pages\RecurringJobsPage.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\n</div>    ");


        }
    }
}
#pragma warning restore 1591
