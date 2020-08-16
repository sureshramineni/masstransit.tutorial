using EventContracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace masstransit.consumer
{
    public class EventConsumer : IConsumer<ValueEntered>
    {
        public async Task Consume(ConsumeContext<ValueEntered> context)
        {
            Console.WriteLine("value :{0}", context.Message.value);
        }
    }
}
