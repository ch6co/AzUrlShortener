using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;

namespace shortenerTools.JiraIssue
{
    public static class Issue
    {
        [FunctionName("Issue")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "issue/{val1}/{val2}/{val3?}")] HttpRequest req,
            string val1, string val2, string val3,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var redirectUrl = val3 == null 
                ? $"https://chromehearts.atlassian.net/servicedesk/customer/portal/7/group/28/create/144?customfield_10638={val1}&customfield_10639={val2}"
                : $"https://chromehearts.atlassian.net/servicedesk/customer/portal/7/group/28/create/144?customfield_10638={val1}&customfield_10639={val2}&summary=Issue%20in%20{val1}.{val2}%3A%20{val3}";
            return new RedirectResult(redirectUrl);
        }
    }
}
