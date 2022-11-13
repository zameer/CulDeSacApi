//https://learn.microsoft.com/en-us/samples/azure/azure-sdk-for-net/azuremessagingservicebus-samples/
using Azure.Messaging.ServiceBus;

namespace CulDeSacApi.Brokers.Queues
{
    public partial class QueueBroker : IQueueBroker
    {
        private readonly IConfiguration configuration;
        private string connectionString { get; set; }

        public QueueBroker(IConfiguration configuration)
        {
            this.connectionString = 
                configuration.GetConnectionString("ServiceBusConnection");
        }
    }
}
