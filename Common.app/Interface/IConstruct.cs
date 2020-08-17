using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.flow.Construct.Interface
{
    public interface IConstruct<TMessage> : IConsumer<ConstructEnvelope>
        where TMessage : class, new()
    {
        TMessage Message { get; set; }
    }
}
