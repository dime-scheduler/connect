using System.Threading.Tasks;
using Dime.Scheduler.Sdk.Import;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Dime.Scheduler.Connect
{
    public class ImportRequestFunction : ImportService<ImportRequest>
    {
        [FunctionName("importRequest")]
        public Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
            => Import(req, log);
    }
}