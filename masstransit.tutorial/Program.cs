using MassTransit;
using System;
using System.Threading.Tasks;
namespace Sample.masstransit
{
    public class Family
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            string connection = "Endpoint=sb://sureshbus-dev.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=NsmbVH+dJMRxlhvdKNJGnHnpR+f7USr/VqpboaTCzMM=";
            try
            {
                var bus = Bus.Factory.CreateUsingAzureServiceBus(cfg =>
                {
                    cfg.Host(connection);
                    cfg.ReceiveEndpoint("test-queue", e =>
                    {
                        e.Handler<Family>(context =>
                        {
                            return Console.Out.WriteLineAsync($"Received: {context.Message.Name}");
                        });
                    });
                });
                await bus.StartAsync();
                await bus.Publish<Family>(new Family() { Name = "suresh", Age = 35 });
                await Task.Run(() => Console.ReadKey());
                await bus.StopAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }

}