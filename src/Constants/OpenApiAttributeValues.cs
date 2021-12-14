namespace Dime.Scheduler.Connect
{
    internal class OpenApiAttributeValues
    {
        internal const string OperationTags = "Dime.Scheduler Import";

        internal const string SecurityScheme = "function_key";
        internal const string SecurityName = "code";

        internal const string BodyJson = "application/json";
        internal const string BodyDescription = "JSON request body containing the contents of the requested entity to be imported.";

        internal const string ReturnDescription = "The OK response message containing a JSON result.";

        internal const string DsHeaderUser = "ds-user";
        internal const string DsHeaderUserDescription = "Dime.Scheduler user";

        internal const string DsHeaderPassword = "ds-password";
        internal const string DsHeaderPasswordDescription = "Dime.Scheduler user password";

        internal const string DsHeaderUri = "ds-uri";
        internal const string DsHeaderUriDescription = "Dime.Scheduler URI";

        internal const string DsHeaderAppend = "ds-append";
        internal const string DsHeaderAppendDescription = "True to create or update the entity, false to remove it.";
    }
}