using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.flow.Initialize
{
    public interface IInitialize<TMessage> : IConsumer<InitializeEnvelope>
        where TMessage : class, new()
    {
        TMessage Message { get; set; }
    }
}
