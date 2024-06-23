using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpotifyLike.Application.Conta
{
    public class AzureServiceBusService : IAzureServiceBusService
    {
        private string ConnectionString = "Endpoint=sb://estudonelson.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=alRIlLmwpi5OSDKYYX+lDwNAPVfWZFT9U+ASbOTqQ8Q=";

        public AzureServiceBusService() { }

        public async Task SendMessage(Notificacao notificacao) 
        {
            ServiceBusClient client;
            ServiceBusSender sender;

            client = new ServiceBusClient(ConnectionString);

            sender = client.CreateSender("notificationqueue");

            var body = JsonSerializer.Serialize(notificacao);

            var message = new ServiceBusMessage(body);

            await sender.SendMessageAsync(message);

        }
    }
}
