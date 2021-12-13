namespace Dime.Scheduler.Connect
{
    internal class ResponseMessages
    {
        internal const string UserMissing = "A Dime.Scheduler header is missing. Make sure to pass ds-user to the request headers";
        internal const string PasswordMissing = "A Dime.Scheduler header is missing. Make sure to pass ds-password to the request headers";
        internal const string UriMissing = "A Dime.Scheduler header is missing. Make sure to pass ds-uri to the request headers";
    }
}