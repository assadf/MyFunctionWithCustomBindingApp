using System.Threading.Tasks;
using Library;
using Library.InputBinding;
using Library.OutputBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MyFunctionApp
{
    public static class SimpleNotificationHttpTrigger
    {
        [FunctionName("SendSimpleNotificationHttpTrigger")]
        public static async Task<IActionResult> SendSimpleNotificationAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [SimpleNotification("%PreMessage%")] IAsyncCollector<SimpleNotification> notifications,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function SendSimpleNotificationHttpTrigger.");

            string name = req.Query["name"];

            await notifications.AddAsync(new SimpleNotification {Name = name, Message = "Hello from my Function"});

            return new OkObjectResult("Check the Console for the Notification");
        }

        [FunctionName("ReceiveSimpleNotificationHttpTrigger")]
        public static async Task<IActionResult> ReceiveSimpleNotificationAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "api/{name}")] HttpRequest req, string name,
            [SimpleServiceNotifiaction(PushNotificationMessage = "{name}")] string simpleServiceNotification,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function ReceiveSimpleNotificationHttpTrigger.");
            
            return new OkObjectResult(simpleServiceNotification);
        }
    }
}
