using System;
using Microsoft.Azure.WebJobs.Description;

namespace Library.InputBinding
{
    [Binding]
    [AttributeUsage(AttributeTargets.Parameter)]
    public class SimpleServiceNotifiactionAttribute : Attribute
    {
        [AutoResolve]
        public string PushNotificationMessage { get; set; }
    }
}
