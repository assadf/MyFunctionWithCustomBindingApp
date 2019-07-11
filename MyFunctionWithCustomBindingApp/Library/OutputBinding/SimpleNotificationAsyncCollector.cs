using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace Library.OutputBinding
{
    public class SimpleNotificationAsyncCollector : IAsyncCollector<SimpleNotification>
    {
        private readonly SimpleNotificationAttribute _attribute;

        public SimpleNotificationAsyncCollector(SimpleNotificationAttribute attribute)
        {
            _attribute = attribute;
        }

        public async Task AddAsync(SimpleNotification item, CancellationToken cancellationToken = new CancellationToken())
        {
            await SendSimpleNotificationAsync(1, item).ConfigureAwait(false);
            await SendSimpleNotificationAsync(2, item).ConfigureAwait(false);
        }

        public Task FlushAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.CompletedTask;
        }

        private async Task SendSimpleNotificationAsync(int count, SimpleNotification simpleNotification)
        {
            Console.WriteLine($"#{count}-{_attribute.PreMessage}:- Name={simpleNotification.Name}, Message={simpleNotification.Message}");
        }
    }
}
