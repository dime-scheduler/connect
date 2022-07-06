using System.Net;
using System.Threading.Tasks;
using Dime.Scheduler.Sdk.Import;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Dime.Scheduler.Connect
{
    public class JobFunction : ImportService<Job>
    {
        private const string Description = "By default, this operation creates or updates the record. To remove the record, set the `ds-append` header to false.";
        private const string Summary = "Job";

        [FunctionName(Functions.Job)]
        [OpenApiOperation(operationId: Functions.Job, tags: new[] { Tags.Task }, Description = Description, Summary = Summary)]
        [OpenApiRequestBody(OpenApiAttributeValues.BodyJson, typeof(Job), Description = OpenApiAttributeValues.BodyDescription, Required = true)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: OpenApiAttributeValues.BodyJson, bodyType: typeof(string), Description = OpenApiAttributeValues.ReturnDescription)]
        [OpenApiParameter(name: OpenApiAttributeValues.DsHeaderUri, In = ParameterLocation.Header, Required = true, Description = OpenApiAttributeValues.DsHeaderUriDescription)]
        [OpenApiParameter(name: OpenApiAttributeValues.DsHeaderUser, In = ParameterLocation.Header, Required = true, Description = OpenApiAttributeValues.DsHeaderUserDescription)]
        [OpenApiParameter(name: OpenApiAttributeValues.DsHeaderPassword, In = ParameterLocation.Header, Required = true, Description = OpenApiAttributeValues.DsHeaderPasswordDescription)]
        [OpenApiParameter(name: OpenApiAttributeValues.DsHeaderAppend, In = ParameterLocation.Header, Required = false, Description = OpenApiAttributeValues.DsHeaderAppendDescription)]
        public Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
            => Import(req, log);
    }
}