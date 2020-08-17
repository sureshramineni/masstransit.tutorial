using Common.flow.Construct.Interface;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.flow.Construct
{
    public partial class Constructor<TMessage, TConstructed> : IConstruct<TMessage>
    {
        TMessage IConstruct<TMessage>.Message
        {
            get => Message;
            set => Message = value;
        }

        async Task IConsumer<ConstructEnvelope>.Consume(ConsumeContext<ConstructEnvelope> context)
        {
            _logger.LogInformation("Shaurya You are in  ConstructEnvelope :starting");
            var token = context.CancellationToken;
            var content = context.Message;
            var allocateResponse = await Allocate(Message, context, token)
                .ConfigureAwait(false);
            var initializeResponse = await Initialize(Message, context, token)
               .ConfigureAwait(false);
            var response = default(TMessage);
            await context.RespondAsync(response, x => x.CorrelationId = context.CorrelationId)
                .ConfigureAwait(false);
        }
    }
}
