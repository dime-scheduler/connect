using System.IO;
using System.Threading.Tasks;
using Dime.Scheduler.Sdk;
using Dime.Scheduler.Sdk.Import;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Dime.Scheduler.AzureFunctions.Test
{
    public abstract class ImportService<T> where T : IImportRequestable
    {
        protected async Task<IActionResult> Import(HttpRequest req, ILogger log)
        {
            log.LogInformation("Received request to send data to Dime.Scheduler");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            T category = JsonConvert.DeserializeObject<T>(requestBody);

            string responseMessage = category == null
                ? "This HTTP triggered function executed successfully. Pass a valid entity in the request body to import the data to Dime.Scheduler."
                : $"This HTTP triggered function executed successfully.";

            IAuthenticator authenticator = new FormsAuthenticator
                    (DimeSchedulerCredentials.Uri,
                    DimeSchedulerCredentials.User,
                    DimeSchedulerCredentials.Password);

            DimeSchedulerClient client = new(DimeSchedulerCredentials.Uri, authenticator);

            IImportEndpoint importEndpoint = await client.Import.Request();
            await importEndpoint.ProcessAsync(category, TransactionType.Append);

            return new OkObjectResult(responseMessage);
        }
    }
}