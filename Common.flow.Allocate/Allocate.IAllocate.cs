using Common.flow.Allocate.Interface;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.flow.Allocate
{
    public partial class Allocate<TMessage> : IAllocate<TMessage>
    {
        TMessage IAllocate<TMessage>.Message
        {
            get => Message;
            set => Message = value;
        }
        public TMessage Message { get; set; }

        Task IConsumer<AllocateEnvelope>.Consume(ConsumeContext<AllocateEnvelope> context)
        {
            _logger.LogInformation("Suresh you are in AllocateEnvelope");
            return Task.CompletedTask;
        }
    }
}
