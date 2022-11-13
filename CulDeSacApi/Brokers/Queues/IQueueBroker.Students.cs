using Azure.Messaging.ServiceBus;

namespace CulDeSacApi.Brokers.Queues
{
    public partial interface IQueueBroker
    {
        void ListenToStudentsQueue(Func<ServiceBusReceivedMessage, Task> eventHandler);
    }
}
