﻿// See https://aka.ms/new-console-template for more information

using Azure.Messaging.ServiceBus;

string ConnectionString = "Endpoint=sb://estudonelson.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=alRIlLmwpi5OSDKYYX+lDwNAPVfWZFT9U+ASbOTqQ8Q=";

ServiceBusClient client;
ServiceBusProcessor processor;


client = new ServiceBusClient(ConnectionString);

processor = client.CreateProcessor("notificationqueue");

processor.ProcessMessageAsync += MessageHandler;
processor.ProcessErrorAsync += ErrorHandler;

await processor.StartProcessingAsync();

Console.WriteLine("Processando mensagem. Aperte qualquer tecla para sair");
Console.ReadKey();

await processor.StopProcessingAsync();  


async Task MessageHandler(ProcessMessageEventArgs args)
{
    string body = args.Message.Body.ToString();
    Console.WriteLine($"Received: {body}");

    // complete the message. message is deleted from the queue. 
    await args.CompleteMessageAsync(args.Message);
}

Task ErrorHandler(ProcessErrorEventArgs args)
{
    Console.WriteLine(args.Exception.ToString());
    return Task.CompletedTask;
}




