using Common;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace masstransit.azurefunctions
{
    public class FlightOrderConsumer : IConsumer<FlightOrder>
    {
        readonly ILogger<FlightOrderConsumer> _logger;
        public FlightOrderConsumer(ILogger<FlightOrderConsumer> logger)
        {
            this._logger = logger;
        }

        public async Task Consume(ConsumeContext<FlightOrder> context)
        {
            _logger.LogInformation($"Flight Id :{context.Message.FlightId} | Flight Name :{context.Message.OrderId}");
            await Task.CompletedTask;
        }
    }
}
