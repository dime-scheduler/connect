using System.Threading.Tasks;
using Dime.Scheduler.Sdk.Import;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Dime.Scheduler.AzureFunctions.Test
{
    public class SendContainerFunction : ImportService<Container>
    {
        [FunctionName("container")]
        public Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
            => Import(req, log);
    }
}