namespace Dime.Scheduler.Connect.Test
{
    internal class DimeSchedulerCredentials
    {
        internal DimeSchedulerCredentials(string uri, string user, string password)
        {
            Uri = uri;
            User = user;
            Password = password;
        }

        internal string Uri { get; set; }
        internal string User { get; set; }
        internal string Password { get; set; }
    }
}