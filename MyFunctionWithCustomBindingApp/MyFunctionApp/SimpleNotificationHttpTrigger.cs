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

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;

            //return name != null
            //    ? (ActionResult)new OkObjectResult($"Hello, {name}")
            //    : new BadRequestObjectResult("Please pass a name on the query string or in the request body");

            await notifications.AddAsync(new SimpleNotification {Name = name, Message = "Hello from my Function"});

            return new OkObjectResult("Check the Console for the Notification");
        }

        [FunctionName("ReceiveSimpleNotificationHttpTrigger")]
        public static async Task<IActionResult> ReceiveSimpleNotificationAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [SimpleServiceNotifiaction] string simpleServiceNotification,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function ReceiveSimpleNotificationHttpTrigger.");

            string name = req.Query["name"];
            
            return new OkObjectResult(simpleServiceNotification);
        }
    }
}
