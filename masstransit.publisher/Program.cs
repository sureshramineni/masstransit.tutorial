using EventContracts;
using MassTransit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace masstransit.publisher
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string connection = "Endpoint=sb://sureshbus-dev.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=NsmbVH+dJMRxlhvdKNJGnHnpR+f7USr/VqpboaTCzMM=";
            var bus = Bus.Factory.CreateUsingAzureServiceBus(cfg =>
            {
                cfg.Host(connection);
            });
            var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await bus.StartAsync(source.Token);
            try
            {
                do
                {
                    string value = await Task.Run(() =>
                    {
                        Console.WriteLine("Enter message (or quit to exit)");
                        Console.Write("> ");
                        return Console.ReadLine();
                    });

                    await bus.Publish<ValueEntered>(new { value = value });
                    if ("quit".Equals(value, StringComparison.OrdinalIgnoreCase))
                        break;
                } while (true);
            }
            finally
            {
                await bus.StopAsync();
            }
        }
    }
}
