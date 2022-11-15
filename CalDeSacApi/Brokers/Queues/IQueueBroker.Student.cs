using Microsoft.Azure.ServiceBus;

namespace CalDeSacApi.Brokers.Queues
{
    public partial interface IQueueBroker
    {
        void ListenToStudentsQueue(Func<Message, CancellationToken, Task> eventHandler);
    }
}
