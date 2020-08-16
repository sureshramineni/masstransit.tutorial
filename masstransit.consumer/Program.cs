using MassTransit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace masstransit.consumer
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingAzureServiceBus(cfg =>
            {
                string connection = "Endpoint=sb://sureshbus-dev.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=NsmbVH+dJMRxlhvdKNJGnHnpR+f7USr/VqpboaTCzMM=";
                cfg.Host(connection);
                cfg.ReceiveEndpoint("event-listener", e =>
                {
                    e.Consumer<EventConsumer>();
                });
            });

            var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await bus.StartAsync(source.Token);

            try
            {
                Console.WriteLine("Press enter to exit");
                await Task.Run(() => Console.ReadLine());
            }
            finally
            {
                await bus.StopAsync();
            }
        }
    }
}
