using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.flow.Allocate
{
    public partial class Allocate<TMessage>
        where TMessage : class, CorrelatedBy<Guid>, new()
    {
        readonly ILogger<Allocate.Allocate<TMessage>> _logger;
        public Allocate(ILogger<Allocate.Allocate<TMessage>> logger )
        {
            _logger = logger;
        }
    }
}
