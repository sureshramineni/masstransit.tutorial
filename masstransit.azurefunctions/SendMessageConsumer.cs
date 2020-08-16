using Common;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace masstransit.azurefunctions
{
    public class SendMessageConsumer : IConsumer<Message>
    {
        readonly ILogger<SendMessageConsumer> _logger;
        public SendMessageConsumer(ILogger<SendMessageConsumer> logger)
        {
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<Message> context)
        {
            _logger.LogInformation($"Message that consumer is processing is ${context.Message.Value}");
            await Task.CompletedTask;
        }
    }
}
