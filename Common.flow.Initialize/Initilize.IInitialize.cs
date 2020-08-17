using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.flow.Initialize
{
    public partial class Initialize<TMessage> : IInitialize<TMessage>
        where TMessage : class, new()
    {
        TMessage IInitialize<TMessage>.Message
        {
            get => Message;
            set => Message = value;
        }

        Task IConsumer<InitializeEnvelope>.Consume(ConsumeContext<InitializeEnvelope> context)
        {
            _logger.LogInformation("Ramineni you are in InitializeEnvelope");
            return Task.CompletedTask;
        }
    }
}
