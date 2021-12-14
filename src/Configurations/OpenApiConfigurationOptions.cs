using System;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;

namespace Dime.Scheduler.Connect
{
    public class OpenApiConfigurationOptions : DefaultOpenApiConfigurationOptions
    {
        public override OpenApiInfo Info { get; set; } = new OpenApiInfo()
        {
            Version = GetOpenApiDocVersion(),
            Title = "OpenAPI Document on Dime.Scheduler Connect",
            Description = "Link any system to Dime.Scheduler through Dime.Scheduler Connect",
            Contact = new OpenApiContact()
            {
                Name = "Dime Software",
                Email = "hello@dime-software.com",
                Url = new Uri("https://github.com/dime-scheduler/connect/issues"),
            },
            License = new OpenApiLicense()
            {
                Name = "MIT",
                Url = new Uri("http://opensource.org/licenses/MIT"),
            }
        };

        public override OpenApiVersionType OpenApiVersion { get; set; } = GetOpenApiVersion();
    }
}