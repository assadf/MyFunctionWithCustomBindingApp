using System;
using Microsoft.Azure.WebJobs.Description;

namespace Library.OutputBinding
{
    [Binding]
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    public class SimpleNotificationAttribute : Attribute
    {
        public SimpleNotificationAttribute(string preMessage)
        {
            PreMessage = preMessage;
        }

        [AutoResolve]
        public string PreMessage { get; set; }
    }
}
