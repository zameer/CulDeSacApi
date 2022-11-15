// See https://aka.ms/new-console-template for more information
using Azure.Messaging.ServiceBus;

Console.WriteLine("Hello, World!");

string connectionString = "Endpoint=sb://culdesacbus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=K5cn1J197BMgN4iZ0JuKAEsfCV+ilWddRG4scMWqDg8=";
string queueName = "studentsqueue";
// since ServiceBusClient implements IAsyncDisposable we create it with "await using"
await using var client = new ServiceBusClient(connectionString);

//// create the sender
//ServiceBusSender sender = client.CreateSender(queueName);

//// create a message that we can send
//ServiceBusMessage message = new ServiceBusMessage("Hello world!");

//// send the message
//await sender.SendMessageAsync(message);

// create a receiver that we can use to receive and settle the message
ServiceBusReceiver receiver = client.CreateReceiver(queueName);

// the received message is a different type as it contains some service set properties
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

// complete the message, thereby deleting it from the service
await receiver.CompleteMessageAsync(receivedMessage);