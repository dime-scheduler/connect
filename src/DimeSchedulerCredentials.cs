using System;

namespace Dime.Scheduler.AzureFunctions.Test
{
    internal static class DimeSchedulerCredentials
    {
        internal static string Uri => GetEnvironmentVariable(nameof(Uri));
        internal static string User => GetEnvironmentVariable(nameof(User));
        internal static string Password => GetEnvironmentVariable(nameof(Password));

        private static string GetEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }
    }
}