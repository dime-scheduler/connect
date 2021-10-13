using System;
using System.Threading.Tasks;
using Dime.Scheduler.Sdk.Import;
using Dime.Scheduler.AzureFunctions.Test;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Dime.Scheduler.AzureFunctions.Test
{
    public class SendTimeMarkerFunction : ImportService<TimeMarker>
    {
        [FunctionName("timemarker")]
        public Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
            => Import(req, log);
    }
}