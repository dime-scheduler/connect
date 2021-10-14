using System;

namespace Dime.Scheduler.AzureFunctions.Test
{
    internal class DimeSchedulerCredentials
    {
        public DimeSchedulerCredentials(string uri, string user, string password)
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