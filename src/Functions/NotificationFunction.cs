using Dime.Scheduler.Sdk.Import;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Threading.Tasks;

namespace Dime.Scheduler.Connect
{
    public class NotificationFunction : ImportService<Notification>
    {
        [FunctionName("notification")]
        [OpenApiOperation(operationId: OpenApiAttributeValues.OperationId, tags: new[] { OpenApiAttributeValues.OperationTags })]
        [OpenApiSecurity(OpenApiAttributeValues.SecurityScheme, SecuritySchemeType.ApiKey, Name = OpenApiAttributeValues.SecurityName, In = OpenApiSecurityLocationType.Query)]
        [OpenApiRequestBody(OpenApiAttributeValues.BodyJson, typeof(Notification), Description = OpenApiAttributeValues.BodyDescription)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: OpenApiAttributeValues.BodyJson, bodyType: typeof(string), Description = OpenApiAttributeValues.ReturnDescription)]
        [OpenApiParameter(name: OpenApiAttributeValues.DsHeaderUri, In = ParameterLocation.Header, Required = true, Description = OpenApiAttributeValues.DsHeaderUriDescription)]
        [OpenApiParameter(name: OpenApiAttributeValues.DsHeaderUser, In = ParameterLocation.Header, Required = true, Description = OpenApiAttributeValues.DsHeaderUserDescription)]
        [OpenApiParameter(name: OpenApiAttributeValues.DsHeaderPassword, In = ParameterLocation.Header, Required = true, Description = OpenApiAttributeValues.DsHeaderPasswordDescription)]
        public Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
            => Import(req, log);
    }
}