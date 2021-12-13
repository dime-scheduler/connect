namespace Dime.Scheduler.Connect
{
    internal class DimeSchedulerCredentials
    {
        internal DimeSchedulerCredentials(string uri, string user, string password)
        {
            Uri = uri;
            User = user;
            Password = password;
        }

        internal string Uri { get; private set; }
        internal string User { get; private set; }
        internal string Password { get; private set; }
    }
}