using System.IO;
using System.Threading.Tasks;
using Dime.Scheduler.Sdk;
using Dime.Scheduler.Sdk.Import;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Dime.Scheduler.Connect
{
    public abstract class ImportService<T> where T : IImportRequestable
    {
        protected async Task<IActionResult> Import(HttpRequest req, ILogger log)
        {
            log.LogInformation("Received request to send data to Dime.Scheduler");

            string user = req.Headers["ds-user"];
            string password = req.Headers["ds-password"];
            string url = req.Headers["ds-uri"];
            bool append = string.IsNullOrEmpty(req.Headers["ds-append"]) || bool.Parse(req.Headers["ds-append"]);

            if (string.IsNullOrEmpty(user))
                return new BadRequestObjectResult(ResponseMessages.UserMissing);
            if (string.IsNullOrEmpty(password))
                return new BadRequestObjectResult(ResponseMessages.PasswordMissing);
            if (string.IsNullOrEmpty(url))
                return new BadRequestObjectResult(ResponseMessages.UriMissing);

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            T entity = JsonConvert.DeserializeObject<T>(requestBody);

            IAuthenticator authenticator = new FormsAuthenticator(url, user, password);
            DimeSchedulerClient client = new(url, authenticator);

            IImportEndpoint importEndpoint = await client.Import.Request();
            ImportSet importSet = await importEndpoint.ProcessAsync(entity, append ? TransactionType.Append : TransactionType.Delete);

            if (importSet.Success)
                return new OkObjectResult(importSet);

            ObjectResult result = new(importSet.Message);
            result.StatusCode = importSet.Status;
            return result;
        }
    }
}