using Dime.Scheduler.Sdk;
using Dime.Scheduler.Sdk.Import;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace Dime.Scheduler.Connect.Test
{
    public abstract class ImportService<T> where T : IImportRequestable
    {
        protected async Task<IActionResult> Import(HttpRequest req, ILogger log)
        {
            log.LogInformation("Received request to send data to Dime.Scheduler");

            string user = req.Headers["ds-user"];
            string password = req.Headers["ds-password"];
            string url = req.Headers["ds-uri"];

            if (string.IsNullOrEmpty(user))
                return new BadRequestObjectResult("A Dime.Scheduler header is missing. Make sure to pass ds-user to the request headers");
            if (string.IsNullOrEmpty(password))
                return new BadRequestObjectResult("A Dime.Scheduler header is missing. Make sure to pass ds-password to the request headers");
            if (string.IsNullOrEmpty(url))
                return new BadRequestObjectResult("A Dime.Scheduler header is missing. Make sure to pass ds-uri to the request headers");

            DimeSchedulerCredentials credentials = new(url, user, password);
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            T category = JsonConvert.DeserializeObject<T>(requestBody);

            IAuthenticator authenticator = new FormsAuthenticator(credentials.Uri, credentials.User, credentials.Password);
            DimeSchedulerClient client = new(credentials.Uri, authenticator);

            IImportEndpoint importEndpoint = await client.Import.Request();
            ImportSet importSet = await importEndpoint.ProcessAsync(category, TransactionType.Append);

            return new OkObjectResult(importSet);
        }
    }
}