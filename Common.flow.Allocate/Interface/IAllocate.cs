using MassTransit;
using System;

namespace Common.flow.Allocate.Interface
{
    public interface IAllocate<TMessage> : IConsumer<AllocateEnvelope>
        where TMessage : class, new()
    {
        TMessage Message { get; set; }
    }
}
