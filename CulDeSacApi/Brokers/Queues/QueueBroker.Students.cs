using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Amqp.Framing;

namespace CulDeSacApi.Brokers.Queues
{
    public partial class QueueBroker
    {
        public ServiceBusClient StudentsQueue { get; private set; }
        public async void ListenToStudentsQueue(Func<ServiceBusReceivedMessage, Task> eventHandler)
        {
            await using var client = new ServiceBusClient(this.connectionString);

            ServiceBusReceiver receiver = client.CreateReceiver(nameof(StudentsQueue));
            ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

            await eventHandler(receivedMessage);

            await receiver.CompleteMessageAsync(receivedMessage);
        }
    }
}