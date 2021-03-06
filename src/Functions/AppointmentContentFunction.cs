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
    public class AppointmentContentFunction : ImportService<AppointmentContent>
    {
        private const string Description = "";
        private const string Summary = "Appointment Content";

        [FunctionName(Functions.AppointmentContent)]
        [OpenApiOperation(operationId: Functions.AppointmentContent, tags: new[] { Tags.Appointment }, Description = Description, Summary = Summary)]
        [OpenApiRequestBody(OpenApiAttributeValues.BodyJson, typeof(AppointmentContent), Description = OpenApiAttributeValues.BodyDescription, Required = true)]
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