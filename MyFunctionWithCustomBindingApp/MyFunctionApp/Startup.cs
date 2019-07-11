using Library.InputBinding;
using Library.OutputBinding;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;

namespace MyFunctionApp
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddExtension<SimpleNotificationExtensions>();
            builder.AddExtension<SimpleServiceNotificationExtension>();
        }
    }
}
