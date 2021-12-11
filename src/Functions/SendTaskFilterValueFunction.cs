using Dime.Scheduler.Sdk.Import;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Dime.Scheduler.Connect.Test
{
    public class SendTaskFilterValueFunction : ImportService<TaskFilterValue>
    {
        [FunctionName("taskFilterValue")]
        public Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
            => Import(req, log);
    }
}