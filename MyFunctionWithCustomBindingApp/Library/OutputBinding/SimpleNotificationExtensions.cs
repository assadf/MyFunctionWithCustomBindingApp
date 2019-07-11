using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;

namespace Library.OutputBinding
{
    [Extension("SimpleExtensions")]
    public class SimpleNotificationExtensions : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            var rule = context.AddBindingRule<SimpleNotificationAttribute>();

            rule.BindToCollector(BuildCollector);
        }

        private IAsyncCollector<SimpleNotification> BuildCollector(SimpleNotificationAttribute attribute)
        {
            return new SimpleNotificationAsyncCollector(attribute);
        }
    }
}
