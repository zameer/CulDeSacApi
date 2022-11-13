using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using CulDeSacApi.Brokers.Queues;
using CulDeSacApi.Models.Fees;
using CulDeSacApi.Models.Students;
using Newtonsoft.Json;

namespace CulDeSacApi.Services.Foundations.StudentEvents
{
    public partial class StudentEventService : IStudentEventService
    {
        private readonly IQueueBroker queueBroker;

        public StudentEventService(IQueueBroker queueBroker) =>
            this.queueBroker = queueBroker;

        public void ListenToStudentEvent(Func<Student, ValueTask> studentEventHandler)
        {
            this.queueBroker.ListenToStudentsQueue(async (message) =>
            {
                Student incomingStudent = MapToStudent(message);
                await studentEventHandler(incomingStudent);
            });
        }

        public void ListenToFeeServiceEvent(Func<Fee, ValueTask> feeEventHandler)
        {
            this.queueBroker.ListenToStudentsQueue(async (message) =>
            {
                Fee incomingFee = MapToFee(message);
                await feeEventHandler(incomingFee);
            });
        }

        private static Student MapToStudent(ServiceBusReceivedMessage message)
        {
            string serializedStudent =
                Encoding.UTF8.GetString(message.Body);

            return JsonConvert.DeserializeObject<Student>(serializedStudent);
        }

        private static Fee MapToFee(ServiceBusReceivedMessage message)
        {
            string serializedFee =
                Encoding.UTF8.GetString(message.Body);

            return JsonConvert.DeserializeObject<Fee>(serializedFee);
        }
    }
}
