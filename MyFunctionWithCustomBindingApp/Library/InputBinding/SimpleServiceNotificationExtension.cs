using Microsoft.Azure.WebJobs.Host.Config;

namespace Library.InputBinding
{
    public class SimpleServiceNotificationExtension : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            var rule = context.AddBindingRule<SimpleServiceNotifiactionAttribute>();
            rule.BindToInput(a => a.PushNotificationMessage = "Hello from Simple Service {Query.name}");
        }
    }
}
