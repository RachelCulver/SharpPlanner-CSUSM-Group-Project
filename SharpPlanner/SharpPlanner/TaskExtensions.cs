using System;
using System.Threading.Tasks;

namespace SharpPlanner
{

    // File based off https://docs.microsoft.com/en-us/xamarin/xamarin-forms/data-cloud/data/databases#install-the-sqlite-nuget-package

    public static class TaskExtensions
    {
 
        public static async void SafeFireAndForget(this Task task,
            bool returnToCallingContext,
            Action<Exception> onException = null)
        {
            try
            {
                await task.ConfigureAwait(returnToCallingContext);
            }

            // if the provided action is not null, catch and
            // pass the thrown exception
            catch (Exception ex) when (onException != null)
            {
                onException(ex);
            }
        }
    }
}
